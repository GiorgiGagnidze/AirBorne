using UnityEngine;

public class ScoreHelper : MonoBehaviour {
	private bool isPaused = false;
	
	void OnGUI()
  	{
		const int buttonWidth = 84;
		const int buttonHeight = 35;
	
		// Determine the button's place on screen
		// Center in X, 2/3 of the height in Y
		GUI.color = Color.red;
		Rect buttonRect = new Rect(
			Screen.width / 2 - buttonWidth/2,
			(24 * Screen.height / 25) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect healthRect = new Rect(
			0,
			(24 * Screen.height / 25) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		Rect scoreRect = new Rect(
			buttonWidth,
			(24 * Screen.height / 25) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			);
		
		if (isPaused)
		{
			if(GUI.Button(buttonRect,"Resume"))
			{
				isPaused = false;
				Time.timeScale = 1;
			}
		} else 
		{
			if(GUI.Button(buttonRect,"Pause"))
			{
				isPaused = true;
				Time.timeScale = 0;
			}
		}
		GUI.Label(scoreRect,"Score "+AppData.CurrentScore);
		GUI.Label(healthRect,"Health "+AppData.CurrentHealth);
	}
	
}
