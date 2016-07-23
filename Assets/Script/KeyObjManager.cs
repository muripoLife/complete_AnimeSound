using UnityEngine;
using System.Collections;

public class KeyObjManager : MonoBehaviour {
	
	[SerializeField] GameObject wakuObj = null;

	[SerializeField] KeyObj[] KeyObjOriginal = null;
	KeyObj[] KeyObjDatas;

	float timer = 0;
	float maxTimer = 1;

	static KeyObjManager instance;

	void Start () {
		instance = this;
		KeyObjDatas = new KeyObj[40];
	}

	void Update()
	{
		if(GameOver.GameOverFlag)
		{
			return;
		}

		timer += Time.deltaTime;
		if(timer >=  maxTimer)
		{
			maxTimer = Random.Range(1.15f, 2.02f);
			timer = 0;

			KeyObj obj = (KeyObj)Instantiate(KeyObjOriginal [ Random.Range(0,KeyObjOriginal.Length) ] );
			obj.transform.parent = transform;

			clearnObj();

			for(int i = 0; i < KeyObjDatas.Length; i++)
			{
				if(KeyObjDatas[i] == null)
				{
					KeyObjDatas[i] = obj;
					break;
				}
			}
		}
	}

	public static KeyObjManager GetInstance()
	{
		return instance;
	}

	public void NearKeyOK(string key)
	{
		float distanceMin = 90f;
		int nearIndex = -1;
		bool touchOk = false;
		bool Great = false;

		for(int i = 0; i < KeyObjDatas.Length; i++)
		{
			if(KeyObjDatas[i] == null ||
				KeyObjDatas[i].gameObject.activeSelf == false)
			{
				continue;
			}

			Vector2 point = wakuObj.transform.position;

			point.y = 0;
			Vector2 point2 = KeyObjDatas[i].transform.position;
			point2.y = 0;
			float distanceData = Vector2.Distance(point, point2);
			if(distanceData <= distanceMin)
			{
				nearIndex = i;
				distanceMin = distanceData;

				touchOk = true;

				if(distanceMin <= 10.01f)
				{
					Great = true;
				}
			}
		}

		if(touchOk)
		{
			if(KeyObjDatas[nearIndex].gameObject.tag == key)
			{
				Destroy(KeyObjDatas[nearIndex].gameObject);

				if(Great)
				{
					ActionManager.GetInstance().OKActiocn(2, key);
				} else
				{
					ActionManager.GetInstance().OKActiocn(1, key);
				}
			}
		} else
		{
			ActionManager.GetInstance().OKActiocn(0, key);
		}

		return;
	}

	void clearnObj()
	{
		for(int i = 0; i < KeyObjDatas.Length; i++)
		{
			if(KeyObjDatas[i] == null ||
				KeyObjDatas[i].gameObject.activeSelf == false)
			{
				KeyObjDatas[i] = null;
				continue;
			}
		}
	}
}