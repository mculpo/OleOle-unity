using UnityEngine;
using System.Collections;

public class ObstacleBehavior : ObjectCollision {

	public Animator animator;

	protected override void collided(){

		animator.SetTrigger("Animation");

	}

	protected override void collidedImmunized(){
		
		animator.SetTrigger("AnimationImmunized");
		
	}

}