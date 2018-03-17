using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour {
    private int livesLeft;
    private Text livesText;
    private PlayerController player;


    void Start() {
        player = FindObjectOfType<PlayerController>();
        livesLeft = player.LivesLeft;
        livesText = GetComponent<Text>();
        livesText.text = livesLeft.ToString();
    }

    public void UpdateLives() {
        livesLeft = player.LivesLeft;
        livesText.text = livesLeft.ToString();
    }
}
