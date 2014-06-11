using UnityEngine;
using System.Collections;

public class RocketBehavior : AuxiliaryItemBehavior {

	public float rotationDelay, 
				 force;

#region events
	public static event System.Action<bool> playBonusSceneryEvent;
#endregion

	private Rigidbody2D rigid2d;
	private AnyCollision anyCollision;

	protected override void Awake () {
		base.Awake();

		anyCollision = GetComponent<AnyCollision>();
		
	}

	protected override void OnEnable () {
		base.OnEnable();
		
		TouchController.onTouchEvent += onTouch;

		anyCollision.onCollisionEvent += stopManagerTime;
		
	}
	
	protected override void OnDisable () {
		base.OnDisable();
		
		TouchController.onTouchEvent -= onTouch;

		anyCollision.onCollisionEvent -= stopManagerTime;
		
	}

	protected override void Start(){
		base.Start();

		rigid2d = rigidbody2D;

	}

	void FixedUpdate () {

		float _angle = 90 * (rigid2d.velocity.y / 10);

		Quaternion _newRotation = Quaternion.Euler(new Vector3(0, 0, _angle));

		transform.rotation = Quaternion.Slerp(transform.rotation, _newRotation, rotationDelay * Time.fixedDeltaTime);
	
	}

	private void onTouch(string name){

		addForce(force);

	}

	protected override void collided(){
		base.collided();

		transform.GetChild(1).gameObject.SetActive(true);
		transform.GetChild(0).gameObject.SetActive(false);

		PlayerBehavior.Get.transform.parent = this.transform;

		rigid2d.isKinematic = false;

		addForce(500);

		//playBonusSceneryEvent(true);

	}

	protected override void stopManagerTime(){
		base.stopManagerTime();

		PlayerBehavior.Get.transform.parent = null;

		//playBonusSceneryEvent(false);

		Destroy(this.gameObject);

	}

	private void addForce(float force){

		rigid2d.velocity = Vector2.zero;

		rigid2d.AddForce(new Vector2(0, force));

	}

}