using UnityEngine;


public class SpawnerController : MonoBehaviour {
    [SerializeField] private Transform actorPrefab;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private Vector3 direction;

    private float timeTillSpawn;


    void Start() {
//        var random = new System.Random();
//        var direction = (random.Next(0, 2) == 0 ? Vector3.left : Vector3.right);
    }

    void Update() {
        timeTillSpawn -= Time.deltaTime;
        if(timeTillSpawn <= 0) {
            var actor = Instantiate(actorPrefab, transform.position, Quaternion.identity).
                GetComponent<Actor>();

            actor.Initialize(transform.position, direction);
            timeTillSpawn = spawnRate;
        }
    }
}
