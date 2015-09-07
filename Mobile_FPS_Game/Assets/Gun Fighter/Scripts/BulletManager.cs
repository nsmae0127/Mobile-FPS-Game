using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject bulletPosition;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			//instantiate the bullet
			GameObject bullet = (GameObject)Instantiate (bulletPrefab);
			bullet.transform.position = bulletPosition.transform.position;
		}
	}
}