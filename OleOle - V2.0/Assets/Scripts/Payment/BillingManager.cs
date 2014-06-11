using UnityEngine;
using System.Collections;

public class BillingManager {
	
	static BillingManager(){
		
		#if UNITY_ANDROID
		string _key = 	"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjtXN/EOhIM+uNC4ussb9y+GXx3pLaHbggw/Q81OZ5cwc9o+yeQKn4IFQsb7LOca6ioN/IbIMtipwwCibFE4Xoe1jwgbj3A5tNj+m+agALH+LwdQFvGO3ISAx+pYNgDlJfYuZKfj3FwAW1CK++SyTx7Ce2Su2BfT9d9N/lghexhzmIAPKkldJrvlDXOEf8X+BrK+kowPQ+VF4zivEWB1el2JiB34KVa/9/HjCbTQRZzZH9c3auNvycfsNh7i2se/TtoFv+4fp5OKi39LcbiZOd99+G1SQsRdtC+wny7+OIvqG59vgFajaNzepF+zQ5Jzj0rP8CVqyaCbWKe0jxIzvwQIDAQAB";
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
