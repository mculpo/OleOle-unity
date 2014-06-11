using UnityEngine;
using System.Collections;

public class GameTimeController : MonoBehaviour {

	public Object fourthRefereePrefab, 
				  narratorPrefab;

	private float bestTime, 
				  currentTime, 
				  lastTime;

	private int frequency = 1;

	private bool lockedBreakRecord;

	public static string BEST_TIME_KEY = "BEST_TIME_KEY";

	void OnEnable () {

		AuxiliaryItemBehavior.accelerateTimeEvent += accelerateTime;
		CrowdBehavior.onGameOverEvent += onGameOver;

	}

	void OnDisable () {

		AuxiliaryItemBehavior.accelerateTimeEvent -= accelerateTime;
		CrowdBehavior.onGameOverEvent -= onGameOver;

	}

	void Start () {

		bestTime = 100.35f;//SaveSystem.loadFloat(BEST_TIME_KEY);
	
	}

	void Update () {

		currentTime += ((Time.time - lastTime) * frequency);

		lastTime = Time.time;

		InterfaceController.Get.updateTime((float) System.Math.Round((decimal) currentTime, 1));

		if(!lockedBreakRecord){

			if(bestTime > 0 && currentTime > bestTime){

				lockedBreakRecord = true;

				breakRecord();
				
			}

		}

	
	}

	private void breakRecord(){

		print("Record broken = " + bestTime);

		//InstanceController.createObject(narratorPrefab, transform.position);

		//InstanceController.createObject(fourthRefereePrefab, transform.position);
				
	}

	private void onGameOver(){

		//SaveSystem.saveFloat(BEST_TIME_KEY, currentTime);

	}

	private void accelerateTime(bool state, int frequency){

		if(state){

			this.frequency = frequency;

		}
		else{

			this.frequency = 1;

		}

	}

}