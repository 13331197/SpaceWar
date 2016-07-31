using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneGUIAgain : MonoBehaviour {

	void OnClick(){
		//Application.LoadLevel(0);
		SceneManager.LoadScene("Scene/GamingScene");
	}
}
