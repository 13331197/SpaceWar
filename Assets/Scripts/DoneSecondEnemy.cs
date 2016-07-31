using UnityEngine;
using System.Collections;

public class DoneSecondEnemy : MonoBehaviour
{
	private Transform[] path;
	private GameObject player;
	private float posX, posY, posZ;
	private bool IsFinsh;
	private DoneWayPoint wayPoint;
	private int Timer = 0;
	public Object EnemyBulletObj;
	private float ShootTime = 0.0f;
	private float freeShootTime = 0.7f;

	void Awake ()
	{
		player = GameObject.FindWithTag ("Player");
		wayPoint = GameObject.Find ("WayPoint1").GetComponent<DoneWayPoint> ();
		InvokeRepeating ("TimeAdd", 0, 1);
	}
	// Use this for initialization
	void Start ()
	{
		path = new Transform[7];
		path [0] = GameObject.Find ("Point7").transform;
		path [1] = GameObject.Find ("Point6").transform;
		path [2] = GameObject.Find ("Point5").transform;
		path [3] = GameObject.Find ("Point4").transform;
		path [4] = GameObject.Find ("Point3").transform;
		path [5] = GameObject.Find ("Point2").transform;
		path [6] = GameObject.Find ("Point1").transform;
		tween ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Quaternion quat = Quaternion.Euler (new Vector3 (-90, 0, 0));
		ShootTime += Time.deltaTime;
		if (ShootTime > freeShootTime) {	
			Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z-transform.localScale.y/2);
			Instantiate (EnemyBulletObj, pos, quat);
			ShootTime = 0.0f;
		}
		if (IsFinsh) {
			if (Timer > 1) {
				this.GetComponent<TrailRenderer> ().enabled = true;
				Timer = 0;
				IsFinsh = false;
			}
			tween ();	
		}
	}

	void OnDrawGizmos ()
	{
		iTween.DrawPath (path);
	}

	void tween ()
	{
		
		iTween.MoveTo (gameObject, iTween.Hash ("path", path, "time", 20, "orienttopath", true, "looktime", .6, "easetype", "easeInOutSine", "oncomplete", "Reset"));
	}

	void Reset ()
	{
		this.GetComponent<TrailRenderer> ().enabled = false;
		float x1 = player.transform.position.x - 25.0f;
		float x2 = player.transform.position.x + 25.0f;
		float y1 = player.transform.position.y;
		float y2 = player.transform.position.y + 25.0f;
		posX = Random.Range (x1, x2);
		posY = Random.Range (y1, y2);
		posZ = player.transform.position.z + 250.0f;
		transform.position = new Vector3 (posX, posY, posZ);
		wayPoint.InstansWayPos ();
		IsFinsh = true;
	}

	void TimeAdd ()
	{
		if (IsFinsh) {
			Timer++;
		}
	}

}
