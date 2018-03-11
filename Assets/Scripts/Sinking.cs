using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sinking : MonoBehaviour {
    [SerializeField] private float sinkingRate = 2f;
    [SerializeField] private float timeUnderwater = 2f;

    private bool isUnderwater = false;
    private float timeToSink;
    private float timeToResurface;
    private SpriteRenderer sprite;
    private Color baseColor;
    private Color underwaterColor = Color.blue;

    private void Awake() {
        timeToSink = sinkingRate;
        timeToResurface = timeUnderwater;
        sprite = GetComponent<SpriteRenderer>();
        baseColor = sprite.color;
    }

    private void Update() {
        if(isUnderwater) {
            if(timeToResurface <= 0) {
                Resurface();
            }
            else {
                timeToResurface -= Time.deltaTime;
            }
        }
        else {
            if(timeToSink <= 0) {
                Sink();
            }
            else {
                timeToSink -= Time.deltaTime;
            }
        }
    }

    private void Sink() {
        isUnderwater = true;
        timeToSink = sinkingRate;
        gameObject.tag = "Untagged";
        sprite.color = underwaterColor;
    }

    private void Resurface() {
        isUnderwater = false;
        timeToResurface = timeUnderwater;
        gameObject.tag = "Platform";
        sprite.color = baseColor;
    }
}
