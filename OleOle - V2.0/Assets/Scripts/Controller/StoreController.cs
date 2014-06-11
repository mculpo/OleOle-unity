using UnityEngine;
using System.Collections;

public class StoreController : AnimatorController
{
	void OnEnable()
	{
		StoreInterface.backAnimation += backAnimation;
	}
	
	void OnDisable()
	{
		StoreInterface.backAnimation -= backAnimation;
	}
	
	void backAnimation (string obj)
	{
		this.nameScene = obj;
		anim.SetTrigger("Menu");
	}

	void goToSceneStore()
	{
		CreateController.shareCreate().createScene(this.nameScene);
		Destroy(this.gameObject);
	}
}
