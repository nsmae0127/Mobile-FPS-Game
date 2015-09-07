using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour
{
	Text scoreText;

	int score;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			UpdateScoreText ();
		}
	}

	// Use this for initialization
	void Start ()
	{
		scoreText = GetComponent<Text> ();
	}
	
	// Function to update the score text UI
	void UpdateScoreText ()
	{
		string scoreStr = string.Format ("{0} pt", score);
		scoreText.text = scoreStr;
	}
}
