using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private int catsAtHome = 0;
    private readonly int catsToWin = 4;
    private PlayerController player;


    private GameManager() { }


    public void CatAtHome(Collider2D other) {
        Debug.Log(catsAtHome);
        var home = other.GetComponent<HomeTile>();
        if(home == null) {
            return;
        }

        if(home.IsFree) {
            home.IsFree = false;
            catsAtHome += 1;
            if(catsAtHome == catsToWin) {
                HandleWin();
            }
            Debug.Log(catsAtHome);
        }
        else {
            player.LifeLost();
        }
    }

    public void HandleLose() {
        Debug.Log("lose");
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
        var playerObject = GameObject.FindWithTag("Player");

        if(playerObject != null) {
            player = playerObject.GetComponent<PlayerController>();
            Debug.Log(player);
            Debug.Log("player found");
        }
        player = playerObject.GetComponent<PlayerController>();
        Debug.Log(player);
    }
}
