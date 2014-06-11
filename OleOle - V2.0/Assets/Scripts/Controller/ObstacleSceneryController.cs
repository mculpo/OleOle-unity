using UnityEngine;
using System.Collections;

public class ObstacleSceneryController : MonoBehaviour {

	public Object[] fieldObstaclePrefabes, 
				    bleacherObstaclePrefabes, 
				    cloakroomObstaclePrefabes;

	void OnEnable () {

		ObstacleSceneryListener.onObstacleBecameVisibleEvent += instanciateObstacleScenery;

	}

	void OnDisable () {

		ObstacleSceneryListener.onObstacleBecameVisibleEvent -= instanciateObstacleScenery;

	}

	private void instanciateObstacleScenery(){

		Object _object = null;

		if(SceneryController.CurrentScenery == SceneryType.Field){

			_object = fieldObstaclePrefabes[Random.Range(0, fieldObstaclePrefabes.Length)];
			
		}
		else if(SceneryController.CurrentScenery == SceneryType.Bleacher){
			
			_object = bleacherObstaclePrefabes[Random.Range(0, bleacherObstaclePrefabes.Length)];
			
		}
		else{
			
			_object = cloakroomObstaclePrefabes[Random.Range(0, cloakroomObstaclePrefabes.Length)];
			
		}
		
		if(_object != null){

			InstanceController.createObject(_object, transform.position);

		}

	}

}