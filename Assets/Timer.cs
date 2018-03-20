using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField] private float startingTime = 90f;

    private float timeLeft;
    private Slider timer;

    void Start() {
        timeLeft = startingTime;
        timer = GetComponent<Slider>();
        timer.maxValue = startingTime;
    }

    // Update is called once per frame
    void Update() {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0) {
            GameManager.Instance.HandleLose();
        }
        else {
            timer.value = timeLeft;
        }
    }
}
