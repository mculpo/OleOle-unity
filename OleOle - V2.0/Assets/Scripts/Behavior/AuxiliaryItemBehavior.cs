using UnityEngine;
using System.Collections;

public class AuxiliaryItemBehavior : ObjectCollision {

	public AudioClip newAudio;
	public float sceneryMoveSpeed;
	public int accelerateTime;
	public ItemsType itemType;

	private ExecutionTimeManager executionTimeManager;
	private float runningTime;

#region events
	public static event System.Action<bool, float> moveObjectEvent;
	public static event System.Action<bool, float> moveCrowdEvent;
	public static event System.Action<bool, int> accelerateTimeEvent;
#endregion

	protected virtual void Awake () {

		executionTimeManager = GetComponent<ExecutionTimeManager>();

	}

	protected virtual void OnEnable () {

		executionTimeManager.stopManagerTimeEvent += stopManagerTime;

	}

	protected virtual void OnDisable () {

		executionTimeManager.stopManagerTimeEvent -= stopManagerTime;

	}

	protected virtual void Start () {
		
		runningTime = WalletController.getValue(itemType);
		
	}

	protected override void collided(){

		GetComponent<SceneryMovement>().enabled = false;
		
		PlayerBehavior.Get.activeSelf(false);

		//Director.Get.changeBackgroundAudio(newAudio);

		executionTimeManager.startManagerTime(runningTime);

		moveObjectEvent(true, sceneryMoveSpeed);

		moveCrowdEvent(false, -5.0f);

		accelerateTimeEvent(true, accelerateTime);
				
	}

	protected override void collidedImmunized(){

		collided();
		
	}

	protected virtual void stopManagerTime(){

		//Director.Get.restoreLastBackgroundAudio();

		PlayerBehavior.Get.activeSelf(true);
				
		moveObjectEvent(false, 0);
		
		accelerateTimeEvent(false, 0);

		GetComponent<SceneryMovement>().enabled = true;

	}

}