using UnityEngine;
using System.Collections;

public class ManSlideTackleBehavior : MonoBehaviour {

	public Animator animator;
	public CircleCollider2D circleCollider;
	public BoxCollider2D boxCollider;

	private CheckDistanceTrigger checkDistanceTrigger;

	void Awake () {
		
		checkDistanceTrigger = GetComponent<CheckDistanceTrigger>();
		
	}
	
	void OnEnable () {
		
		checkDistanceTrigger.onIsNearEvent += onIsNear;
		
	}
	
	void OnDisable () {
		
		checkDistanceTrigger.onIsNearEvent -= onIsNear;
		
	}

	private void onIsNear() {

		rigidbody2D.isKinematic = true;
		setTriggerCollisor(true);

		animator.SetTrigger("Escorregar");

		Invoke("getUp", 0.85f);

	}

	private void getUp(){

		setTriggerCollisor(false);
		rigidbody2D.isKinematic = false;

	}

	private void setTriggerCollisor(bool parm){
		
		boxCollider.isTrigger = parm;
		circleCollider.isTrigger = parm;
		
	}

}