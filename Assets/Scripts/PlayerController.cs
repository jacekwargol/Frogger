using UnityEngine;

public class PlayerController : MonoBehaviour {
    private bool isMovingHorizontal;
    private bool isMovingVertical;

    // Use this for initialization
    private void Start() {
        isMovingHorizontal = false;
        isMovingVertical = false;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Truck>()) {
            Destroy(gameObject);
        }
    }
}
