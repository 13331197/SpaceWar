using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoneSceneGUI : MonoBehaviour
{   
	public UILabel mytext;
	private Texture2D lifeCountTexture = null;
	// Use this for initialization
	void Start ()
	{
		GameObject lg = GameObject.Find("Label_Grade");
		mytext = lg.GetComponent<UILabel> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}


	public static Vector2 NativeResolution  = new Vector2(547, 410);

	private static float _guiScaleFactor = -1.0f;
	private static Vector3 _offset = Vector3.zero;

	static List<Matrix4x4> stack = new List<Matrix4x4> ();
	public void BeginUIResizing()
	{
		Vector2 nativeSize = NativeResolution;

		//_didResizeUI = true;

		stack.Add (GUI.matrix);
		Matrix4x4 m = new Matrix4x4();
		var w = (float)Screen.width;
		var h = (float)Screen.height;
		var aspect = w / h;
		var offset = Vector3.zero;
		if(aspect < (nativeSize.x/nativeSize.y)) 
		{ 
			//screen is taller
			_guiScaleFactor = (Screen.width/nativeSize.x);
			offset.y += (Screen.height-(nativeSize.y * _guiScaleFactor)) * 0.5f;
		} 
		else 
		{ 
			// screen is wider
			_guiScaleFactor = (Screen.height/nativeSize.y);
			offset.x += (Screen.width-(nativeSize.x * _guiScaleFactor)) * 0.5f;
		}

		m.SetTRS(offset,Quaternion.identity,Vector3.one * _guiScaleFactor);
		GUI.matrix *= m;	
	}

	public void EndUIResizing()
	{
		GUI.matrix = stack[stack.Count - 1];
		stack.RemoveAt (stack.Count - 1);
		//_didResizeUI = false;
	}


	void OnGUI ()
	{
		BeginUIResizing ();
		mytext.text = "Grade: " + DoneGameManager.Instance ().PlayerGrade.ToString ();
		//GUI.Label (new Rect (200, 20, 200, 100), DoneGameManger.Instance ().PlayerGrade.ToString());
		GUI.Label(new Rect (30, 50, 200, 100), DoneGameManager.Instance().PlayerCurrentHealth.ToString() + " / " + 500);
		if (lifeCountTexture == null) {
			lifeCountTexture = (Texture2D)Resources.Load ("Material/Life",typeof(Texture2D));
		}
		if (lifeCountTexture != null) {
			for (int i = 0; i < DoneGameManager.Instance().PlayerLife; ++i) 
			{
				GUI.DrawTexture (new Rect (160 + i * 50, 10, 100, 100), lifeCountTexture, ScaleMode.StretchToFill, true, 0);
			}
		}
		if(Input.GetKeyDown(KeyCode.R))
		{
			Application.CaptureScreenshot(Time.time+".png");
		}
		EndUIResizing();
	}
}
