using UnityEngine;
using System.Collections;

public class DoneEffectOfBlink : MonoBehaviour
{
	// Blink continuing time 
	public float blinkTime = 0.2f;
	private float timer = 0.0f;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Blinking ();
	}

	private void Blinking ()
	{
		// When player is hited, life - 1, and blink for a while, during this interval,
		// it can not be injured again 
		if (DoneGameManager.Instance ().Hited) 
		{
			timer += Time.deltaTime;
			if (timer > blinkTime) 
			{
				GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
				timer = 0;
			}
			DoneGameManager.Instance().IsAlive = false;
		} 
		else 
		{
			if (GetComponent<Renderer>().enabled == false) 
			{
				GetComponent<Renderer>().enabled = true;
			}
			DoneGameManager.Instance().IsAlive = true;
		}
	}
}
