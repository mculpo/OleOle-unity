using UnityEngine;
using System.Collections;

public class ChangePlayerMovementController : ObjectCollision {

#region events
	public static event System.Action changeMovementScriptsEvent;
#endregion

		
	protected override void collided(){

		changeMovementScriptsEvent();

	}

	protected override void collidedImmunized(){
		
		collided();
		
	}

}