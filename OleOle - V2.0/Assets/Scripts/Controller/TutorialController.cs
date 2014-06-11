using UnityEngine;
using System.Collections;

public class TutorialController : ObjectCollision {

	public static string TUTORIAL_KEY = "TUTORIAL_KEY";

	public TutorialType tutorialType;

	public Animator animator;

	public int maxCount;

	private int count;

	void OnEnable () {

		switch(tutorialType){

			case TutorialType.touch : {

				TouchController.onTouchEvent += onTouch;

				break;
			}

			case TutorialType.upMovement : {

				TouchController.onUpMovementEvent += onMovementTouch;
				
				break;
			}

			case TutorialType.downMovement : {

				TouchController.onDownMovementEvent += onMovementTouch;
				
				break;
			}

		}

	}

	void OnDisable () {

		switch(tutorialType){
			
			case TutorialType.touch : {
				
				TouchController.onTouchEvent -= onTouch;
				
				break;
			}
				
			case TutorialType.upMovement : {
				
				TouchController.onUpMovementEvent -= onMovementTouch;
				
				break;
			}
				
			case TutorialType.downMovement : {
				
				TouchController.onDownMovementEvent -= onMovementTouch;
				
				break;
			}
			
		}
	
	}

	private void onTouch(string name){

		if(count < (maxCount - 1)){

			count++;

		}
		else{

			SaveSystem.saveInt(TUTORIAL_KEY, 1);

			Destroy(this);

		}

	}

	private void onMovementTouch(){
		
		onTouch(null);
		
	}

	protected override void collided(){
		
		animator.SetTrigger("Animation");
		
	}

	protected override void collidedImmunized(){
		
		collided();
		
	}

}