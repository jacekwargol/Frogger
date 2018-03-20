using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField] private GameObject pauseMenuUI;


    public void Resume() {
        pauseMenuUI.SetActive(false);
        GameManager.Instance.IsGamePaused = false;
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }


    private void Update() {
        HandleInput();
    }

    private void HandleInput() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameManager.Instance.IsGamePaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    private void Pause() {
        pauseMenuUI.SetActive(true);
        GameManager.Instance.IsGamePaused = true;
        Time.timeScale = 0f;
    }
}
