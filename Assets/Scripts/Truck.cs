using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : Actor {
    [SerializeField] private float speed = 5f;
    private Vector3 direction;

    public override void Initialize(Vector3 pos, Vector3 direction, float speed) {
        this.direction = direction;
        this.speed = speed;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
