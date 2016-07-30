using UnityEngine;
using System.Collections;

public class DoneProgressBar : MonoBehaviour
{
	public UISlider uiSlider;

	void Awake ()
	{
		uiSlider = GetComponent<UISlider> ();
	}

	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		uiSlider.sliderValue = DoneGameManager.Instance ().PlayersliderValue;
	}
}
