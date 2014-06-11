using UnityEngine;
using System.Collections;

public class FlyBehavior : MonoBehaviour {

#region events
	public event System.Action onArriveAtDestinyEvent;
#endregion

	private Transform target;

	private bool locked = true, 
				 canCallEvent;

	private float flyTime = 5.0f,
				  pi;

	void Update () {
	
		if(!locked){

			if(Vector3.Distance(transform.position, target.position) > 1.0f){

				Vector3 _newPosition = Vector3.Slerp(transform.position, target.position, flyTime * Time.deltaTime);

				//transform.position = _newPosition;
				transform.position = new Vector3(_newPosition.x + Mathf.Cos(pi), _newPosition.y, 0);

				if (transform.localScale.x > 0.3){
				
					Vector3 _scale = transform.localScale;

					_scale = new Vector3(_scale.x - 0.025f, _scale.y - 0.025f, 0);

					transform.localScale = _scale;

				}

				pi = pi + 0.1f;

			}
			else{

				locked = true;

				if(canCallEvent){

					onArriveAtDestinyEvent();

				}

			}

		}

	}

	public void flyToTarget(Transform target, bool canCallEvent){

		this.target = target;

		this.canCallEvent = canCallEvent;

		pi = 0;

		locked = false;

	}

}