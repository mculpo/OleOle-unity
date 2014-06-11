using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

	public Vector2 direction;
	public float speed;

	protected bool locked;
	protected float lastSpeed;

	protected virtual void OnEnable () {

		DrumBehavior.moveObjectEvent += moveObject;
		AuxiliaryItemBehavior.moveObjectEvent += moveObject;
		
	}
	
	protected virtual void OnDisable () {

		DrumBehavior.moveObjectEvent -= moveObject;
		AuxiliaryItemBehavior.moveObjectEvent -= moveObject;
		
	}

	void Update () {

		if(!locked){

			transform.Translate((new Vector3(this.direction.x, this.direction.y, 0) * this.speed) * Time.deltaTime);


		}
	
	}

	protected virtual void moveObject(bool state, float value){

		if(state){
			
			this.lastSpeed = this.speed;
			this.speed += value;
			
		}
		else{
			
			speed = this.lastSpeed;
			
		}
		
	}

	public void movement(Vector2 direction, float speed){

		this.direction = direction;
		this.speed = speed;

	}

	public float LastSpeed {
		get {
			return this.lastSpeed;
		}
		set {
			lastSpeed = value;
		}
	}

}