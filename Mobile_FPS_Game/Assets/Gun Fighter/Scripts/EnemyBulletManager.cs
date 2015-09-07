using UnityEngine;
using System.Collections;

public class EnemyBulletManager : MonoBehaviour
{
	public GameObject enemyBulletPrefab;

	// Use this for initialization
	void Start ()
	{
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FireEnemyBullet ()
	{
		GameObject player = GameObject.Find ("Player");

		if (player != null) {
			GameObject bullet = (GameObject)Instantiate (enemyBulletPrefab);

			bullet.transform.position = transform.position;

			Vector2 direction = player.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
		}
	}
}
