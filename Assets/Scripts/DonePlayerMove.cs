using UnityEngine;
using System.Collections;

public class DonePlayerMove : MonoBehaviour
{
	
	public float playerMoveSpeedX;
	public float playerMoveSpeedY;
	public float playerMoveSpeedZ;
	public Object bulletObj;
	public AudioClip shootClip;
	public Object parObj;
	// Fire interval
	private float freezTime = 0.1f;
	// Timer to compare it with freeztime
	private float timer = 0.0f;
	private bool IsHaveProp;
	// Prop effect continuing time
	private float PropTime;

	void Awake ()
	{
		// Player game properties inits
		DoneGameManager.Instance ().PlayerLife = 3;
		DoneGameManager.Instance ().PlayerHealth = 500;
		DoneGameManager.Instance ().PlayerCurrentHealth = 500;
		DoneGameManager.Instance ().PlayerGrade = 0;
		DoneGameManager.Instance ().PlayersliderValue = 1;
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Keyboard input events
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * Time.deltaTime * playerMoveSpeedX);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * Time.deltaTime * playerMoveSpeedX);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.back * Time.deltaTime * playerMoveSpeedY);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.forward * Time.deltaTime * playerMoveSpeedY);
		}
		
		if (Input.GetKey ("space")) {
			if (DoneGameManager.Instance ().IsAlive) {
				timer += Time.deltaTime;
				if (timer > freezTime) {
					Quaternion quat = Quaternion.Euler (new Vector3 (90, 0, 0));
					if (!DoneGameManager.Instance ().IsHaveBulletProp) {
						Vector3 bulletPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + transform.localScale.y / 2);
						Instantiate (bulletObj, bulletPos, quat);
					}
					// If get bullet prop, set bullet numbers from 1 to 3
					else {
						Vector3 bulletPos1 = new Vector3 (transform.position.x - 2, transform.position.y, transform.position.z + transform.localScale.y / 2);
						Instantiate (bulletObj, bulletPos1, quat);
						Vector3 bulletPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + transform.localScale.y / 2);
						Instantiate (bulletObj, bulletPos, quat);
						Vector3 bulletPos2 = new Vector3 (transform.position.x + 2, transform.position.y, transform.position.z + transform.localScale.y / 2);
						Instantiate (bulletObj, bulletPos2, quat);
						// When getting prop, prop timer over, set it to 0 and set bullet numbers from 3 to 1
						PropTime += Time.deltaTime;
						if (PropTime > 4.0f) {
							DoneGameManager.Instance ().IsHaveBulletProp = false;
							PropTime = 0.0f;
						}
					}
					// Play shootclip effect
					AudioSource.PlayClipAtPoint (shootClip, transform.position, 1.0f);
					timer = 0.0f;
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		// When player is hited by BlackHole, directly decrease lifes by 1
		if (other.gameObject.tag == "BlackHole") {
			Vector3 particPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + transform.localScale.y / 2);
			GameObject partic = Instantiate (parObj, particPos, Quaternion.identity)as GameObject;
			Destroy (partic, 1.0f);
			DoneGameManager.Instance ().Hited = true;
			DoneGameManager.Instance ().PlayerLife -= 1;
			DoneGameManager.Instance ().PlayerCurrentHealth = DoneGameManager.Instance ().PlayerHealth = 500;
			DoneGameManager.Instance ().PlayersliderValue = 1.0f;
		}
		// When player is hited by EnemyBullet, directly decrease player blood by 50, update blood slider
		if (other.gameObject.tag == "EnemyBullet") {
			DoneGameManager.Instance ().PlayerHealth -= 50;
			DoneGameManager.Instance ().PlayerCurrentHealth = DoneGameManager.Instance ().PlayerHealth;
			DoneGameManager.Instance ().PlayersliderValue -= 0.1f;
		}
		// When player is hited by Star or Enemy, directly decrease player blood by 150, update blood slider
		if (other.gameObject.tag == "Star" || other.gameObject.tag == "Enemy") {
			Vector3 particPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + transform.localScale.y / 2);
			GameObject partic = Instantiate (parObj, particPos, Quaternion.identity)as GameObject;
			Destroy (partic, 1.0f);
			DoneGameManager.Instance ().PlayerHealth -= 150;
			DoneGameManager.Instance ().PlayerCurrentHealth = DoneGameManager.Instance ().PlayerHealth;
			DoneGameManager.Instance ().PlayersliderValue -= 0.3f;
		}
		// When player is hited by BulletProp, get it and set bullet properties
		if (other.gameObject.tag == "Prop") {
			DoneGameManager.Instance ().IsHaveBulletProp = true;
		}
		// When player is hited by BloodProp, get it and increase blood by 100, update the blood slider
		if (other.gameObject.tag == "Prop1") {
			if (DoneGameManager.Instance ().PlayerCurrentHealth + 100 <= 500) {
				DoneGameManager.Instance ().PlayerCurrentHealth += 100;
				DoneGameManager.Instance ().PlayersliderValue += 0.2f;
			} 
			else 
			{
				DoneGameManager.Instance ().PlayerCurrentHealth = 500;
				DoneGameManager.Instance ().PlayersliderValue = 1.0f;
			}
		}
		// When finished, destroy the hit gameobject
		Destroy (other.gameObject);
	}

	/*void GenerateBullet(int count) {
		
	}*/

}