using UnityEngine;
using System.Collections;

public abstract class PlayerCollision : MonoBehaviour {

	protected bool immunized;

	void OnCollisionEnter2D(Collision2D collision) {

		if(!immunized && collision.collider != null){

			if(collision.collider.CompareTag("Obstacle_Rigid")){

				dead(false);

			}

		}
		
	}

	void OnTriggerEnter2D(Collider2D collider) {

		if(!immunized && collider != null){

			if(collider.CompareTag("Obstacle_Delay")){

				stumble();
				
			}
			else if(collider.CompareTag("Obstacle_Rigid")){

				dead(true);

			}

		}

	}

	protected abstract void stumble();

	protected abstract void dead(bool isStumbling);

}