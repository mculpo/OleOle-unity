using UnityEngine;
using System.Collections;

public class GroundSceneryManager : SceneryManager {

	public LayerSceneryListener[] fieldPrefabes;

	public LayerSceneryListener bleacherPrefab, 
								 cloakroomPrefab, 
								 inTransactionBleacherPrefab, 
								 outTransactionBleacherPrefab, 
								 inTransactionCloakroomPrefab, 
								 outTransactionCloakroomPrefab;

	private int maxCountChanging,
				countChanging,
				fieldPrefabIndex = 0;

	private bool isNextTransaction;

	void OnEnable () {

		SceneryController.onChangeSceneryEvent += onChangeScenery;

	}

	void OnDisable () {

		SceneryController.onChangeSceneryEvent -= onChangeScenery;
		
	}

	void Start () {
		
		resetCount();
		
	}

	private int getIndex(){
		
		if(countChanging >= maxCountChanging){
			
			resetCount();

			return fieldPrefabIndex == 0 ? 1 : 0;
			
		}
		else{
			
			countChanging++;

			return fieldPrefabIndex;
						
		}
		
	}
	
	private void resetCount(){
		
		maxCountChanging = Random.Range(3, 6);
		countChanging = 0;
		
	}

	private void onChangeScenery(){

		isNextTransaction = true;

	}

	public override void instanciateScenery(ObjectMovement objectMovement){

		if(!isNextTransaction){

			LayerSceneryListener _object = null;
			
			if(SceneryController.CurrentScenery == SceneryType.Field){

				_object = fieldPrefabes[getIndex()];

			}
			else if(SceneryController.CurrentScenery == SceneryType.Bleacher){

				_object = bleacherPrefab;

			}
			else{

				_object = cloakroomPrefab;

			}
			
			if(_object != null){
				
				_object = InstanceController.createObject(_object, position) as LayerSceneryListener;
				
				_object.sceneryManager = this;

				_object.objectMovement.movement(objectMovement.direction, objectMovement.speed);
				
				_object.objectMovement.LastSpeed = objectMovement.LastSpeed;
				
			}

		}
		else{

			isNextTransaction = false;

			instanciateTransactionScenery(objectMovement);

		}
		
	}

	private void instanciateTransactionScenery(ObjectMovement objectMovement){

		LayerSceneryListener _object;
		
		if(SceneryController.CurrentScenery == SceneryType.Field){
			
			if(SceneryController.LastScenery == SceneryType.Bleacher){
				
				_object = outTransactionBleacherPrefab;
				
			}
			else{
				
				_object = outTransactionCloakroomPrefab;
				
			}
			
		}
		else if(SceneryController.CurrentScenery == SceneryType.Bleacher){
			
			_object = inTransactionBleacherPrefab;
			
		}
		else{
			
			_object = inTransactionCloakroomPrefab;
			
		}
		
		if(_object != null){
						
			_object = InstanceController.createObject(_object, position) as LayerSceneryListener;
			
			_object.sceneryManager = this;

			_object.objectMovement.movement(objectMovement.direction, objectMovement.speed);
			
			_object.objectMovement.LastSpeed = objectMovement.LastSpeed;
			
		}

	}

}