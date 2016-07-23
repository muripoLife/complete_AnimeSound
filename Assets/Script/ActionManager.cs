using UnityEngine;
using System.Collections;

public class ActionManager : MonoBehaviour {

	static ActionManager instance;
	bool end = false;

	UnityChanMove unityChan;

	void Start()
	{
		instance = this;
		unityChan = GetComponent<UnityChanMove>();
	}

	void Update()
	{
		if(GameOver.GameOverFlag)
		{
			if(end)
			{
				return;
			}
			end = true;
			unityChan.UnityGameOver();
		}
	}

	public static ActionManager GetInstance()
	{
		return instance;
	}

	public void OKActiocn(int Point, string action)
	{
		if(Point == 0)
		{
			Score.GetInstance().LifeDown();
			unityChan.UnityDamageAnime();
			return;
		} else
			if(Point == 1)
			{
				Score.ScorePoint += 10;
			}else
				if(Point == 2)
				{
					Score.ScorePoint += 20;
				}

		switch(action)
		{
		case "Z":
			{
				unityChan.UnityPose(1);
				break;
			}
		case "X":
			{
				unityChan.UnityPose(2);
				break;
			}
		case "C":
			{
				unityChan.UnityPose(3);
				break;
			}
		}
	}
}