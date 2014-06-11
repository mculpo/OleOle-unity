using UnityEngine;
using System.Collections;

public class PlayerMovement : PlayerBehavior {

	public float jumpForce = 400f;
		
	void OnEnable () {
		
		TouchController.onUpMovementEvent += onUpMovement;
		TouchController.onDownMovementEvent += onDownMovement;

		ChangePlayerMovementController.changeMovementScriptsEvent += changeMovementScripts;
		
	}
	
	void OnDisable () {
		
		TouchController.onUpMovementEvent -= onUpMovement;
		TouchController.onDownMovementEvent -= onDownMovement;

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
		
		if(ownCharacterController.isGrounded){
			
			ownCharacterController.jump(jumpForce);
			
		}
		
	}
	
	private void onDownMovement(){
		
		if(ownCharacterController.isGrounded){

			this.slip(true);

			Invoke("unSlip", 0.82f);

		}
		
	}

	private void unSlip(){

		if(!isFixedSliping){

			this.slip(false);

		}

	}

	private void changeMovementScripts(){

		PlayerBleacherMovement _component = gameObject.AddComponent<PlayerBleacherMovement>() as PlayerBleacherMovement;

		_component.animator = this.animator;

		changeLayer(LayerMask.NameToLayer("PlayerBleacher5"));

		Destroy(this);

	}

}