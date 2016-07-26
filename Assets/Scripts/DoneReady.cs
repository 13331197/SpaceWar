using UnityEngine;
using System.Collections;

public class DoneReady : MonoBehaviour
{
	public GUIText readyText;
	void Awake ()
	{
		StartCoroutine (ReadyGo ());
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator ReadyGo ()
	{
		// When game starts, play readygo audioclip effect and update view label synchronously
		readyText.material.color = Color.green;
		readyText.text = "READY!";
		yield return new WaitForSeconds(1.5f);
		readyText.text = "GO!";
		yield return new WaitForSeconds(1.5f);
		Destroy (readyText);
	}
}
