using UnityEngine;
using System.Collections;

public class CheckDistanceTrigger : MonoBehaviour {

	public float maxDistance;

#region events
	public event System.Action onIsNearEvent;
#endregion

	private bool locked;

	void Update () {

		if(!locked){

			if(Vector3.Distance(PlayerBehavior.Get.transform.position, transform.position) < maxDistance){

				locked = true;

				onIsNearEvent();

			}

		}
	
	}

}