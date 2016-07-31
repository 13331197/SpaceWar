using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneGUIBack : MonoBehaviour {

	void OnClick(){
		//Application.LoadLevel(1);
		SceneManager.LoadScene("Scene/StartScene");
	}
}
