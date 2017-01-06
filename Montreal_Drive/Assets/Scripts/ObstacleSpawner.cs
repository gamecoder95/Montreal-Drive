using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	public ScrollingObject obstacle;
	public float lowerLimitSpawn_x;
	public float upperLimitSpawn_x;
	private float spawnPoint_y;
	private float obstacleHeight;
	private float cameraTop_y;
	private const float EXTRA_HEIGHT = 2.0f;

	// Use this for initialization
	void Start () {
		obstacleHeight = obstacle.GetComponent<SpriteRenderer> ().bounds.size.y;
		cameraTop_y = Camera.main.orthographicSize;
		spawnPoint_y = cameraTop_y + obstacleHeight + EXTRA_HEIGHT;
	}
	
	// Update is called once per frame
	void Update () {

		// Temporary; the aim is to spawn obstacles periodically, using a defined time interval.
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.spawnObstacleAtRandomPoint ();
		}
	}

	void spawnObstacle(float x, float y)
	{
		Instantiate (obstacle, new Vector3 (x, y, 0.0f), Quaternion.identity);
	}

	void spawnObstacleAtRandomPoint()
	{
		float spawnPoint_x = Random.Range (lowerLimitSpawn_x, upperLimitSpawn_x);
		if (isLatestObstacleAboveScreen ()) {

			GameObject latestSpawnedObstacle = getLatestSpawnedObstacle ();
			float latestSpawnedObstacle_y = latestSpawnedObstacle.transform.position.y;
			float spawnPointAboveLatestObstacle_y = latestSpawnedObstacle_y + obstacleHeight + EXTRA_HEIGHT;

			spawnObstacle (spawnPoint_x, spawnPointAboveLatestObstacle_y);
			
		} else {
			spawnObstacle (spawnPoint_x, spawnPoint_y);
		}
	}

	GameObject getLatestSpawnedObstacle()
	{
		GameObject[] spawnedObstacles = GameObject.FindGameObjectsWithTag ("Obstacle");
		if (spawnedObstacles.Length == 0) {
			return null;
		} else {
			return spawnedObstacles [spawnedObstacles.Length - 1];
		}
	}

	bool isLatestObstacleAboveScreen()
	{
		GameObject latestSpawnedObstacle = getLatestSpawnedObstacle ();

		if (latestSpawnedObstacle == null) {
			return false;
		} else {
			
			float latestSpawnedObstacle_y = latestSpawnedObstacle.transform.position.y;
			float latestSpawnedObstacleBottom_y = latestSpawnedObstacle_y + obstacleHeight;

			return latestSpawnedObstacleBottom_y >= cameraTop_y;
		}
			

	}
		
}
