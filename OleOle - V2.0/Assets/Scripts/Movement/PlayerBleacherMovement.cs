using UnityEngine;
using System.Collections;

public class PlayerBleacherMovement : PlayerBehavior {

	public static bool locked;

	public float jumpForceBleacher = 210f,
				 jumpForce = 400f,
				 downForce = -3f;

	private int layerBleacherIndex = ((int) PlayerBleacherLayerType.playerBleacher5);

	void OnEnable () {
		
		TouchController.onUpMovementEvent += onUpMovement;
		TouchController.onDownMovementEvent += onDownMovement;

		HoleBehavior.onFallInTheHoleEvent += onDownMovement;

		ChangePlayerMovementController.changeMovementScriptsEvent += changeMovementScripts;
		
	}
	
	void OnDisable () {
		
		TouchController.onUpMovementEvent -= onUpMovement;
		TouchController.onDownMovementEvent -= onDownMovement;

		HoleBehavior.onFallInTheHoleEvent -= onDownMovement;

		ChangePlayerMovementController.changeMovementScriptsEvent -= changeMovementScripts;

	}
		
	void Update () {
		
		animator.SetBool("Ground", ownCharacterController.isGrounded);
		animator.SetFloat("SpeedPulo", ownCharacterController.motion.y);
		
		if(Input.GetKeyDown(KeyCode.Space)){
			
			onUpMovement();
			
		}
		
		if(Input.GetKeyDown(KeyCode.B)){
			
			onDownMovement();
			
		}
		
	}
	
	private void onUpMovement(){

		if(!locked){
		
			if(ownCharacterController.isGrounded){

				float _jump = jumpForce;

				if(layerBleacherIndex < ((int) PlayerBleacherLayerType.playerBleacher5)){

					setTriggerCollisor(true, true);
						
					layerBleacherIndex++;

					_jump = jumpForceBleacher;

				}

				ownCharacterController.jump(_jump);

				Invoke("deactivateTrigger", 0.5f);

			}

		}
		
	}

	private void deactivateTrigger(){
		
		changeLayer(layerBleacherIndex);

		setTriggerCollisor(false, false);

	}
	
	private void onDownMovement(){

		if(!locked){

			if(ownCharacterController.isGrounded && layerBleacherIndex > ((int) PlayerBleacherLayerType.playerBleacher1)){
			
				setTriggerCollisor(true, true);

				layerBleacherIndex--;

				changeLayer(layerBleacherIndex);

				ownCharacterController.move(new Vector2(0, downForce));

				setTriggerCollisor(false, false);

			}

		}
		
	}

	private void changeMovementScripts(){
		
		PlayerMovement _component = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
		
		_component.animator = this.animator;

		changeLayer(LayerMask.NameToLayer("Player"));
		
		Destroy(this);
		
	}

}