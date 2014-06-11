using UnityEngine;
using System.Collections;

public class GetItemsBehavior : ObjectCollision {

	public Transform target;

	public ItemsType itemType;

	private float value;

	private FlyBehavior flyBehavior;

	void Awake () {

		flyBehavior = GetComponent<FlyBehavior>();
		
	}

	void OnEnable () {
		
		flyBehavior.onArriveAtDestinyEvent += addOnWallet;
		
	}

	void OnDisable () {

		flyBehavior.onArriveAtDestinyEvent -= addOnWallet;

	}

	void Start () {

		if(itemType != ItemsType.coin && itemType != ItemsType.yellowCard){

			value = WalletController.getValue(itemType);

		}

	}

	protected override void collided(){
					
		flyBehavior.flyToTarget(target, true);

	}

	protected override void collidedImmunized(){
		
		collided();
		
	}

	private void addOnWallet(){

		switch(itemType){
			
			case ItemsType.coin : {
				
				WalletController.addCoin();
				
				break;
			}
				
			case ItemsType.whistle : {
				
				WalletController.addCoins(value);
				
				break;
			}
				
			case ItemsType.yellowCard : {
				
				WalletController.addYellowCard();
				
				break;
			}

			default : {

				WalletController.addItems(itemType, value);

				break;
			}
			
		}

		Destroy(this.gameObject);

	}

}