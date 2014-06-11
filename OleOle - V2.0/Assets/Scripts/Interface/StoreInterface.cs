using UnityEngine;
using System;
using System.Collections;

public class StoreInterface : MonoBehaviour
{
	public static event Action<string> backAnimation;

	public static TextMesh coin;

	public Sprite 	LevelUpOn,
					LevelUpOff,
					UtilitsOn,
					UtilitsOff;

	private string thisName = "Level-UP";

	void OnEnable()
	{
		TouchController.onTouchEvent += onTouchEvent;
		WarningCoinInterface.buyCoin += buyCoin;
	}
	
	void OnDisable()
	{
		TouchController.onTouchEvent -= onTouchEvent;
		WarningCoinInterface.buyCoin -= buyCoin;
	}

	void buyCoin ()
	{
		backAnimation("Coins");
	}
	
	void onTouchEvent (string obj)
	{
		if(obj == "Level-UP")
		{
			if(GameObject.Find("Level-UP").GetComponent<SpriteRenderer>().sprite != LevelUpOn)
			{
				this.thisName = obj;

				backAnimation(obj);

				GameObject.Find("Level-UP").GetComponent<SpriteRenderer>().sprite = LevelUpOn;

				GameObject.Find("Utilits").GetComponent<SpriteRenderer>().sprite = UtilitsOff;

			}
		}
		else if(obj == "Utilits")
		{
			if(GameObject.Find("Utilits").GetComponent<SpriteRenderer>().sprite != UtilitsOn)
			{
				this.thisName = obj;

				backAnimation(obj);

				GameObject.Find("Level-UP").GetComponent<SpriteRenderer>().sprite = LevelUpOff;

				GameObject.Find("Utilits").GetComponent<SpriteRenderer>().sprite = UtilitsOn;

			}
		}
		else if(obj == "Coins")
		{
			if(obj != thisName)
			{
				this.thisName = obj;

				backAnimation(obj);

				GameObject.Find("Level-UP").GetComponent<SpriteRenderer>().sprite = LevelUpOff;
				
				GameObject.Find("Utilits").GetComponent<SpriteRenderer>().sprite = UtilitsOff;
			}
		}

		else if(obj == "moedas01")
		{
			StartCoroutine(TouchController.collider.GetComponent<StoreCoinItem>().buyItem());
		}
		else if(obj == "moedas02")
		{
			StartCoroutine(TouchController.collider.GetComponent<StoreCoinItem>().buyItem());
		}
		else if(obj == "moedas03")
		{
			StartCoroutine(TouchController.collider.GetComponent<StoreCoinItem>().buyItem());
		}
		else if(obj == "moedas04")
		{
			StartCoroutine(TouchController.collider.GetComponent<StoreCoinItem>().buyItem());
		}
	}

	public static void updateCoin()
	{
		coin = GameObject.Find("moedasTx").GetComponent<TextMesh>();
		coin.text = WalletController.getValue(ItemsType.coin).ToString();
	}
}
