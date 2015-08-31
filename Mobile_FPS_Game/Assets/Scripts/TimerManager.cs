using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerManager : MonoBehaviour
{
	Text timer;
	//UI text that is a game time

	int startTime = 0;
	float currentTime;

	// Use this for initialization
	void Start ()
	{
		timer = GetComponent<Text> ();

		timer.text = null; //initalize the text null
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Calcurate a current time
		currentTime += startTime + Time.deltaTime;

//		print ((int)currentTime);

		//Current time convert to MMSS format
		string mmss = TimeToMMSS (currentTime);

		timer.text = mmss;
	}

	string TimeToMMSS (float currentTime)
	{
		int minutes = ((int)currentTime % 3600) / 60;
		int seconds = ((int)currentTime % 3600) % 60; 

		string mmss = string.Format ("{0}:{1}", minutes, seconds);

//		print (mmss);

		return mmss;
	}
}
