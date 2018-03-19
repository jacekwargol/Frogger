using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayClassic() {
        SceneManager.LoadScene("Classic");
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
