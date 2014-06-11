using UnityEngine;
using System.Collections;

public class DrumBehavior : ObstacleBehavior {

	public float impulseForce,
				 sceneryMoveSpeed;

#region events
	public static event System.Action<bool, float> moveObjectEvent;
	public static event System.Action<bool, float> moveCrowdEvent;
#endregion

	private AnyCollision anyCollision;

	void Awake () {
		
		anyCollision = GetComponent<AnyCollision>();
		
	}

	void OnEnable () {

		if(anyCollision != null){

			anyCollision.onCollisionEvent += crowdCollision;

		}
		
	}
	
	void OnDisable () {
		
		if(anyCollision != null){
			
			anyCollision.onCollisionEvent -= crowdCollision;
			
		}
		
	}
	
	protected override void collided(){
		base.collided();

		PlayerBehavior.Get.impulseBody(impulseForce);

		moveObjectEvent(true, sceneryMoveSpeed);

		moveCrowdEvent(false, -2.0f);

		Invoke("goBackSceneryMovement", 0.25f);

	}

	private void goBackSceneryMovement(){

		moveObjectEvent(false, 0);

	}

	protected override void collidedImmunized(){

		collided();

	}

	private void crowdCollision(){

		CrowdBehavior.Get.impulseCrowd(impulseForce);

	}

}