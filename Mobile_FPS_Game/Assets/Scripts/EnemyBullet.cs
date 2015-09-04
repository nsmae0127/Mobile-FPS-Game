using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
	private float speed = 5f;
	private Vector2 direction;
	private bool isReady;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isReady) {
			Vector2 position = transform.position;

			position += direction * speed * Time.deltaTime;

			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

			if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
			    (transform.position.y < min.y) || (transform.position.y > max.y)) {
				Destroy (gameObject);	
			}
		}
	}

	public void SetDirection (Vector2 dir)
	{
		direction = dir.normalized;

		isReady = true;
	}
}
