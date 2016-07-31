using UnityEngine;
using System.Collections;

public class DoneEarthRotate : MonoBehaviour 
{
	// Earth rotating speed
	public float rotateSpeed;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Earth rotate round the forwatd axis
	    transform.Rotate(Vector3.forward ,rotateSpeed*Time.deltaTime ); 
	}
}
