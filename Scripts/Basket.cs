using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public Text scoreText;

	void Start() {
		// Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("Score");
		scoreText = scoreGO.GetComponent<Text>();
		scoreText.text = "0";
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

	}

	void OnCollisionEnter (Collision coll){
		int score = 0;
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
			score = int.Parse (scoreText.text);
			score += 100;
		} else if (collidedWith.tag == "Orange") {
			Destroy (collidedWith);
			score = int.Parse (scoreText.text);
			score += 200;
		}
		scoreText.text = score.ToString();

		if (score > HighScore.highScore)
			HighScore.highScore = score;

	}
}
