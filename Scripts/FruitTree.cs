using UnityEngine;
using System.Collections;

public class FruitTree : MonoBehaviour {
	//gets apple object, and sets speed
	public GameObject applePrefab;
	public GameObject orangePrefab;
	public float speed= 1f;
	public float leftAndRightEdge = 10f;
	public float chanceToChangeDirections = 0.1f;
	public float chanceToSpawnOrange = 0.2f;
	public float secondsBetweenDrops = 1f;
	// Use this for initialization
	void Start () {
		//drops apples after start
		InvokeRepeating("DropFruit", 2f, secondsBetweenDrops);
	}
	
	// Update is called once per frame
	void Update () {
		//basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//change direction
		if (pos.x < -leftAndRightEdge)
			speed = Mathf.Abs (speed);
		else if (pos.x > leftAndRightEdge)
			speed = -Mathf.Abs (speed);
		
	}

	void FixedUpdate(){
		if (Random.value < chanceToChangeDirections)
			speed = -speed;
	}

	void DropFruit(){
		GameObject fruit;
		if (Random.value < chanceToSpawnOrange) {
			fruit = Instantiate (orangePrefab) as GameObject;
		}
		else{
			fruit = Instantiate (applePrefab) as GameObject;
		}
		fruit.transform.position = transform.position;
	}
}
