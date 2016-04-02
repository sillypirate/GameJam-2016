// Brian Miller

using UnityEngine;
using System.Collections;

public class EnemyDestroy : MonoBehaviour {

	// Destroy Enemy Object
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Enemy")
		{
			Destroy (col.gameObject);
		}
	}
}