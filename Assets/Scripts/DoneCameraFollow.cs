using UnityEngine;
using System.Collections;

public class DoneCameraFollow : MonoBehaviour 
{
	// Camera follow target
	public Transform target;
	public float time = 0.8f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Plugins itween moveupdate method
	    iTween.MoveUpdate(gameObject,new Vector3(target.transform.position.x,target.transform.position.y+6,target.transform.position.z-23),time);
	}
}
