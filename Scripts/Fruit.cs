using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {

	// Update is called once per frame
	public float bottomY = -20f;
	void Update () {
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);

			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
			apScript.fruitDestroyed ();
		}
	}
}
