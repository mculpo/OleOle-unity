using UnityEngine;
using System.Collections;

public class ExecutionTimeManager : MonoBehaviour {

	private float lastTime,
				  maxTime;
	private bool locked = true;

#region events
	public event System.Action stopManagerTimeEvent;
#endregion

	void Update () {

		if(!locked){

			if((lastTime + maxTime) < Time.time){

				locked = true;

				stopManagerTimeEvent();

			}

		}
	
	}

	public void startManagerTime(float time){

		this.maxTime = time;

		this.lastTime = Time.time;

		this.locked = false;

	}

}