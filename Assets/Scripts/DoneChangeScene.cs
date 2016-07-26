using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoneChangeScene : MonoBehaviour 
{
	public GUIText text;
	// Avoid invoking repeatly
	bool invokeFlag;

	void Awake () 
	{

	}
	// Use this for initialization
	void Start () 
	{
		text.enabled = false;
		invokeFlag = true;
	}

	// Update is called once per frame
	void Update () 
	{
		// Start coroutine when game over
		if(!DoneGameManager.Instance ().IsStart)
		{
			StartCoroutine (ShowGameResult());
			DoneGameManager.Instance ().IsStart = true;
		}
	}

	// Show game result
	IEnumerator ShowGameResult() 
	{
		if (DoneGameManager.Instance ().IsWin && invokeFlag) 
		{
			invokeFlag = false;
			text.enabled = true;
			text.text = "YOU WIN!";
			text.material.color = Color.red;
			yield return new WaitForSeconds(3.0f);
			text.text = "Final Grade:" + DoneGameManager.Instance().PlayerGrade.ToString();
			yield return new WaitForSeconds(5.0f);
			text.enabled = false;
			//Application.LoadLevel(0);
			// Win! Back to main menu scene
			SceneManager.LoadScene("Scene/StartScene");
		}  
		if (!DoneGameManager.Instance ().IsStart && !DoneGameManager.Instance ().IsWin) 
		{
			text.enabled = true;
			text.text = "YOU LOSE!";
			text.material.color = Color.red;
			yield return new WaitForSeconds(3.0f);
			text.enabled = false;
			//Application.LoadLevel(3);
			// Lose... Try again or Back to main menu scene
			SceneManager.LoadScene("Scene/FailedScene");
		}	
	}
}
