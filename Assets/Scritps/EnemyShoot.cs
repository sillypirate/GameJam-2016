using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public GameObject idle;
	public GameObject shooting;
	public GameObject projectile;
	public float attackTimer;
	public bool attackChance;
	public float attacking;

	// Use this for initialization
	void Start () {
		attackTimer = 2.5f;
		int pickNum = Random.Range (1, 4);
		if (pickNum == 1) {
			attackChance = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		attackTimer -= Time.deltaTime;
		if (attackTimer < 0 && attackChance) {
			attacking = 0.27f;
			Instantiate (projectile, new Vector3(this.gameObject.transform.position.x-.03f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);

			attackChance = false;
		}

		if (attacking > 0) {
			shooting.SetActive (true);
			idle.SetActive (false);
			attacking -= Time.deltaTime;
		} else {
			shooting.SetActive (false);
			idle.SetActive (true);
		}
	}
}
