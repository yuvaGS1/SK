using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;

	private Text theText;
	
	// Use this for initialization
	void Start () {
		theText = GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (startingTime > 0) {
			startingTime -= Time.deltaTime;
			theText.text = "" + Mathf.Round (startingTime);
		}
		else 
		{
			Application.LoadLevel ("gameoverscene");
		}
	}
}
