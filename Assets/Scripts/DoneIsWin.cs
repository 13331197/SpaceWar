using UnityEngine;
using System.Collections;

public class DoneIsWin : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Life is still left then decrese it by 1, player blood restores
		if (DoneGameManager.Instance ().PlayerLife > 1 &&
			DoneGameManager.Instance ().PlayerCurrentHealth <= 0) {
				DoneGameManager.Instance ().PlayerLife -= 1;
				DoneGameManager.Instance ().PlayerCurrentHealth = 500;
				DoneGameManager.Instance ().PlayerHealth = 500;
				DoneGameManager.Instance ().PlayersliderValue = 1.0f;
			    DoneGameManager.Instance ().Hited = true;
		}
		// No lifes left, set it to 0, and game over to lose state
		if (DoneGameManager.Instance ().PlayerLife < 1 || (DoneGameManager.Instance ().PlayerCurrentHealth <= 0 
			&& DoneGameManager.Instance ().PlayerLife == 1)) {
			if (DoneGameManager.Instance ().PlayerCurrentHealth <= 0
				&& DoneGameManager.Instance ().PlayerLife == 1)
				DoneGameManager.Instance ().PlayerLife -= 1;
			DoneGameManager.Instance ().PlayerCurrentHealth = DoneGameManager.Instance ().PlayerHealth = 0;
			DoneGameManager.Instance ().PlayersliderValue = 0.0f;
			DoneGameManager.Instance ().IsWin = false;
			DoneGameManager.Instance ().IsStart = false;
		}
		// When boss finishes its way line and is still alive, game over to lose state
		if (DoneGameManager.Instance ().EnemyHealth > 0 && DoneGameManager.Instance ().EnemyIsFinsh) {
			DoneGameManager.Instance ().IsWin = false;
			DoneGameManager.Instance ().IsStart = false;
		}
		// When boss have not finished its way line yet and is injured to death, game over to win state
		if (DoneGameManager.Instance ().EnemyHealth <= 0 && !DoneGameManager.Instance ().EnemyIsFinsh) {
			DoneGameManager.Instance ().IsWin = true;
			DoneGameManager.Instance ().IsStart = false;
		}
	}
}
