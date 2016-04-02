using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {

	public void buttonYes(){
		GameController.gameOver = false;
		SceneManager.LoadSceneAsync ("MainLevel");
	}

	public void buttonNo(){
		//TODO
	}
}
