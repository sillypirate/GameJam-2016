using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public bool player;
	public Rigidbody rb;
	public GameObject self;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		self.transform.Translate (Vector2.right / 20);


		if (Input.GetKeyDown (KeyCode.W)) {
			rb.AddForce (transform.up*500);

		}

		if (this.gameObject.transform.position.x >= 10) {
			self.transform.position = new Vector2 (-9.5f, this.gameObject.transform.position.y);
		}

	}
}
