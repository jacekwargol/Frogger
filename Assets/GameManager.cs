using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int startingLives = 4;
    private int livesLeft;
    private int catsAtHome = 0;


    private GameManager() { }

    private void Awake() {
        livesLeft = startingLives;

        if(Instance == null) {
            Instance = this;
        }

        else if(Instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
