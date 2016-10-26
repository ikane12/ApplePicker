using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float spacing = 2f;
	public List<GameObject> basketList;
	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for(int i =0; i<numBaskets; i++){
			GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (spacing * i);
			tBasketGO.transform.position = pos;
			basketList.Add (tBasketGO);
		}
	}

	public void fruitDestroyed(){
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		GameObject[] tOrangeArray = GameObject.FindGameObjectsWithTag ("Orange");
		foreach (GameObject tGO in tAppleArray) {
			Destroy (tGO);
		}
		foreach (GameObject tGO in tOrangeArray) {
			Destroy (tGO);
		}
		int basketIndex = basketList.Count - 1;
		GameObject tBasketGO = basketList [basketIndex];
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGO);

		if (basketList.Count == 0)
			Application.LoadLevel ("GameOverScene");
	}
}
