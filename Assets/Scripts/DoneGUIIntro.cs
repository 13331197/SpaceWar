using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneGUIIntro : MonoBehaviour {

	void OnClick(){
		//Application.LoadLevel(1);
		SceneManager.LoadScene("Scene/HelpScene");
	}
}
