using UnityEngine;
using System.Collections;

public class DogBehavior : ObstacleSceneryListener {

	public AudioClip dogBarking;

	protected override void onBecameVisible(){		
		base.onBecameVisible();

		Director.Get.playEffect(dogBarking);
		
	}

}