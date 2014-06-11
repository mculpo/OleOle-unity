using UnityEngine;
using System.Collections;

public abstract class ObjectCollision : MonoBehaviour {

	// because the player has two colliders
	private bool lockedCollision;

	void OnTriggerEnter2D(Collider2D collider) {

		if(!lockedCollision){

			if(collider.CompareTag("Player")){

				lockedCollision = true;

				collided();

			}
			else if(collider.CompareTag("Immunized")){

				lockedCollision = true;
				
				collidedImmunized();

			}

		}

	}

	protected abstract void collided();

	protected abstract void collidedImmunized();

}