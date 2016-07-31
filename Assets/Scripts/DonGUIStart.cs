using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DonGUIStart : MonoBehaviour
{
	void OnClick ()
	{
		//Application.LoadLevel (0);
		SceneManager.LoadScene("Scene/GamingScene");
	}
}
