using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Actor {
    [SerializeField] private float speed = 5f;
    private Vector3 direction;

    public override void Initialize(Vector3 pos, Vector3 direction) {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
