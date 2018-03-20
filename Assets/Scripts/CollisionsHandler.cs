using UnityEngine;

public class CollisionsHandler : MonoBehaviour {
    private bool isOnPlatform = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Platform")) {
            PlatformCollision(other);
        }

        else if(other.CompareTag("Destroyer")) {
            DestroyerCollision();
        }

        else if(other.CompareTag("Water") && !isOnPlatform) {
            WaterCollision();
        }

        else if(other.CompareTag("Home")) {
            HomeCollision(other);
        }
    }

    private void DestroyerCollision() {
        SendMessage("OnDestroyerCollision");
    }

    private void PlatformCollision(Collider2D other) {
        transform.SetParent(other.transform);
        isOnPlatform = true;
    }


    private void WaterCollision() {
        var collisions = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
            0.1f);
        foreach(var collider in collisions) {
            if(collider.CompareTag("Platform")) {
                isOnPlatform = true;
                return;
            }
        }

        DestroyerCollision();
    }

    private void HomeCollision(Collider2D other) {
        var home = other.GetComponent<HomeTile>();
        if(home == null) {
            return;
        }

        if(home.IsFree) {
            home.IsFree = false;
            GameManager.Instance.CatAtHome();
            SendMessage("OnFreeHomeCollision");
        }
        else {
            DestroyerCollision();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Platform")) {
            transform.SetParent(null);
            isOnPlatform = false;
        }
    }
}
