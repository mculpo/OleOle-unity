using UnityEngine;
using System.Collections;

public class InterfaceController : MonoBehaviour {

	public TextMesh coinText,
					timeText;
		
	public GameObject yellowCard, 
					  redCard;

	private static InterfaceController self;

	void OnEnable () {
		
		TouchController.onTouchEvent += onTouch;
		
	}
	
	void OnDisable () {
		
		TouchController.onTouchEvent -= onTouch;
		
	}

	void Start () {
		
		self = this;
		
	}

	private void onTouch(string name){

		switch(name){
			
			case "Pause" : {
				
				Director.pauseGame();
				
				break;
			}
				
			case "RedCard" : {
				
				RedCardBehavior.Get.useRedCard();
				
				break;
			}

		}

	}

	public void updateCoin(int value){

		coinText.text = value.ToString();

	}

	public void updateTime(float value){

		//timeText.text = value.ToString();

	}

	public void updateYellowCard(bool parm){

		yellowCard.SetActive(parm);

	}

	public void updateRedCard(int value){
		
		if(value <= 0){

			redCard.SetActive(false);

		}
		else if(value == 1){

			redCard.SetActive(true);
			redCard.transform.GetChild(0).gameObject.SetActive(false);

		}
		else{

			redCard.SetActive(true);

			Transform _child = redCard.transform.GetChild(0);

			_child.gameObject.SetActive(true);

			_child.GetComponent<TextMesh>().text = "x" + value.ToString();

		}
		
	}

	public static InterfaceController Get {
		get {
			return self;
		}
	}

}