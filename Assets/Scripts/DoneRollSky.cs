using UnityEngine;
using System.Collections;

public class DoneRollSky : MonoBehaviour
{
	private GameObject cameraObj;

	void Awake ()
	{
		cameraObj = GameObject.FindWithTag ("MainCamera");
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position = new Vector3 (cameraObj.transform.position.x - 3, cameraObj.transform.position.y - 11, cameraObj.transform.position.z + 60);
	}
}
