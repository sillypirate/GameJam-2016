using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

	public bool player;
	public Rigidbody rb;
	public GameObject self;
	public GameObject other;
	public bool top;
	public GameObject deathParticle;
	public bool sliding;
	public float slideTime;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		BoxCollider selfB = self.GetComponent<BoxCollider>();


		if (Input.GetKeyDown (KeyCode.W)) {
			rb.AddForce (transform.up*500);
			sliding = false;
			slideTime = 0;
		}
			

		if (sliding) {
			selfB.size = new Vector3 (1, 0.5f, 1);
			slideTime -= Time.deltaTime;
		} else {
			selfB.size = new Vector3 (1, 1f, 1);
		}

		if (slideTime <= 0) {
			sliding = false;
		}

		if (Input.GetKeyDown (KeyCode.D)){
			slideTime = 0;
		}

		if (Input.GetKeyDown (KeyCode.S) && !sliding) {
			sliding = true;
			slideTime = 1f;
		}

			
			

		//if (this.gameObject.transform.position.x >= 10) {
		//	self.transform.position = new Vector2 (-9.5f, this.gameObject.transform.position.y);
		//}

	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Spawn Trigger"){
			if (top) {
				Destroy (col.gameObject);
				GameObject.Find ("Game Manager").GetComponent<GameController> ().newSpawn ();
			}
		}

		if (col.gameObject.tag == "Enemy") {
			if (GameController.dashing) {
				Destroy (col.gameObject);
			} else {
				youLose ();
			}
		}
	}

	void youLose(){
		Instantiate (deathParticle, self.transform.position, Quaternion.identity);
		GameController.gameOver = true;
		Destroy (self);
	}
}
