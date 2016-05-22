using UnityEngine;

public class MusicScript : MonoBehaviour {

	void Awake () {
		AudioSource audio= GetComponent<AudioSource>();
		if (AppData.IsMusicOn)
			audio.Play();
	}
	
}
