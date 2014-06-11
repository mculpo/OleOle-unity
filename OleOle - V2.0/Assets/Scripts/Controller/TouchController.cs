using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	public float minMovement = 1.0f;

	public static Collider2D collider;

	// -1 = Everything / 0 = Nothing	
	public static LayerMask layerMask = 0;

#region events
	public static event System.Action<string> onTouchEvent;
	public static event System.Action onUpMovementEvent;
	public static event System.Action onDownMovementEvent;
#endregion

	private Vector2 startPosition;

	// 0 is no movement, < 0 is down movement and > 0 is up movement
	private float movementIndex;

	void Update () {
		/*
		if(Input.GetMouseButtonDown(0)){
				
			onTouchEvent(null);

		}*/

		if(Input.touchCount > 0){

			Touch _touch = Input.GetTouch(0);

			if(_touch.phase == TouchPhase.Began){

				this.startPosition = _touch.position;

				this.movementIndex = 0;

			}

			if(_touch.phase == TouchPhase.Moved){

				Vector2 _difference = _touch.position - this.startPosition;

				if(_difference.magnitude > minMovement){

					this.movementIndex = _difference.y;

				}
								
			}

			if(_touch.phase == TouchPhase.Canceled || _touch.phase == TouchPhase.Ended){

				if(movementIndex == 0){

					int mask = 1 << layerMask.value;

					Ray _ray = Camera.main.ScreenPointToRay(_touch.position);

					RaycastHit2D _hit = Physics2D.GetRayIntersection(_ray, 20.0f, mask);
					
					if (_hit.collider != null){

						collider = _hit.collider;

						TouchController.onTouchEvent(_hit.collider.name);
						
					}

				}
				else if(movementIndex > 0){
					if(onUpMovementEvent != null)
						TouchController.onUpMovementEvent();
					
				}
				else{

					if(onDownMovementEvent != null)
						TouchController.onDownMovementEvent();
					
				}
			
			}

		}
	
	}

}