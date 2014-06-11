using UnityEngine;
using System.Collections;

public class BillingManager {
	
	static BillingManager(){
		
		#if UNITY_ANDROID
		string _key = 	"";
		GoogleIAB.init(_key);
		#endif
		
	}
	
	public static void getItems()
	{
		
		string[] _idItems = new string[] {BillingItemsIds.coin_01, BillingItemsIds.coin_02, 
			BillingItemsIds.coin_03, BillingItemsIds.coin_04};

		#if UNITY_ANDROID
		GoogleIAB.queryInventory(_idItems);
		#elif UNITY_IPHONE
		StoreKitBinding.requestProductData(_idItems);
		#endif
		
	}
	
	public static void buyItem(string itemID){
		
		#if UNITY_ANDROID
		GoogleIAB.purchaseProduct(itemID);
		#elif UNITY_IPHONE
		StoreKitBinding.purchaseProduct(itemID, 1);
		#endif
		
	}
	
	public static void consumeItem(string itemID){
		
		#if UNITY_ANDROID
		GoogleIAB.consumeProduct(itemID);
		#endif
		
	}
}
