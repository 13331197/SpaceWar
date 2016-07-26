using UnityEngine;
using System.Collections;

public class DoneGameManager : MonoBehaviour {
	public static DoneGameManager gm;

	public static DoneGameManager Instance () {
		if (gm) {
			return gm;
		} else {
			GameObject gameObj = new GameObject ();
			gameObj.name = "GameManager";
			gm = gameObj.AddComponent<DoneGameManager> ();
			return gm;
		}
	}

	void Awake ()
	{
		if (!gm) {
			gm = this;
		}
	}

	// Game judgement properties
	public float injuredTime = 3f; // init injuredtime, the time interval which player can not be injured again
	private bool hited = false;
	private bool playerIsAlive = true;
	private bool enemyIsAlive = true;
	private int playerLife = 3; // init player lifes to 3
	private int playerHealth;
	private int playerCurrentHealth;
	private int playerGrade;
	private float playersliderValue;
	private bool isHaveBulletProp;
	private bool isWin;
	private int enemyHealth = 1000; // init boss health to 1000
	private bool enemyIsFinsh;
	private bool isStart = true;
	public bool Hited {
		get {
			return this.hited;
		} set {
			hited = value;
			// When player is hited, it blink for a while if there are still lifes left, set bullet numebers state
			// to origin
			if (hited == true) {
				DoneGameManager.Instance ().IsHaveBulletProp = false;
				CancelInvoke ("CloseBlink");
				Invoke ("CloseBlink", injuredTime);
			}
		}
	}

	public bool IsAlive {
		get {
			return this.playerIsAlive;
		} set {
			playerIsAlive = value;
		}
	}

	public bool EnemyIsAlive {
		get {
			return this.enemyIsAlive;
		} set {
			enemyIsAlive = value;
		}
	}

	public int PlayerLife {
		get {
			return this.playerLife;
		} set {
			playerLife = value;
		}
	}

	public int PlayerHealth {
		get {
			return this.playerHealth;
		} set {
			playerHealth = value;
		}
	}

	public int PlayerGrade {
		get {
			return this.playerGrade;
		} set {
			playerGrade = value;
		}
	}

	public int PlayerCurrentHealth {
		get {
			return this.playerCurrentHealth;
		} set {
			playerCurrentHealth = value;
		}
	}

	public float PlayersliderValue {
		get {
			return this.playersliderValue;
		} set {
			playersliderValue = value;
		}
	}

	public bool IsHaveBulletProp {
		get {
			return this.isHaveBulletProp;
		} set {
			isHaveBulletProp = value;
		}
	}

	public bool IsWin {
		get {
			return this.isWin;
		} set {
			isWin = value;
		}
	}

	public int EnemyHealth {
		get {
			return this.enemyHealth;
		} set {
			enemyHealth = value;
		}
	}

	public bool EnemyIsFinsh {
		get {
			return this.enemyIsFinsh;
		} set {
			enemyIsFinsh = value;
		}
	}
		public bool IsStart {
		get {
			return this.isStart;
		} set {
			isStart = value;
		}
	}
	void CloseBlink () {
		hited = false;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
