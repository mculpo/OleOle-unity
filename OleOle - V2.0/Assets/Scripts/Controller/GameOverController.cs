using UnityEngine;
using System;
using System.Collections;

public class GameOverController : MonoBehaviour
{
	public static event Action endGameOverEvent; 

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
		if(obj.Equals("Reiniciar"))
		{
			endGameOverEvent();
		}
		else if(obj.Equals("IrMenu"))
		{
			endGameOverEvent();
		}
	}
}
