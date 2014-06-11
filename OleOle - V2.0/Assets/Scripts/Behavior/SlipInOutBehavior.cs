using UnityEngine;
using System.Collections;

public class SlipInOutBehavior : ObjectCollision {

	protected override void collided(){
		
		PlayerBehavior.Get.fixedSlip(true);
		
	}
	
	protected override void collidedImmunized(){

		collided();
		
	}

	void OnTriggerExit2D(Collider2D collider) {

		if(collider.CompareTag("Player") || collider.CompareTag("Immunized")){

			PlayerBehavior.Get.fixedSlip(false);

		}
		
	}

}