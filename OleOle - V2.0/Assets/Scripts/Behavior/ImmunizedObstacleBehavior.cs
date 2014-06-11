using UnityEngine;
using System.Collections;

public class ImmunizedObstacleBehavior : ImmunizedObjectCollision {

	public Animator animator;

	protected override void collided(){

		animator.SetTrigger("destroi");

	}

}