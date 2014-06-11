using UnityEngine;
using System.Collections;

public class SceneryMovement : ObjectMovement {

	protected override void OnEnable () {
		base.OnEnable();

		PlayerBehavior.stopSceneryEvent += stopScenery;

	}

	protected override void OnDisable () {
		base.OnDisable();

		PlayerBehavior.stopSceneryEvent -= stopScenery;

	}

	private void stopScenery(){
		
		this.locked = true;

	}

}