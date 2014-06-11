using UnityEngine;
using System;
using System.Collections;

public class WarningCoinInterface : MonoBehaviour
{
	public static event Action buyCoin;

	void OnEnable()
	{
		TouchController.onTouchEvent += onTouchEvent;
	}
	
	void OnDisable()
	{
		TouchController.onTouchEvent -= onTouchEvent;
	}

	void onTouchEvent( string obj )
	{
		if(obj == "Close_Coin")
		{
			TouchController.layerMask = LayerMask.NameToLayer("Layer2");

			Destroy(this.gameObject);
		}
		else if(obj == "Buy_Coin")
		{
			buyCoin();

			Destroy(this.gameObject);
		}
	}
}
