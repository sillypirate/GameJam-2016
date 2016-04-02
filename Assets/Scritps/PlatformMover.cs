using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {

	public float rate;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (GameController.dashing) {
			rate = 3;
		} else if(GameController.gameOver){ 
			rate = 0;
		} else {
			rate = 1;
		}
			


		this.gameObject.transform.Translate ((Vector2.left / 10) * rate);

	}

	//void OnDestroy(){
	//	GameObject.Find ("Game Manager").GetComponent<GameController> ().platformList.RemoveAt (0);
	//}
}
