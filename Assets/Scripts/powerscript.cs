using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class powerscript : MonoBehaviour {
	public Text theText;

	// Use this for initialization
	void Start () {
		Debug.Log("sample");
	}
	// Update is called once per frame
	void Update () {
	
	} 

	public void buttonpress(int num)
	{
		theText.text = num.ToString();
	}

	public void LoadScene(int level)
	{
		StartCoroutine(gotoscene(level));
		
	}
	IEnumerator gotoscene(int level)
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel(level);
	}
}
