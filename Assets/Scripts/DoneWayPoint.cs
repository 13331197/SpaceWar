using UnityEngine;
using System.Collections;

public class DoneWayPoint : MonoBehaviour
{
	private float posX, posY, posZ;
	private GameObject player;

	void Awake ()
	{
		player = GameObject.FindWithTag ("Player");
	}
	// Use this for initialization
	void Start ()
	{
		InstansWayPos ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void InstansWayPos ()
	{
		float x1 = player.transform.position.x - 25.0f;
		float x2 = player.transform.position.x + 25.0f;
		posX = Random.Range (x1, x2);
		posY = player.transform.position.y;
		posZ = player.transform.position.z + 250.0f;
		transform.position = new Vector3 (posX, posY, posZ);
	}
}
