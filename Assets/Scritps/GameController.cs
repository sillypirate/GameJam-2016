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
	public GameObject[] platformList;
	public GameObject[] platformsPrefabs;


	// Use this for initialization
	void Start () {
		
		dashCharge = 2;
		platformList[0] =  (GameObject.Find("FirstPlat"));
		platformList[1] =  (GameObject.Find("SecondPlat"));

	}
	
	// Update is called once per frame
	void Update () {
	
		if (dashCharge < 2) {
			dashCharge += Time.deltaTime;
		}

		if (dashing) {
			dashTime -= Time.deltaTime;
		}

		if (dashTime < 0) {
			dashing = false;
		}

		if (Input.GetKeyDown (KeyCode.D) && !dashing && dashCharge >= 2) {
			dashing = true;
			dashTime = 0.5f;
			dashCharge = 0;
		}

	}

	public void newSpawn(){
		Debug.Log ("newSpawn()");
		int randPick = Random.Range (1, 4);
		GameObject platformClone = (Instantiate (platformsPrefabs [randPick], new Vector3 (10.5f, 1.3235f, 0), Quaternion.identity) as GameObject);
		platformList[2] =  (platformClone);
		Destroy (platformList [0]);
		platformList [0] = platformList [1];
		platformList [1] = platformList [2];
		platformList [2] = null;
	}

	

}
