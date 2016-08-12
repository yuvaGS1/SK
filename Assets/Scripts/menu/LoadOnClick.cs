using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LoadOnClick : MonoBehaviour {

	public int score;
	public GameObject loading;
	private Text theText;

	void Start()
	{
		GameObject.Find("loading").GetComponent<Text>().text = "Loading . . . ";
		GameObject.Find ("loading").transform.localScale = new Vector3(0, 0, 0);
		PlayerPrefs.SetInt ("score", 0);
	}


	public void LoadScene(int level)
	{
		GameObject.Find ("loading").transform.localScale = new Vector3(1, 1, 1);
		StartCoroutine(gotoscene(level));
	
	}
	IEnumerator gotoscene(int level)
	{
		yield return new WaitForSeconds (3);
		Application.LoadLevel(level);
	}
	
	}
