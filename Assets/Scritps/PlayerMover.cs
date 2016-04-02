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
	public bool onGround;
	public float lastY;
	public GameObject runAnim;
	public GameObject jumpAnim;
	public GameObject dashAnim;
	public GameObject slideAnim;
	public GameObject guardAnim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		BoxCollider selfB = self.GetComponent<BoxCollider>();


		if (Input.GetKeyDown (KeyCode.W) && onGround) {
			rb.AddForce (transform.up*500);
			sliding = false;
			slideTime = 0;
		}

		if (GameController.dashing) {
			runAnim.SetActive (false);
			jumpAnim.SetActive (false);
			dashAnim.SetActive (true);
			slideAnim.SetActive (false);
			guardAnim.SetActive (false);
		} else if (GameController.guarding){
			runAnim.SetActive (false);
			jumpAnim.SetActive (false);
			dashAnim.SetActive (false);
			slideAnim.SetActive (false);
			guardAnim.SetActive (true);
		} else if (sliding){
			runAnim.SetActive (false);
			jumpAnim.SetActive (false);
			dashAnim.SetActive (false);
			slideAnim.SetActive (true);
			guardAnim.SetActive (false);
		} else if (onGround) {
			runAnim.SetActive (true);
			jumpAnim.SetActive (false);
			dashAnim.SetActive (false);
			slideAnim.SetActive (false);
			guardAnim.SetActive (false);
		} else {
			runAnim.SetActive (false);
			jumpAnim.SetActive (true);
			dashAnim.SetActive (false);
			slideAnim.SetActive (false);
			guardAnim.SetActive (false);
		}


		if (sliding) {
			selfB.size = new Vector3 (.8f, 0.5f, 1);
			slideTime -= Time.deltaTime;
		} else {
			selfB.size = new Vector3 (.8f, 1f, 1);
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
		/*if (self.transform.position.y == lastY) {
			onGround = true;
		} else {
			onGround = false;
		}
		lastY = self.transform.position.y;*/


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

		if (col.gameObject.tag == "Hazard") {
			youLose ();
		}
	}

	void OnCollisionEnter (Collision coll){
		if (coll.gameObject.tag == "Platform") {
			onGround = true;
		} 
	}

	void OnCollisionExit (Collision coll){
		if (coll.gameObject.tag == "Platform") {
			onGround = false;
		} 
	}

	void OnCollisionStay (Collision coll){
		if (coll.gameObject.tag == "Platform") {
			onGround = true;
		} 
	}

	void youLose(){
		Instantiate (deathParticle, self.transform.position, Quaternion.identity);
		GameController.gameOver = true;
		Destroy (self);
	}
}
