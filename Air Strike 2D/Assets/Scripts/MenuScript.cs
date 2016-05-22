using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
  private bool MusicOn;
  private bool SoundOn;
  
  void Start()
  {
    MusicOn = AppData.IsMusicOn;
    SoundOn = AppData.IsSoundEffectsOn;
  }
  void OnGUI()
  {
    const int buttonWidth = 84;
    const int buttonHeight = 35;

    // Determine the button's place on screen
    // Center in X, 2/3 of the height in Y
    Rect buttonRect = new Rect(
          Screen.width / 2 - buttonWidth*(5/4),
          (2 * Screen.height / 3) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        );
    Rect music = new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 3) - (buttonHeight / 2) + buttonHeight,
          buttonWidth,
          buttonHeight
        );
    Rect sound = new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 3) - (buttonHeight / 2) + 2*buttonHeight,
          buttonWidth,
          buttonHeight
        );
    Rect score = new Rect(
          Screen.width / 2 - (buttonWidth / 2),
          (2 * Screen.height / 3) - (buttonHeight / 2) + 3*buttonHeight,
          buttonWidth,
          buttonHeight
        );
    Rect exit = new Rect(
          Screen.width / 2 + buttonWidth*(1/4),
          (2 * Screen.height / 3) - (buttonHeight / 2),
          buttonWidth,
          buttonHeight
        );
    //  MusicOn = AppData.IsMusicOn;
    //  SoundOn = AppData.IsSoundEffectsOn;
    // Draw a button to start the game
    if(GUI.Button(buttonRect,"Start!"))
    {
      // On Click, load the first level.
      // "Stage1" is the name of the first scene we created.
      AppData.IsMusicOn = MusicOn;
      AppData.IsSoundEffectsOn = SoundOn;
      AppData.CurrentScore = 0;
      AppData.shootType = AppData.ShootType.One;
      Application.LoadLevel("Stage1");
    }
    
    MusicOn = GUI.Toggle(music,MusicOn,"Music ");
    SoundOn =  GUI.Toggle(sound,SoundOn,"Sound ");
    GUI.Label(score,"Best Score "+AppData.Achievment);
    if(GUI.Button(exit,"Quit"))
    {
      Application.Quit();
    }
  }
}