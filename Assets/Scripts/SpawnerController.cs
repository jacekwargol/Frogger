using UnityEngine;


public class SpawnerController : MonoBehaviour {
    [SerializeField] private Transform actorPrefab;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private Vector3 direction;

    [SerializeField] private float minSpeed = 3;
    [SerializeField] private float maxSpeed = 5;


    private float timeTillSpawn;


    void Update() {
        timeTillSpawn -= Time.deltaTime;
        if(timeTillSpawn <= 0) {
            var speed = Random.Range(minSpeed, maxSpeed);
            var actor = Instantiate(actorPrefab, transform.position, Quaternion.identity).
                GetComponent<Actor>();

            actor.Initialize(transform.position, direction, speed);
            timeTillSpawn = spawnRate;
        }
    }
}
