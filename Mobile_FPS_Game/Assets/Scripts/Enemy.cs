using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	[SerializeField]private float speed;

	// Use this for initialization
	void Start ()
	{
	
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
}
