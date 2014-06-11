using UnityEngine;
using System.Collections;

public class ObstacleSceneryListener : SceneryListener {

#region events
	public static event System.Action onObstacleBecameVisibleEvent;
#endregion

	protected override void onBecameVisible(){

		onObstacleBecameVisibleEvent();

	}

	protected override void onBecameInvisible(){

		Destroy(gameObject);
		
	}

}