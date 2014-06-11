using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {
	
	public float maxDistance;
	
	private FlyBehavior flyBehavior;
	
	private bool locked;
	
	void OnEnable () {
		
		BlackSuitcaseBehavior.cameCoinEvent += cameCoin;
		
	}
	
	void OnDisable () {
		
		BlackSuitcaseBehavior.cameCoinEvent -= cameCoin;
		
	}
	
	void Start () {
		
		flyBehavior = GetComponent<FlyBehavior>();
		
	}
	
	private void cameCoin(){
		
		if(!locked){
			
			if(Vector3.Distance(PlayerBehavior.Get.transform.position, transform.position) < maxDistance){
				
				locked = true;
				
				flyBehavior.flyToTarget(PlayerBehavior.Get.transform, false);
				
			}
			
		}
		
	}
	
}