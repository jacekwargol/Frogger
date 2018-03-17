using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
    [SerializeField] private int pointsForCat = 50;
    [SerializeField] private int pointsForWin = 200;

    private int score;
    private Text scoreText;

    public void ScoreCat() {
        score += pointsForCat;
    }

    public void ScoreWin() {
        score += pointsForWin;
    }

    private void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    private void Update() {
        scoreText.text = score.ToString();
    }
}
