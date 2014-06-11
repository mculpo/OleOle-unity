using UnityEngine;
using System.Collections;

public class CrowdBehavior : ObjectCollision {

#region events
	public static event System.Action onGameOverEvent;
#endregion

	private Vector3 movePosition;

	private bool locked = true;

	private static CrowdBehavior self;

	void Start () {

		self = this;

	}

	void OnEnable () {

		PlayerBehavior.moveCrowdEvent += moveCrowd;
		AuxiliaryItemBehavior.moveCrowdEvent += moveCrowd;
		DrumBehavior.moveCrowdEvent += moveCrowd;
		
	}

	void OnDisable () {

		PlayerBehavior.moveCrowdEvent -= moveCrowd;
		AuxiliaryItemBehavior.moveCrowdEvent -= moveCrowd;
		DrumBehavior.moveCrowdEvent -= moveCrowd;

	}

	void Update () {

		if(!locked){

			transform.position = Vector3.Slerp(transform.position, movePosition, 2f * Time.deltaTime);

			if(Vector3.Distance(transform.position, movePosition) < 0.5f){

				locked = true;

			}

		}
	
	}

	protected override void collided(){

		onGameOverEvent();

	}

	protected override void collidedImmunized(){
		
		collided();
		
	}

	private void moveCrowd(bool isDead, float value){

		if(isDead){

			movePosition = new Vector3(PlayerBehavior.Get.transform.position.x + value, 
			                           transform.position.y, transform.position.z);

		}
		else{

			movePosition = new Vector3(transform.position.x + value, 
			                           transform.position.y, transform.position.z);

		}

		locked = false;

	}

	public void impulseCrowd(float force){

		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.AddForce(new Vector2(0, force));

	}

	public static CrowdBehavior Get {
		get {
			return self;
		}
	}

}