using UnityEngine;
using System.Collections;

public class AnyCollision : MonoBehaviour {

	public string TAG;

#region events
	public event System.Action onCollisionEvent;
#endregion

	void OnCollisionEnter2D(Collision2D collision) {

		if(collision.collider.CompareTag(TAG)){
			
			onCollisionEvent();
			
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
					
		if(collider.CompareTag(TAG)){
						
			onCollisionEvent();
			
		}
					
	}

}