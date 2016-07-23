﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int ScorePoint = 0;
	int LifePoint = 3;
	[SerializeField] GUIText gui = null;
	[SerializeField] GUIText guiLife = null;

	static Score instance;

	void Start()
	{
		ScorePoint = 0;
		Time.timeScale = 1.0f;
		instance = this;
	}

	void Update()
	{
		gui.text = "ScorePoint:" + ScorePoint;
		guiLife.text = "Life:" + LifePoint;
		if(GameOver.GameOverFlag)
		{
			Time.timeScale = 1;
			return;
		}
		Time.timeScale = 1.0f + (float)ScorePoint / 100;
	}

	public static Score GetInstance()
	{
		return instance;
	}

	public void LifeDown()
	{
		LifePoint --;
		if (LifePoint <= 0) {
			GameOver.GameOverFlag = true;
		}
	}
}