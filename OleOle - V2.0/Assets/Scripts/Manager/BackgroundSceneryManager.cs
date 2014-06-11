using UnityEngine;
using System.Collections;

public class BackgroundSceneryManager : SceneryManager {

	public LayerSceneryListener prefab;

	public override void instanciateScenery(ObjectMovement objectMovement){

		if(prefab != null){
			
			LayerSceneryListener _object = InstanceController.createObject(prefab, position) as LayerSceneryListener;
			
			_object.sceneryManager = this;

			_object.objectMovement.movement(objectMovement.direction, objectMovement.speed);

			_object.objectMovement.LastSpeed = objectMovement.LastSpeed;
			
		}

	}

}