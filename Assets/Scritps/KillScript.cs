using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {

	public float TTL;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		TTL -= Time.deltaTime;
		if (TTL < 0) {
			Destroy (this.gameObject);
		}

	}
}
