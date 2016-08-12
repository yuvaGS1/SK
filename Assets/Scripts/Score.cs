using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private Text theText;
	// Use this for initialization
	
	void Start () {
		theText = GetComponent<Text>();
		Debug.Log(PlayerPrefs.GetInt ("score"));
	}
	
	// Update is called once per frame
	void Update () {
		theText.text = "" + Mathf.Round (PlayerPrefs.GetInt ("score"));
	}
}
