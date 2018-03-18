using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private int startingLives = 4;

    public int LivesLeft { get; private set; }

    private bool isMovingHorizontal = false;
    private bool isMovingVertical = false;

    private Vector3 originalPos;

    private LivesDisplay livesDisplay;


    public void LifeLost() {
        LivesLeft--;
        livesDisplay.UpdateLives();

        if(LivesLeft <= 0) {
            Debug.Log(GameManager.Instance);
            GameManager.Instance.HandleLose();
        }

        else {
            transform.SetParent(null);
            transform.position = originalPos;
        }
    }


    private void Awake() {
        originalPos = transform.position;
        LivesLeft = startingLives;

        livesDisplay = FindObjectOfType<LivesDisplay>();
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

    private void FreeHomeCollision() {
        var cat = new GameObject();
        var sr = cat.AddComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.sortingLayerName = "Player";
        cat.transform.localScale = transform.localScale;
        Instantiate(cat, transform.position, Quaternion.identity);

        transform.position = originalPos;

    }

    private void Move(Vector3 pos) {
        var newX = Mathf.Clamp(transform.position.x + pos.x, 0f, 13f);
        var newY = Mathf.Clamp(transform.position.y + pos.y, 0f, 13f);
        transform.position = new Vector3(newX, newY, 0f);
    }

    private void OnDestroyerCollision() {
        LifeLost();
    }
}
