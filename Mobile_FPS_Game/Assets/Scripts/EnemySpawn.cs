using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemyPrefab;

	private float spawnDelay = 5f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	// Function to spawn an enemy
	void SpawnEnemy ()
	{
//		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//this is the top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//instantiate an enemy
		GameObject enemy = (GameObject)Instantiate (enemyPrefab);
		enemy.transform.position = new Vector2 (max.x, -5.28f);

		//schedule when to spawn next enemy
		ScheduleNextEnemySpawn ();
	}

	void ScheduleNextEnemySpawn ()
	{
		float spawnDelays;

		if (spawnDelay > 1f) {
			spawnDelays = Random.Range (1f, spawnDelay);
		} else {
			spawnDelays = 1f;
		}

		Invoke ("SpawnEnemy", spawnDelays);
	}

	// Function to increase the difficulty of the game
	void IncreaseSpawnRate ()
	{
		if (spawnDelay > 1f)
			spawnDelay--;

		if (spawnDelay == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	// Function to start enemy spawn
	public void ScheduleEnemySpawn ()
	{
		Invoke ("SpawnEnemy", spawnDelay);

		//increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}

	// Fucton to stop enemy spawn
	public void UnscheduleEnemySpawn ()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
}