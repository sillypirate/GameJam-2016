using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

	public void buttonYes(){
		SceneManager.LoadScene ("MainLevel");
	}

	public void buttonNo(){
		//TODO
	}
}
