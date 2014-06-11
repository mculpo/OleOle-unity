using UnityEngine;
using System.Collections;

public class MotherMovement : MonoBehaviour {

	public CircleCollider2D circleCollider;
	public BoxCollider2D boxCollider;

	public float jumpForceBleacher = 210f,
				 downForce = -3f;
	
	private int layerBleacherIndex = ((int) PlayerBleacherLayerType.playerBleacher5);

	private CharacterController2D ownCharacterController;

	private ExecutionTimeManager executionTimeManager;

	void Awake () {
		
		executionTimeManager = GetComponent<ExecutionTimeManager>();
		
	}

	void OnEnable () {
		
		TouchController.onUpMovementEvent += onUpMovement;
		TouchController.onDownMovementEvent += onDownMovement;

		executionTimeManager.stopManagerTimeEvent += stopManagerTime;
						
	}
	
	void OnDisable () {
		
		TouchController.onUpMovementEvent -= onUpMovement;
		TouchController.onDownMovementEvent -= onDownMovement;

		executionTimeManager.stopManagerTimeEvent -= stopManagerTime;
		
	}

	void Start () {
		
		ownCharacterController = GetComponent<CharacterController2D>();
		
	}
	
	void Update () {
				
		if(Input.GetKeyDown(KeyCode.Space)){
			
			onUpMovement();
			
		}
		
		if(Input.GetKeyDown(KeyCode.B)){
			
			onDownMovement();
			
		}
		
	}
	
	private void onUpMovement(){
					
		if(ownCharacterController.isGrounded && layerBleacherIndex < ((int) PlayerBleacherLayerType.playerBleacher5)){
									
			setTriggerCollisor(true, true);
				
			layerBleacherIndex++;
						
			ownCharacterController.jump(jumpForceBleacher);
			
			Invoke("deactivateTrigger", 0.5f);
			
		}
					
	}
	
	private void deactivateTrigger(){
		
		changeLayer(layerBleacherIndex);
		
		setTriggerCollisor(false, false);
		
	}
	
	private void onDownMovement(){
					
		if(ownCharacterController.isGrounded && layerBleacherIndex > ((int) PlayerBleacherLayerType.playerBleacher1)){
			
			setTriggerCollisor(true, true);
			
			layerBleacherIndex--;
			
			changeLayer(layerBleacherIndex);
			
			ownCharacterController.move(new Vector2(0, downForce));
			
			setTriggerCollisor(false, false);
				
		}
					
	}
	
	private void setTriggerCollisor(bool boxParm, bool circleParm){
		
		boxCollider.isTrigger = boxParm;
		circleCollider.isTrigger = circleParm;
		
	}

	public void changeLayer(int layer){
		
		gameObject.layer = layer;
		
	}

	private void stopManagerTime(){

		changeLayer(LayerMask.NameToLayer("WithoutCollision"));

	}

}