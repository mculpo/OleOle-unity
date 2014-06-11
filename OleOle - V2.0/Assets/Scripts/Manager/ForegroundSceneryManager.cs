using UnityEngine;
using System.Collections;

public class ForegroundSceneryManager : SceneryManager {

	public LayerSceneryListener[] prefabesBleacher;

	public LayerSceneryListener prefabField;

	private int maxCountChanging,
				countChanging;

	private bool locked;

	private SceneryType ownSceneryType;

	void OnEnable () {

		TransactionLayerSceneryListener.onStartTransactionSceneryEvent += onStartTransactionScenery;
		TransactionLayerSceneryListener.onBecameVisibleTransactionSceneryEvent += onBecameVisibleTransactionScenery;

	}

	void OnDisable () {

		TransactionLayerSceneryListener.onStartTransactionSceneryEvent -= onStartTransactionScenery;
		TransactionLayerSceneryListener.onBecameVisibleTransactionSceneryEvent -= onBecameVisibleTransactionScenery;

	}

	void Start () {

		ownSceneryType = SceneryType.Field;

		resetCount();

	}

	private bool canChange(){
		
		if(countChanging >= maxCountChanging){
			
			resetCount();
			
			return true;
			
		}
		else{
			
			countChanging++;
			
			return false;
			
		}
		
	}
	
	private void resetCount(){
		
		maxCountChanging = Random.Range(3, 6);
		countChanging = 0;
		
	}

	private void onStartTransactionScenery(){

		locked = true;

		ownSceneryType = SceneryController.CurrentScenery;

	}

	private void onBecameVisibleTransactionScenery(ObjectMovement objectMovement){

		locked = false;

		if(ownSceneryType == SceneryType.Field){

			Invoke("instanciateScenery", 2.5f);

		}
		else{

			instanciateScenery(objectMovement);

		}

	}

	public override void instanciateScenery(ObjectMovement objectMovement){

		if(!locked){
			
			LayerSceneryListener _prefab = null;
			
			if(ownSceneryType == SceneryType.Field){
								
				_prefab = prefabField;
				
			}
			else if(ownSceneryType == SceneryType.Bleacher){
				
				if(!canChange()){
					
					_prefab = prefabesBleacher[0];
					
				}
				else{
					
					_prefab = prefabesBleacher[1];
					
				}
				
			}
			
			if(_prefab != null){
				
				LayerSceneryListener _object = InstanceController.createObject(_prefab, position) as LayerSceneryListener;
				
				_object.sceneryManager = this;

				_object.objectMovement.movement(objectMovement.direction, objectMovement.speed);
				
				_object.objectMovement.LastSpeed = objectMovement.LastSpeed;
				
			}
			
		}
						
	}

}