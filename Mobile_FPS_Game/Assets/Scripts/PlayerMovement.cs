using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public int speed;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float x = Input.GetAxis ("Horizontal"); //the value will be -1, 0, 1 (for left, no input, and right)

		//Based on the input we compute a direction vector, and we normalize it to get a unit vector
		Vector2 direction = new Vector2 (x, 0).normalized;

		//Call the function that computes and sets the player's position
		Move (direction);
	}

	void Move (Vector2 direction)
	{
		//Find the screen limits to the player's movement (left, right)
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)); //this is the bottom-left point (corner) of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); //tihs is the top-right point (corner) of the screen

		min.x = min.x + 0.4f; //add the player sprite half width
		max.x = max.x - 0.4f; //substract the player sprite half width

		//Get the player's current position
		Vector2 pos = transform.position;

		//Calculate the new position
		pos += speed * direction * Time.deltaTime;

		//Make sure the new position is not outside the screen
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);

		//Update the player's position
		transform.position = pos;
	}
}