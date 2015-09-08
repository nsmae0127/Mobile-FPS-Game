using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	// The fastest the player can travel in the x axis.
	private float maxSpeed = 10f;

	// Amount of force added when the player jumps.
	private float jumpForce = 300f;

	// Whether or not the player is jumping.
	private bool isJumping;

	private Rigidbody2D playerRigid;

	void Start ()
	{
		playerRigid = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		Move ();
	}

	private void Move ()
	{
		float direction = Input.GetAxis ("Horizontal") * maxSpeed;

		playerRigid.velocity = new Vector2 (direction, playerRigid.velocity.y);

		if (Input.GetKeyDown (KeyCode.W) && isJumping == false) {
			playerRigid.AddForce (Vector2.up * jumpForce);
			print (jumpForce);
		}

		isJumping = true;
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			isJumping = false;
		}
	}
}