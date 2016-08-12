using UnityEngine;
using System.Collections;
using System;

public class gameovermanager : MonoBehaviour {

	public GameObject loadingImage;

	void Start()
	{
	}


	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
	}
	
	}
