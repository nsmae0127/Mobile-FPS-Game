using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public GameObject muteBtn;

	public Sprite muteSprite;
	public Sprite unmuteSprite;

	private Image muteImg;

	// Use this for initialization
	void Start ()
	{
		muteImg = muteBtn.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		ChangeMuteImage ();
	}

	// Function to change the mute image
	void ChangeMuteImage ()
	{
		bool isMute = muteBtn.GetComponent<AudioToggle> ().IsMute;
		AudioSource audioSrc = GetComponent<AudioSource> ();

		if (isMute) {
			muteImg.sprite = muteSprite;
			audioSrc.mute = true;
		} else {
			muteImg.sprite = unmuteSprite;
			audioSrc.mute = false;
		}
	}

	public void StartGame (string level)
	{
		Application.LoadLevel (level);
	}

	public void QuitGame ()
	{
		print ("Quit game...");
		Application.Quit ();
	}
}
