using UnityEngine;
using System.Collections;

public class CabinBehavior : ObjectCollision {

	public bool isSauna, 
				isEntry;
		
	protected override void collided(){

		if(isSauna){

			PlayerBehavior.Get.changeClothes(isEntry ? 1 : 0);

		}
		else{

			PlayerBehavior.Get.darkenBody(isEntry);

			PlayerBleacherMovement.locked = isEntry;

		}
		
	}

	protected override void collidedImmunized(){

		collided();

	}

}