using UnityEngine;
using System;
using System.Collections;

public class MenuInterface : MonoBehaviour
{
	public static event Action<string> backAnimation;

	private bool onTouch = true;

	void OnEnable()
	{
		TouchController.onTouchEvent += onTouchEvent;
	}

	void OnDisable()
	{
		TouchController.onTouchEvent -= onTouchEvent;
	}

	void onTouchEvent (string obj)
	{
		if(this.onTouch)
		{
			if(obj == "Opcoes")
			{
				//GPGController.showLeaderBoards();
				backAnimation(obj);
			}
			else if(obj == "Shop")
			{

				//SaveScoreController.saveScore(2f);

				//ADSController.instance.StartCoroutine(ADSController.hideBanner());

				backAnimation(obj);
			}
			else if(obj == "Menu")
			{
				//ADSController.instance.StartCoroutine(ADSController.showBanner());

				backAnimation(obj);
			}
			else if(obj == "cred")
			{
				backAnimation(obj);
			}
			else 
			{
				if(TouchController.layerMask == LayerMask.NameToLayer("Deafult"))
				{
					this.onTouch = true;
					//ADSController.instance.StartCoroutine(ADSController.refresh());
				}
			}
		}
	}
}
