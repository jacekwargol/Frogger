using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int startingLives = 4;

    private int currentLives;

    private bool isMovingHorizontal = false;
    private bool isMovingVertical = false;

    private Vector3 originalPos;


    public void LifeLost() {
        if(currentLives <= 0) {
            Debug.Log(GameManager.Instance);
            GameManager.Instance.HandleLose();
        }

        else {
            currentLives--;
            transform.position = originalPos;
        }
    }


    private void Start() {
        originalPos = transform.position;
        currentLives = startingLives;
    }

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

    private void SpawnCat() {
        var cat = new GameObject();
        var sr = cat.AddComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.sortingLayerName = "Player";
        cat.transform.localScale = transform.localScale;
        Instantiate(cat, transform.position, Quaternion.identity);
    }

    private void Move(Vector3 pos) {
        transform.position += pos;
    }

    private void OnDestroyerCollision() {
        LifeLost();
    }
}
