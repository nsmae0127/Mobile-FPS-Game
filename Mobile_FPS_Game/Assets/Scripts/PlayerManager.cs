using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		if ((col.collider.CompareTag("Enemy")) || (col.collider.CompareTag("EnemyBullet"))) {
			PlayExplosion ();

			Destroy (gameObject);
		}
	}

	void PlayExplosion() {
		GameObject explosion = (GameObject)Instantiate (explosionPrefab);

		explosion.transform.position = transform.position;
	}
}