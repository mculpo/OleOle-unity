using UnityEngine;
using System.Collections;

public abstract class SceneryListener : MonoBehaviour {

	public float startLimit, 
				 endLimit;
	
	private bool locked;
	
	void Update () {
		
		if(!locked){
			
			if(transform.position.x > endLimit && transform.position.x < startLimit){
				
				locked = true;
				
				onBecameVisible();
				
			}
			
		}
		else{
			
			if(transform.position.x < endLimit){
				
				onBecameInvisible();
				
			}
			
		}
		
	}

	protected abstract void onBecameVisible();

	protected abstract void onBecameInvisible();

}