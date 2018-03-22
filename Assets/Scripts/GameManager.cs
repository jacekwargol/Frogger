using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private Animator gameOverAnimation;
    [SerializeField] private ScoreController scoreController;

    public static GameManager Instance { get; private set; }

    public bool IsGamePaused { get; set; }


    private int catsAtHome = 0;
    private readonly int catsToWin = 4;

    private bool isGameOver = false;

    private GameManager() { }


    public void CatAtHome() {
        catsAtHome += 1;
        if(catsAtHome == catsToWin) {
            HandleWin();
        }
    }

    public void HandleLose() {
        isGameOver = true;
        gameOverAnimation.SetTrigger("GameOver");
    }


    private void HandleWin() {
        isGameOver = true;
        scoreController.ScoreWin();
        gameOverAnimation.SetTrigger("Win");
    }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }

        else if(Instance != this) {
            Destroy(gameObject);
        }
    }

    private void Update() {
        HandleInput();
    }

    private void HandleInput() {
        if(isGameOver) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                ResetScene();
            }
        }
    }

    private void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
