using UnityEngine;
using System.Collections;

public class DoneAimPoint : MonoBehaviour 
{
	//  Player gameobject
	private GameObject player;
	//  Raycasthit to check whether exsiting object forward
	private RaycastHit hit;
	//  Aiming Material
	public Material mat;
	//  Not aiming Material
	public Material mat1;
	//  When something is aimed, play audioclip once
	public AudioClip aimClip;
	//  Timer to compare with aimtime
	private float timer = 0.0f;
	//  Time that aim continues
	public float aimTime = 1.0f;

	void Awake () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z + player.transform.localScale.y / 2);
		hit = new RaycastHit ();
		// When raycast hitting, change material, and reset timer
		if (Physics.Raycast (pos, Vector3.forward, out hit) && (hit.transform.gameObject.tag == "Star" || hit.transform.gameObject.tag == "BlackHole" ||
			hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag == "Boss")) 
		{
			this.GetComponent<MeshRenderer> ().material = mat;
			transform.position = hit.point;
			AudioSource.PlayClipAtPoint(aimClip,transform.position);
			timer = 0.0f;
		} 
		else 
		{
			this.GetComponent<MeshRenderer> ().material = mat1;
			timer += Time.deltaTime;
			// When nothing is aimed, change aimpoint to origin position(player forward)
			if(timer > aimTime) 
			{
			    transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + 40.0f);
		    }
		}
	}
}
