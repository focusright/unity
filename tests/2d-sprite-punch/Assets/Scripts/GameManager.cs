using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	// The score that the player currently has
	[HideInInspector]
	public int curScore; 
	// The highest score the player has reached (saved)
	private int highscore;
	// Reference to our custom gui skin
	public GUISkin skin;
	// Values defining the width and height of our game over screen
	public Vector2 losePromptWH;
	// Boolean to check if we need to end the game or not
	[HideInInspector]
	public bool showGameOver;

	void Start () {
		// Grab the last saved highscore from the player prefs file
		highscore = PlayerPrefs.GetInt("Highscore");
	}

	void Update () {
		// If the bird died and our current score is greater than our saved highscore
		if (showGameOver && curScore > highscore)
		{
			// Set the highscore to our current score
			highscore = curScore;
			// Now save the score as our new highscore
			PlayerPrefs.SetInt("Highscore", highscore);
		}
	}

	void OnGUI()
	{
		// Set the GUI's skin to our custom skin
		GUI.skin = skin;
		// Show our current score value at the top center of the screen 
		// (note: it uses the custom Score style in our skin)
		GUI.Label (new Rect(Screen.width/2 - 100,10f,200,200), curScore.ToString(), skin.GetStyle("Score"));

		// If the bird died, show the game over screen
		if (showGameOver)
		{
			// Define the screen space for the game over window
			Rect currentGameOver = new Rect(Screen.width/2 - (losePromptWH.x/2), Screen.height/2 - (losePromptWH.y/2), losePromptWH.x, losePromptWH.y);
			// Generate a box based on the game over window rectangle
			GUI.Box (currentGameOver, "Game Over", skin.GetStyle("Game Over"));
			// Draw our current score within the game over window
			GUI.Label(new Rect(currentGameOver.x + 15f, currentGameOver.y + 50f, currentGameOver.width * .5f, currentGameOver.height * .25f), "Score: " + curScore.ToString());
			// Draw our highscore within the game over window (if the highscore was beaten, it will show your current score)
			GUI.Label(new Rect(currentGameOver.x + 15f, currentGameOver.y + 70f, currentGameOver.width * .5f, currentGameOver.height * .25f), "High score: " + highscore.ToString());
			// Draw a replay button on screen and check to see if it was clicked
			if (GUI.Button (new Rect(currentGameOver.x + (currentGameOver.width - 150), currentGameOver.y + (currentGameOver.height - 80), 130, 60), "", skin.GetStyle("Play")))
			{
				// If it is clicked, reload the level
				Application.LoadLevel("Level");
				// Load the highscore from our save file
				highscore = PlayerPrefs.GetInt("Highscore");
			}
		}
	}
}
