using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public int highScore = 1000;
	void Awake(){
		if(PlayerPrefs.HasKey("ApplePickerHighScore"))
			highScore = PlayerPrefs.GetInt("ApplePickerHighScore");
		PlayerPrefs.SetInt ("ApplePickerHighScore", highScore);

	}
	// Update is called once per frame
	void Update () {
		Text message = this.GetComponent<Text>();
		message.text = "High Score: " + highScore;
		if (highScore > PlayerPrefs.GetInt ("ApplePickerHighScore"))
			PlayerPrefs.SetInt ("ApplePickerHighScore", highScore);
	}
}
