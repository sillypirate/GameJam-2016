using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour {

	public bool top;
	public PlayerMover playerMover;
	public AudioSource footstepsSource;

	// Use this for initialization
	void Start () {
		footstepsSource.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!playerMover) {
			GameObject go = null;
			if (top) {
				go = GameObject.Find ("PlayerTop");
			} else {
				go = GameObject.Find ("PlayerBot");
			}
			if (go != null) {
				playerMover = go.GetComponent<PlayerMover> (); 
			}
		}

		if (playerMover) {
			if (playerMover.runAnim.activeInHierarchy && playerMover.onGround) {
				footstepsSource.mute = false;
			} else {
				footstepsSource.mute = true;
			}
		}
	}
}
