using UnityEngine;
using System.Collections;

public class PauseInterface : AnimatorController {

	public TextMesh coin,
					time;

	void Update()
	{
		/// Test Control
		if(Input.GetKeyDown(KeyCode.M))
		{
			onPause(true);
		}
		else if(Input.GetKeyDown(KeyCode.N))
		{
			onPause(false);
		}
	}

	void OnEnable ()
	{
		Director.onPauseEvent += onPause;
	}
	
	void OnDisable () 
	{
		Director.onPauseEvent -= onPause;
	}

	private void onPause(bool state)
	{
		if(state)
		{
			TouchController.layerMask = LayerMask.NameToLayer("Layer2");

			//coin.text = "";

			//time.text = "";

			anim.SetTrigger("Enter");
		}
		else if(!state)
		{
			TouchController.layerMask = LayerMask.NameToLayer("Default");

			anim.SetTrigger("Exit");
		}
	}
}