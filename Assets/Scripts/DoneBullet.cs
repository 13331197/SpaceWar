using UnityEngine;
using System.Collections;

public class DoneBullet : MonoBehaviour 
{
	// Bullet moving speed
	public float bulletMoveSpeed;
	// Bullet transform
	private Transform myTransform;
	// Particle explosion object when bullet hit something
	public Object preObj;
	// Player gameobject
	private GameObject player;
	// Enemy DoneEnemy script object
	private DoneEnemy enemy;

	void Awake () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	// Use this for initialization
	void Start () 
	{
		myTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float aimMove = bulletMoveSpeed * Time.deltaTime;
		myTransform.Translate (Vector3.up * aimMove);
		// When the distance between bullet and player is beyond 200, bullet destroyed
		if (transform.position.z > player.transform.position.z + 200.0f) 
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other) 
	{
		// Bullet hit enemy with tag "Enemy", destroy both of them and add 100 to grade
		if (other.gameObject.tag == "Enemy") 
		{
			GameObject partic = Instantiate (preObj, other.transform.position, Quaternion.identity)as GameObject;
			Destroy (this.gameObject, 0.1f);
			Destroy (other.gameObject);	
			Destroy (partic, 1.0f);
			DoneGameManager.Instance ().PlayerGrade += 100;
		} 
		// Bullet hit enemy with tag "Star" or "BlackHole", destroy both of them and add 50 to grade
		else if (other.gameObject.tag == "Star" || other.gameObject.tag == "BlackHole") 
		{
			GameObject partic = Instantiate (preObj, other.transform.position, Quaternion.identity)as GameObject;
			Destroy (this.gameObject, 0.1f);
			Destroy (other.gameObject);	
			Destroy (partic, 1.0f);
			DoneGameManager.Instance ().PlayerGrade += 50;
		} 
		// Bullet hit enemy with tag "Boss", health of boss decrease by 50, when decrease it to 0, destroy both of them and
		// add 500 to grade finally game wins
		else if (other.gameObject.tag == "Boss") 
		{
			DoneGameManager.Instance ().EnemyHealth -= 50;
			GameObject partic1 = Instantiate (preObj, other.transform.position, Quaternion.identity)as GameObject;	
			Destroy (partic1, 1.0f);
			Destroy (this.gameObject);
			if (DoneGameManager.Instance ().EnemyHealth <= 0) 
			{
				GameObject partic = Instantiate (preObj, other.transform.position, Quaternion.identity)as GameObject;	
				Destroy (partic, 1.0f);
				Destroy (other.gameObject, 0.1f);
				DoneGameManager.Instance ().PlayerGrade += 500;
				DoneGameManager.Instance ().IsWin = true;
				DoneGameManager.Instance ().IsStart = false;
			}
		}
	}
}
