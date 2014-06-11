using UnityEngine;
using System.Collections;

public abstract class ImmunizedObjectCollision : MonoBehaviour {

	// because the player has two colliders
	private bool lockedCollision;

	void OnCollisionEnter2D(Collision2D collision) {

		if(!lockedCollision){

			if(collision.collider.CompareTag("Immunized")){

				lockedCollision = true;

				collided();

			}

		}

	}

	protected abstract void collided();

}