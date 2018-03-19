using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int catsAtHome = 0;
    private readonly int catsToWin = 4;

    private Animator anim;

    private GameManager() { }


    public void CatAtHome() {
        catsAtHome += 1;
        if(catsAtHome == catsToWin) {
            HandleWin();
        }
    }

    public void HandleLose() {
       anim.SetTrigger("GameOver");
    }


    private void HandleWin() {
        Debug.Log("win");
    }

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }

        else if(Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        anim = FindObjectOfType<Animator>();
    }
}
