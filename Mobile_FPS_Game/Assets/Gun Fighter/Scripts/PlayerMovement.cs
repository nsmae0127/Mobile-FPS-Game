using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D playerRigid;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D playerCol;

	void Start ()
	{
		playerRigid = GetComponent<Rigidbody2D> ();

		playerCol = GetComponent<Collider2D> ();
	}
	
	void Update ()
	{
		grounded = Physics2D.IsTouchingLayers (playerCol, whatIsGround);

		if (Input.GetKey (KeyCode.D)) {
			playerRigid.velocity = new Vector2 (moveSpeed, playerRigid.velocity.y);
		}

		if (Input.GetKey (KeyCode.A)) {
			playerRigid.velocity = new Vector2 (-moveSpeed, playerRigid.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				playerRigid.velocity = new Vector2 (playerRigid.velocity.x, jumpForce);
			}
		}
	}
}