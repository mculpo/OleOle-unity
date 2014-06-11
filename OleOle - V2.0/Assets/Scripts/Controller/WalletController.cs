using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalletController : MonoBehaviour {

	private static Dictionary<ItemsType, float> items = new Dictionary<ItemsType, float>();

	public static void addCoin(){

		addItems(ItemsType.coin, 1);

		InterfaceController.Get.updateCoin((int) getValue(ItemsType.coin));

	}

	public static void addCoins(float value){

		addItems(ItemsType.coin, value);
		
	}

	public static void addYellowCard(){

		addItems(ItemsType.yellowCard, 1);

		float _value = getValue(ItemsType.yellowCard);

		if(_value < 2){

			InterfaceController.Get.updateYellowCard(true);

		}
		else{

			InterfaceController.Get.updateYellowCard(false);
			
			destroyItem(ItemsType.yellowCard);
			
			addRedCard(1f);

		}
				
	}

	public static void addRedCard(float value){
							
		addItems(ItemsType.redCard, (int) value);

		InterfaceController.Get.updateRedCard((int) getValue(ItemsType.redCard));
				
	}

	public static void removeRedCard(){

		removeItems(ItemsType.redCard, 1);
		
		InterfaceController.Get.updateRedCard((int) getValue(ItemsType.redCard));
		
	}

	public static void addItems(ItemsType type, float value){

		float _value;

		if(items.TryGetValue(type, out _value)){

			items.Remove(type);

			value += _value;

		}

		items.Add(type, value);
		
	}

	public static void removeItems(ItemsType type, float value){
		
		float _value;
		
		if(items.TryGetValue(type, out _value)){
			
			items.Remove(type);
			
			_value -= value;
			
		}
		
		items.Add(type, _value);
		
	}

	public static float getValue(ItemsType type){

		float _value;

		items.TryGetValue(type, out _value);

		return _value;
		
	}

	public static void destroyItem(ItemsType type){

		items.Remove(type);

	}

}