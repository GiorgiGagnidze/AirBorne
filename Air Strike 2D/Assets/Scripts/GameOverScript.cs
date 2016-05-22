using UnityEngine;

/// <summary>
/// Start or quit the game
/// </summary>
public class GameOverScript : MonoBehaviour
{
  void OnGUI()
  {
    const int buttonWidth = 100;
    const int buttonHeight = 45;
    GUI.color = Color.red;
    if (
      GUI.Button(
        // Center in X, 1/3 of the height in Y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (1 * Screen.height / 5) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Retry!"
      )
    )
    {
      // Reload the level
      AppData.CurrentScore = 0;
      AppData.shootType = AppData.ShootType.One;
      Time.timeScale = 1;
      Application.LoadLevel("Stage1");
    }

    if (
      GUI.Button(
        // Center in X, 2/3 of the height in Y
        new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 5) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),
        "Back to menu"
      )
    )
    {
      // Reload the level
      AppData.CurrentScore = 0;
      Time.timeScale = 1;
      Application.LoadLevel("Menu");
    }
    GUI.Label(new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (3 * Screen.height / 5) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        ),"Best Score "+AppData.Achievment);
  }
}

