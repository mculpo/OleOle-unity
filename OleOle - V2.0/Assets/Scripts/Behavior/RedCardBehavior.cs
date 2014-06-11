using UnityEngine;
using System.Collections;

public class RedCardBehavior : MonoBehaviour {

	private static RedCardBehavior self;

	private float runningTime = 13f;

	private ExecutionTimeManager executionTimeManager;

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
		
		self = this;
		
	}

	public void useRedCard(){

		WalletController.removeRedCard();

		PlayerBehavior.Get.immunize(true);

		executionTimeManager.startManagerTime(runningTime);
	
	}

	private void stopManagerTime(){

		PlayerBehavior.Get.immunize(false);

	}

	public static RedCardBehavior Get {
		get {
			return self;
		}
	}

}