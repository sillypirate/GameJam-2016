using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Rigidbody topRb;
	public Rigidbody botRb;
	public static bool dashing;
	public static bool guarding;
	public float dashTime;
	public float dashCharge;
	public float guardTime;
	public float guardCharge;
	public GameObject[] platformList;
	public GameObject[] platformsPrefabs;
	public GameObject backgoundScroll;
	public GameObject[] backgroundList;
	public static bool gameOver;
	public GameObject gameOverPanel;
	public float gameOverTimer;
	public float bgSpawnCount;


	// Use this for initialization
	void Start () {
		
		dashCharge = 2;
		platformList[0] =  (GameObject.Find("FirstPlat"));
		platformList[1] =  (GameObject.Find("SecondPlat"));
		gameOverTimer = 3;
		bgSpawnCount = 1;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (dashCharge < .5f) {
			dashCharge += Time.deltaTime;
		}

		if (dashing) {
			dashTime -= Time.deltaTime;
		}

		if (dashTime < 0) {
			dashing = false;
		}

		if (Input.GetKeyDown (KeyCode.D) && !dashing && dashCharge >=.5f) {
			dashing = true;
			dashTime = 0.5f;
			dashCharge = 0;
			guarding = false;
			guardTime = 0;
		}

		if (guardCharge < .5f) {
			guardCharge += Time.deltaTime;
		}

		if (guarding) {
			guardTime -= Time.deltaTime;
		}

		if (guardTime < 0) {
			guarding = false;
		}

		if (Input.GetKeyDown (KeyCode.A) && !dashing && guardCharge >= .5f && !guarding) {
			guarding = true;
			guardTime = 0.5f;
			guardCharge = 0;
		}

		if (gameOver) {
			gameOverTimer -= Time.unscaledDeltaTime;
			if (gameOverTimer <= 0) {
				gameOverPanel.SetActive (true);
			}
		}



	}

	public void newSpawn(){
		Debug.Log ("newSpawn()");
		int randPick = Random.Range (1, 10);
		GameObject platformClone = (Instantiate (platformsPrefabs [randPick], new Vector3 (10.5f, 1.3235f, 0), Quaternion.identity) as GameObject);
		platformList[2] =  (platformClone);
		Destroy (platformList [0]);
		platformList [0] = platformList [1];
		platformList [1] = platformList [2];
		platformList [2] = null;
		if (bgSpawnCount == 2) {
			GameObject backgoundClone = (Instantiate (backgoundScroll, new Vector3 (80f, 4.56356f, -0.53f), Quaternion.identity) as GameObject);
			backgroundList [3] = backgoundClone;
			Destroy (backgroundList[0]);
			backgroundList [0] = backgroundList [1];
			backgroundList [1] = backgroundList [2];
			backgroundList [2] = backgroundList [3];
			backgroundList [3] = null;
			bgSpawnCount = 0;
		}
		bgSpawnCount += 1;

	}

	

}
