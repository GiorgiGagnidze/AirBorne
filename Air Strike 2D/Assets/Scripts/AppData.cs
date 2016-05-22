using UnityEngine;

public static class AppData {
	public static bool IsMusicOn {get; set;}
	public static bool IsSoundEffectsOn {get; set;}

	public static int CurrentScore {get; set;}
	public static int CurrentHealth {get; set;}
	
	public static ShootType shootType {get; set;}
	private static int achievment;
	public static int Achievment
	{
		get 
		{
			if (achievment == 0)
			{
				if (PlayerPrefs.HasKey(PREFS_ACHIEVMENTS_KEY))
				{
					achievment = PlayerPrefs.GetInt(PREFS_ACHIEVMENTS_KEY);
				} else 
				{
					achievment = 0;
				}
			}
			return achievment;
		}
		set 
		{
			achievment = value;
			PlayerPrefs.SetInt(AppData.PREFS_ACHIEVMENTS_KEY, achievment);
		}
	}
	
	public const string PREFS_ACHIEVMENTS_KEY = "achievmentskey";


	public enum ShootType {
		One,
		Two,
		Three
	}
}