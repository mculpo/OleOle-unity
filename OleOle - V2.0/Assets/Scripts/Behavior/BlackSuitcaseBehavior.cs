using UnityEngine;
using System.Collections;

public class BlackSuitcaseBehavior : ObjectCollision {

#region events
	public static event System.Action cameCoinEvent;
#endregion

	private bool locked = true;
	private float runningTime;
	private ExecutionTimeManager executionTimeManager;
	private SceneryMovement sceneryMovement;

	void Awake () {

		executionTimeManager = GetComponent<ExecutionTimeManager>();
	
	}

	void OnEnable () {

		executionTimeManager.stopManagerTimeEvent += stopManagerTime;

	}

	void OnDisable () {

		executionTimeManager.stopManagerTimeEvent -= stopManagerTime;

	}

	void Start () {

		sceneryMovement = GetComponent<SceneryMovement>();

		runningTime = WalletController.getValue(ItemsType.blackSuitcase);

	}

	void Update () {

		if(!locked){

			if(cameCoinEvent != null){

				cameCoinEvent();

			}

		}
	
	}

	protected override void collided(){

		sceneryMovement.enabled = false;

		transform.GetChild(0).gameObject.SetActive(false);

		executionTimeManager.startManagerTime(runningTime);

		locked = false;

	}

	protected override void collidedImmunized(){
		
		collided();
		
	}

	private void stopManagerTime(){

		locked = true;

		Destroy(this.gameObject);

	}

}