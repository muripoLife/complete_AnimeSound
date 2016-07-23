﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeyObj : MonoBehaviour {

	RectTransform im;

	void Start()
	{
		im = GetComponent<RectTransform>();
		Vector3 point = im.position;
		point.x = 900;

		im.position = point;
	}

	void Update()
	{
		Vector3 point = im.position;

		point.x -= Time.deltaTime * 100;

		if(point.x <= -100.6f)
		{
			Score.GetInstance().LifeDown();
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		im.position = point;
	}
}