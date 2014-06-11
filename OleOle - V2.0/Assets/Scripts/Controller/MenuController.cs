using UnityEngine;
using System.Collections;

public class MenuController : AnimatorController 
{
	void OnEnable()
	{
		MenuInterface.backAnimation += backAnimation;
	}

	void OnDisable()
	{
		MenuInterface.backAnimation -= backAnimation;
	}

	void backAnimation (string obj)
	{
		this.nameScene = obj;
		anim.SetTrigger("Menu");
	}
	
	void goToSceneMenu()
	{
		CreateController.shareCreate().createScene(this.nameScene);
		Destroy(this.gameObject);
	}
}
