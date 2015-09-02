using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
	public GameObject enemyPrefab;

	private float spawnDelay = 5f;

	// Use this for initialization
	void Start ()
	{
		Invoke ("SpawnEnemy", spawnDelay);

		// increase spawn rate every 30 seconds.
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void SpawnEnemy ()
	{
//		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject enemy = (GameObject)Instantiate (enemyPrefab);
		enemy.transform.position = new Vector2 (max.x, -5.28f);

		NextEnemySpawn ();
	}

	void NextEnemySpawn ()
	{
		float spawnDelays;

		if (spawnDelay > 1f) {
			spawnDelays = Random.Range (1f, spawnDelay);
		} else {
			spawnDelays = 1f;
		}

		Invoke ("SpawnEnemy", spawnDelays);
	}

	void IncreaseSpawnRate ()
	{
		if (spawnDelay > 1f)
			spawnDelay--;

		if (spawnDelay == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}
}