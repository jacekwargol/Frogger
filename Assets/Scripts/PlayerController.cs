using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int startingLives = 4;

    private bool isMovingHorizontal = false;
    private bool isMovingVertical = false;
    private int currentLives;
    private Rigidbody2D rb;
    private Vector3 originalPos;


    public void LifeLost() {
        if(currentLives <= 0) {
            GameManager.Instance.HandleLose();
        }

        else {
            currentLives--;
            transform.position = originalPos;
        }
    }


    // Use this for initialization
    private void Start() {
        originalPos = transform.position;
        currentLives = startingLives;
        rb = GetComponent<Rigidbody2D>();
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
//        rb.MovePosition(transform.position + pos);
    }

    private void OnDestroyerCollision() {
        LifeLost();
    }
}
