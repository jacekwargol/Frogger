using UnityEngine;

public class PlayerController : MonoBehaviour {
    private bool isMovingHorizontal = false;
    private bool isMovingVertical = false;
    private bool isOnPlatform = false;

    // Use this for initialization
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {
        HandleInput();
    }

    private void HandleInput() {
        float x;
        if((x = Input.GetAxisRaw("Horizontal")) != 0) {
            if(!isMovingHorizontal) {
                Move(new Vector3(x, 0, 0));
                isMovingHorizontal = true;
            }
        }
        else {
            isMovingHorizontal = false;
        }

        float y;
        if((y = Input.GetAxisRaw("Vertical")) != 0) {
            if(!isMovingVertical) {
                Move(new Vector3(0, y, 0));
                isMovingVertical = true;
            }
        }
        else {
            isMovingVertical = false;
        }
    }

    private void Move(Vector3 pos) {
        transform.position += pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Platform")) {
            transform.SetParent(other.transform);
            isOnPlatform = true;
        }

        else if(other.CompareTag("Destroyer")) {
//            Destroy(gameObject);
        }

        else if(other.CompareTag("Water") && !isOnPlatform) {
//            Collider2D[] collisions = new Collider2D[10];
            var collisions = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
                0.1f);
            foreach(var collider in collisions) {
                Debug.Log(collider);
                if(collider.CompareTag("Platform")) {
                    isOnPlatform = true;
                    break;
                }
            }

            if(!isOnPlatform)
            {
                Debug.Log("water");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        //        if(other.CompareTag("Platform")) {
        //            transform.SetParent(other.transform);
        //            isOnPlatform = true;
        //            Debug.Log("platform");
        //        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Platform")) {
            transform.SetParent(null);
            isOnPlatform = false;
        }
    }
}
