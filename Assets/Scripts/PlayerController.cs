using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private AudioClip deathSound;

    [SerializeField]
    private ScoreController scoreController;
    [SerializeField] private int startingLives = 4;

    public int LivesLeft { get; private set; }

    private bool isMovingHorizontal = false;
    private bool isMovingVertical = false;

    private Vector3 originalPos;

    private int maxLineReached;

    private LivesDisplay livesDisplay;

    private bool isDying = false;

    private AudioSource audioSource;


    public void LifeLost() {
        LivesLeft--;
        livesDisplay.UpdateLives();

        if(LivesLeft <= 0) {
            isDying = true;
            GameManager.Instance.HandleLose();
        }

        else {
            transform.SetParent(null);
            transform.position = originalPos;
        }
    }


    private void Start() {
        originalPos = transform.position;
        LivesLeft = startingLives;

        livesDisplay = FindObjectOfType<LivesDisplay>();

        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(!isDying && !GameManager.Instance.IsGamePaused) {
            HandleInput();
        }
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

    private void OnFreeHomeCollision() {
        SpawnNewCat();
        transform.position = originalPos;

        scoreController.ScoreCat();
    }

    private void SpawnNewCat() {
        var cat = new GameObject();
        var sr = cat.AddComponent<SpriteRenderer>();
        sr.sprite = GetComponent<SpriteRenderer>().sprite;
        sr.sortingLayerName = "Player";
        cat.transform.localScale = transform.localScale;
        cat.transform.position = transform.position;
//        Instantiate(cat, transform.position, Quaternion.identity);
    }

    private void Move(Vector3 pos) {
        var newX = Mathf.Clamp(transform.position.x + pos.x, 0f, 13f);
        var newY = Mathf.Clamp(transform.position.y + pos.y, 0f, 13f);
        transform.position = new Vector3(newX, newY, 0f);

        if(newY > maxLineReached) {
            maxLineReached = (int)newY;
            scoreController.ScoreNewLine();
        }
    }

    private void OnDestroyerCollision() {
//        audioSource.PlayOneShot(deathSound, 1f);
        LifeLost();
    }
}
