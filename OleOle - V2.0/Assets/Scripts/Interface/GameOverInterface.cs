using UnityEngine;
using System.Collections;

public class GameOverInterface : AnimatorController {

	public TextMesh time,
					coin,
					bestTime,
					totalCoin;

	void Update()
	{
		/// Test Control
		if(Input.GetKeyDown(KeyCode.L))
		{
			onGameOver();
		}
		else if(Input.GetKeyDown(KeyCode.K))
		{
			endGameOverEvent();
		}
	}

	void OnEnable () 
	{

		Director.onGameOverEvent += onGameOver;

		GameOverController.endGameOverEvent += endGameOverEvent;

	}
	
	void OnDisable () 
	{

		Director.onGameOverEvent -= onGameOver;

		GameOverController.endGameOverEvent -= endGameOverEvent;

	}
	
	private void endGameOverEvent ()
	{

		TouchController.layerMask = LayerMask.NameToLayer("Default");

		anim.SetTrigger("Exit");

		Application.LoadLevel(0);
	}

	private void onGameOver()
	{
		TouchController.layerMask = LayerMask.NameToLayer("Layer2");

		this.time.text = "";

		this.coin.text = "";

		this.bestTime.text = "";

		this.totalCoin.text = "";

		anim.SetTrigger("Enter");
	}
}