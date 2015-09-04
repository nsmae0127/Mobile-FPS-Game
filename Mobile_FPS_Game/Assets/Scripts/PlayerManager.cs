using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
	public GameObject gameManager;

	public GameObject explosionPrefab;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if ((col.collider.CompareTag ("Enemy")) || (col.collider.CompareTag ("EnemyBullet"))) {
			PlayExplosion ();

//			healthPoint--; //subtract player's health point

//			if (health == 0) //if health point is zero, player is dead
//			{
			//change game manager state to game over state
			gameManager.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameOver);

			//hide the player
			gameObject.SetActive (false);
//			}
		}
	}

	void PlayExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate (explosionPrefab);

		explosion.transform.position = transform.position;
	}

	// Initialize the game settings and player' status
	public void Init ()
	{
		//update the health point

		//set this player game object to active
		gameObject.SetActive (true);
	}
}