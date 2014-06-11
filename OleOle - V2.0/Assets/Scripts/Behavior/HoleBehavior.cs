using UnityEngine;
using System.Collections;

public class HoleBehavior : ObjectCollision {

#region events
	public static event System.Action onFallInTheHoleEvent;
#endregion

	private bool locked;

	protected override void collided(){

		if(!locked){

			onFallInTheHoleEvent();

			locked = true;

		}

	}

	protected override void collidedImmunized(){}

}