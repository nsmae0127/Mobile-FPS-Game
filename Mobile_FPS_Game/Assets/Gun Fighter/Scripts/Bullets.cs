using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour
{
	private float speed = 8f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Get the bullet's current position
		Vector2 position = transform.position;	

		//compute the bullet's new position
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		//update the bullet's position
		transform.position = position;

		//this is the top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//if the bullet went outside the screen on the right, then destory the bullet
		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.CompareTag("Enemy")) {
			Destroy (gameObject);
		}
	}
}
