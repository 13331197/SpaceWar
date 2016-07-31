using UnityEngine;
using System.Collections;

public class DoneThreeEnemy : MonoBehaviour
{

	private Transform[] enemyPath;
	private GameObject player;
	private float posX, posY, posZ;
	private bool IsFinsh;
	private DoneWayPoint wayPoint;
	private int Timer = 0;
	public Object EnemyBulletObj1;
	public Object EnemyBulletObj2;
	public Object EnemyBulletObj3;
	private float ShootTime = 0.0f;
	private float freeShootTime = 1.0f;

	void Awake ()
	{
		player = GameObject.FindWithTag ("Player");
		wayPoint = GameObject.Find ("WayPoint2").GetComponent<DoneWayPoint> ();
		InvokeRepeating ("TimeAdd", 0, 1);
	}
	// Use this for initialization
	void Start ()
	{
		enemyPath = new Transform[7];
		enemyPath [0] = GameObject.Find ("Point2_7").transform;
		enemyPath [1] = GameObject.Find ("Point2_6").transform;
		enemyPath [2] = GameObject.Find ("Point2_5").transform;
		enemyPath [3] = GameObject.Find ("Point2_4").transform;
		enemyPath [4] = GameObject.Find ("Point2_3").transform;
		enemyPath [5] = GameObject.Find ("Point2_2").transform;
		enemyPath [6] = GameObject.Find ("Point2_1").transform;
		tween ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Quaternion quat = Quaternion.Euler (new Vector3 (-90, 0, 0));
		ShootTime += Time.deltaTime;
		if (ShootTime > freeShootTime) {
			GameObject shoot1 = GameObject.FindWithTag("shoot1");
			Vector3 pos1 = new Vector3 (shoot1.transform.position.x, shoot1.transform.position.y, shoot1.transform.position.z - shoot1.transform.localScale.y / 2);
			Instantiate (EnemyBulletObj2, pos1, quat);
			GameObject shoot2 = GameObject.FindWithTag("shoot2");
			Vector3 pos2 = new Vector3 (shoot2.transform.position.x, shoot2.transform.position.y, shoot2.transform.position.z - shoot1.transform.localScale.y / 2);
			Instantiate (EnemyBulletObj1, pos2, quat);
			GameObject shoot3 = GameObject.FindWithTag("shoot3");
			Vector3 pos3 = new Vector3 (shoot3.transform.position.x, shoot3.transform.position.y, shoot3.transform.position.z - shoot3.transform.localScale.y / 2);
			Instantiate (EnemyBulletObj3, pos3, quat);
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

//	void OnDrawGizmos ()
//	{
//		iTween.DrawPath(enemyPath);
//	}

	void tween ()
	{
		
		iTween.MoveTo (gameObject, iTween.Hash ("path", enemyPath, "time", 30, "orienttopath", true, "looktime", .6, "easetype", "easeInOutSine", "oncomplete", "Resetpos"));
	}

	void Resetpos ()
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
