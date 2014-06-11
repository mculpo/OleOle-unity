using UnityEngine;
using System.Collections;

public class SceneryController : MonoBehaviour {

#region events
	public static event System.Action onChangeSceneryEvent;
#endregion

	private static SceneryType currentScenery,
							   lastScenery;

	private float maxChangingTime,
				  lastChangingTime;
	
	void Start () {

		currentScenery = SceneryType.Field;

		resetTime();
	
	}

	void Update () {

		if(canChange()){

			lastScenery = currentScenery;

			if(currentScenery == SceneryType.Field){

				currentScenery = Random.Range(0, 2) == 0 ? SceneryType.Bleacher : SceneryType.Cloakromm;

			}
			else{

				currentScenery = SceneryType.Field;

			}

			onChangeSceneryEvent();

			resetTime();

		}
	
	}

	private bool canChange(){
		
		if((lastChangingTime + maxChangingTime) < Time.time){
			
			return true;
			
		}
		
		return false;
		
	}
	
	private void resetTime(){

		maxChangingTime = Random.Range(20, 50);

		lastChangingTime = Time.time;
		
	}

	public static SceneryType CurrentScenery {
		get {
			return currentScenery;
		}
	}

	public static SceneryType LastScenery {
		get {
			return lastScenery;
		}
	}

}