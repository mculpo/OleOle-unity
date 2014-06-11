using UnityEngine;
using System.Collections;

public class ManGrabBehavior : MonoBehaviour {

	public Animator animator;
	public float jumpHigh;

	private bool locked;
	private CheckDistanceTrigger checkDistanceTrigger;
	private BoxCollider2D boxCollider;
	private CircleCollider2D circleCollider;
	private CharacterController2D characterController;

	void Awake () {

		checkDistanceTrigger = GetComponent<CheckDistanceTrigger>();

	}

	void OnEnable () {

		checkDistanceTrigger.onIsNearEvent += onIsNear;

	}

	void OnDisable () {
	
		checkDistanceTrigger.onIsNearEvent -= onIsNear;

	}

	void Start () {

		characterController = GetComponent<CharacterController2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		circleCollider = GetComponent<CircleCollider2D>();

	}

	void Update () {
	
		setTriggerCollisor(!characterController.isGrounded);
				
	}

	private void setTriggerCollisor(bool parm){
		
		boxCollider.isTrigger = parm;
		circleCollider.isTrigger = parm;
		
	}

	private void onIsNear() {

		animator.SetTrigger("Pular");
		characterController.jump(jumpHigh);
						
	}

}