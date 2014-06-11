using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{
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
		if(obj.Equals("PLAY"))
		{
			Director.pauseGame();
			Director.gameOver();
		}
		else if(obj.Equals("REINICIAR"))
		{
			Application.LoadLevel(0);
		}
		else if(obj.Equals("MENU"))
		{
			Application.LoadLevel(0);
		}
		else if(obj.Equals("pause"))
		{
			Director.pauseGame();
		}
	}
}
