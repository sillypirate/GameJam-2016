using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	PlayerMover playerMover;
	GameController gameController;
	public GameObject jumpRandomizer;
	public GameObject hurtRandomizer;

	// Use this for initialization
	void Start () {
		playerMover = this.gameObject.GetComponent<PlayerMover> ();
		gameController = FindObjectOfType<GameController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playJumpSound() {

	}
}
