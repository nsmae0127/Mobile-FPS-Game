using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	GameObject scoreText;

	public GameObject explosionPrefab;

	[SerializeField]
	private float
		speed;

	// Use this for initialization
	void Start ()
	{
		//get the score texx UI
		scoreText = GameObject.FindGameObjectWithTag ("ScoreText");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 position = transform.position;

		position = new Vector2 (position.x - speed * Time.deltaTime, position.y);

		transform.position = position;

		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		if (transform.position.x < min.x) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if ((col.collider.CompareTag ("Player")) || (col.collider.CompareTag ("PlayerBullet"))) {
			PlayExposion ();

			//add 100 points to the score
			scoreText.GetComponent<GameScore> ().Score += 100;

			Destroy (gameObject);
		}
	}

	void PlayExposion ()
	{
		GameObject explosion = (GameObject)Instantiate (explosionPrefab);

		explosion.transform.position = transform.position;
	}
}
