using UnityEngine;
using System.Collections;

public class DoneBossEnemy : MonoBehaviour {

	// Enemy generation position array 
	private Transform[] enemyPath;
	// Enemy bullet object
	public Object EnemyBulletObj;
	// Enemy shoottimer to comparing with freeshoottime
	private float ShootTime = 0.0f;
	// Enemy firing interval
	private float freeShootTime = 1.0f;
	// Enemy walk waypoints
	private DoneWayPoint wayPoint;
	private GameObject wayPointObj;
	void Awake ()
	{
		wayPointObj = GameObject.Find ("WayPoint3");
		wayPoint = wayPointObj.GetComponent<DoneWayPoint> ();
	}
	// Use this for initialization
	void Start ()
	{
		//DoneGameManger.Instance().EnemyHealth = 1000;
		wayPoint.InstansWayPos ();
		transform.position = wayPointObj.transform.position;
		enemyPath = new Transform[7];
		enemyPath [0] = GameObject.Find ("Point3_7").transform;
		enemyPath [1] = GameObject.Find ("Point3_6").transform;
		enemyPath [2] = GameObject.Find ("Point3_5").transform;
		enemyPath [3] = GameObject.Find ("Point3_4").transform;
		enemyPath [4] = GameObject.Find ("Point3_3").transform;
		enemyPath [5] = GameObject.Find ("Point3_2").transform;
		enemyPath [6] = GameObject.Find ("Point3_1").transform;
		tween ();
	}

	// Update is called once per frame
	void Update ()
	{
		Quaternion quat = Quaternion.Euler (new Vector3 (0, 90, 0));
		ShootTime += Time.deltaTime;
		if (ShootTime > freeShootTime) {
			GameObject shoot1 = GameObject.FindWithTag("EnemyShoot1");
			Vector3 pos1 = shoot1.transform.position;
			Instantiate (EnemyBulletObj, pos1, quat);
			GameObject shoot2 = GameObject.FindWithTag("EnemyShoot2");
			Vector3 pos2 = shoot2.transform.position;
			Instantiate (EnemyBulletObj, pos2, quat);
			GameObject shoot3 = GameObject.FindWithTag("EnemyShoot3");
			Vector3 pos3 = shoot3.transform.position;
			Instantiate (EnemyBulletObj, pos3, quat);
			ShootTime = 0.0f;
		}
	}

	//	void OnDrawGizmos ()
	//	{
	//		iTween.DrawPath(enemyPath);
	//	}

	void tween ()
	{
		// Plugins tween moveto method
		iTween.MoveTo (gameObject, iTween.Hash ("path", enemyPath, "time", 100, "orienttopath", true, "looktime", .6, "easetype", "easeInOutSine", "oncomplete", "Resetpos"));
	}
	void Resetpos(){
		// When this boss enemy way line is finished, set finish tag to true for checking game result
		DoneGameManager.Instance().EnemyIsFinsh = true;
		Destroy(this.gameObject);
	}
}
