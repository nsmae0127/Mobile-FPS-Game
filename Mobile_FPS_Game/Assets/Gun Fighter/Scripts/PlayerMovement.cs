using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	// The fastest the player can travel in the x axis.
	[SerializeField]private float maxSpeed = 10f;

	// Amount of force added when the player jumps.
	[SerializeField]private float jumpForce = 300f;

	// Whether or not the player is grounded.
	private bool isGrounded;

	private Rigidbody2D playerRigid;

	void Awake ()
	{
		playerRigid = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		isGrounded = true;

		Move ();
	}

	private void Move ()
	{
		if (isGrounded) {
			playerRigid.velocity = new Vector2 (Input.GetAxis ("Horizontal") * maxSpeed, playerRigid.velocity.y);
		}

		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			isGrounded = false;
			playerRigid.AddForce (new Vector2 (0, jumpForce));
		}
	}

	//	// Use this for initialization
	//	void Start ()
	//	{
	//
	//	}
	//
	//	// Update is called once per frame
	//	void Update ()
	//	{
	//		float x = Input.GetAxis ("Horizontal"); //the value will be -1, 0, 1 (for left, no input, and right)
	//
	//		//Based on the input we compute a direction vector, and we normalize it to get a unit vector
	//		Vector2 direction = new Vector2 (x, 0).normalized;
	//
	//		//Call the function that computes and sets the player's position
	//		Move (direction);
	//
	//		Jump ();
	//	}
	//
	//	void Move (Vector2 direction)
	//	{
	//		//Find the screen limits to the player's movement (left, right)
	//		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)); //this is the bottom-left point (corner) of the screen
	//		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); //tihs is the top-right point (corner) of the screen
	//
	//		min.x = min.x + 0.4f; //add the player sprite half width
	//		max.x = max.x - 0.4f; //substract the player sprite half width
	//
	//		//Get the player's current position
	//		Vector2 pos = transform.position;
	//
	//		//Calculate the new position
	//		pos += maxSpeed * direction * Time.deltaTime;
	//
	//		//Make sure the new position is not outside the screen
	//		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
	//
	//		//Update the player's position
	//		transform.position = pos;
	//	}
	//
	//	void Jump ()
	//	{
	//		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
	//
	//		if (Input.GetKeyDown (KeyCode.Space)) {
	//			// Character jump script
	//			rigid.AddForce (Vector2.up * jumpForce);
	//		}
	//	}
}