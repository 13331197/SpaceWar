using UnityEngine;
using System.Collections;

public class DoneProp : MonoBehaviour
{
	// Prop moving properties
	public float maxSpeed;
	public float minSpeed;
	private float currentSpeed;
	private float posX, posY, posZ;
	public float maxRotate;
	public float minRotate;
	private float currenRotate;
	private GameObject player;

	void Awake ()
	{
		player = GameObject.FindWithTag ("Player");
	}
	// Use this for initialization
	void Start ()
	{
		InstansSpeedPos ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float aimMove = currentSpeed * Time.deltaTime;
		transform.Translate (Vector3.back * aimMove);
		if (transform.position.z < player.transform.position.z - 10.0f) {
			InstansSpeedPos ();
		}
		float aimRotate = currenRotate * Time.deltaTime;
		transform.Rotate (Vector3.forward* aimRotate);
	}

	public void InstansSpeedPos ()
	{
		currentSpeed = Random.Range (minSpeed, maxSpeed);
		float x1 = player.transform.position.x - 25.0f;
		float x2 = player.transform.position.x + 25.0f;
		float y1 = player.transform.position.y;
		float y2 = player.transform.position.y + 25.0f;
		posX = Random.Range (x1, x2);
		posY = Random.Range (y1, y2);
		posZ = player.transform.position.z + 250.0f;
		transform.position = new Vector3 (posX, posY, posZ);
		currenRotate = Random.Range (minRotate, maxRotate);
	}
}
