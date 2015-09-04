using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public GameObject playButton;
	public GameObject player;
	public GameObject enemySpawn;
	public GameObject gameOver;

	public enum GameManagerState
	{
		GameStart,
		GamePlay,
		GameOver
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start ()
	{
		GMState = GameManagerState.GameStart;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	// Function to update the game manager state
	void UpdateGameManagerState ()
	{
		switch (GMState) {
		case GameManagerState.GameStart:
			//hide game over
			gameOver.SetActive (false);

			//set play button visible (active)
			playButton.SetActive (true);

			break;
		case GameManagerState.GamePlay:

			//hide play button on game play state
			playButton.SetActive (false);

			//set the player visible (active) and init the player lives
			player.GetComponent<PlayerManager> ().Init ();

			//start enemy spawn
			enemySpawn.GetComponent<EnemySpawn> ().ScheduleEnemySpawn ();

			break;
		case GameManagerState.GameOver:

			//stop enemy spawner
			enemySpawn.GetComponent<EnemySpawn> ().UnscheduleEnemySpawn ();
					
			//display game over
			gameOver.SetActive (true);

			//change game manager state to GameStart state after 8 seconds
			Invoke ("ChangeToGameStartState", 8f);

			break;
		}
	}

	// Function to set the game manager state
	public void SetGameManagerState (GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	// Play button will call this function when the user clicks the button
	public void StartGamePlay ()
	{
		GMState = GameManagerState.GamePlay;
		UpdateGameManagerState ();
	}

	// Function to change game manager state to GameStart state
	public void ChangeToGameStartState ()
	{
		SetGameManagerState (GameManagerState.GameStart);
	}
}
