using UnityEngine;
using System.Collections;

public class LayerSceneryListener : SceneryListener {

	public SceneryManager sceneryManager;

	public ObjectMovement objectMovement;

	protected override void onBecameVisible(){

		sceneryManager.instanciateScenery(objectMovement);

	}

	protected override void onBecameInvisible(){

		Destroy(gameObject);

	}

}