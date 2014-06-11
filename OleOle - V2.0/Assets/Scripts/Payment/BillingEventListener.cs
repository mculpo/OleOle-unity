using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BillingEventListener : MonoBehaviour
{

	public StoreCoinItem 	item_01,
							item_02,
							item_03,
							item_04;

	void Start()
	{
		BillingManager.getItems();
	}

	void OnEnable()
	{
		// Listen to all events for illustration purposes
		#if UNITY_ANDROID
		GoogleIABManager.queryInventorySucceededEvent += android_productListReceivedEvent;
		GoogleIABManager.queryInventoryFailedEvent += failedEvent;
		GoogleIABManager.purchaseSucceededEvent += android_purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += failedEvent;
		#elif UNITY_IPHONE
		StoreKitManager.productListReceivedEvent += iOS_productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent += failedEvent;		
		StoreKitManager.purchaseSuccessfulEvent += iOS_purchaseSucceededEvent;
		StoreKitManager.purchaseCancelledEvent += failedEvent;
		StoreKitManager.purchaseFailedEvent += failedEvent;
		#endif
	}

	void OnDisable(){
		
		// Remove all event handlers
		#if UNITY_ANDROID
		GoogleIABManager.queryInventorySucceededEvent -= android_productListReceivedEvent;
		GoogleIABManager.queryInventoryFailedEvent -= failedEvent;
		GoogleIABManager.purchaseSucceededEvent -= android_purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= failedEvent;
		#elif UNITY_IPHONE
		StoreKitManager.productListReceivedEvent -= iOS_productListReceivedEvent;
		StoreKitManager.productListRequestFailedEvent -= failedEvent;		
		StoreKitManager.purchaseSuccessfulEvent -= iOS_purchaseSucceededEvent;
		StoreKitManager.purchaseCancelledEvent -= failedEvent;
		StoreKitManager.purchaseFailedEvent -= failedEvent;
		#endif
		
	}

	void failedEvent(string error)
	{
		GameObject.Find("erro").GetComponent<TextMesh>().text = error;
	}
	
#if UNITY_ANDROID
	void android_productListReceivedEvent(List<GooglePurchase> purchases, List<GoogleSkuInfo> skus)
	{
		if(skus.Count > 0)
		{
			foreach(GoogleSkuInfo sku in skus)
			{
				if(sku.productId == BillingItemsIds.coin_01)
				{
					item_01.init(sku.productId, sku.price);
				}
				else if(sku.productId == BillingItemsIds.coin_02)
				{
					item_02.init(sku.productId, sku.price);
				}
				else if(sku.productId == BillingItemsIds.coin_03)
				{
					item_03.init(sku.productId, sku.price);
				}
				else if(sku.productId == BillingItemsIds.coin_04)
				{
					item_04.init(sku.productId, sku.price);
				}
			}
		}
	}
	
	void android_purchaseSucceededEvent(GooglePurchase purchase)
	{
		if(purchase.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if(purchase.productId == BillingItemsIds.coin_01)
			{
				WalletController.addCoins(100f);
			}
			else if(purchase.productId == BillingItemsIds.coin_02)
			{
				WalletController.addCoins(1000f);
			}
			else if(purchase.productId == BillingItemsIds.coin_03)
			{
				WalletController.addCoins(10000f);
			}
			else if(purchase.productId == BillingItemsIds.coin_04)
			{
				WalletController.addCoins(100000f);
			}
			
			BillingManager.consumeItem(purchase.productId);
			
			StoreInterface.updateCoin();
		}
	}
	#endif
	
	#if UNITY_IPHONE
	void iOS_productListReceivedEvent(List<StoreKitProduct> productList){
		
		if(productList.Count > 0){
			
			foreach(StoreKitProduct skp in productList){
				
				if(skp.productIdentifier == BillingItemsIDs.teeth_01){
					
					item01.init(skp.productIdentifier, skp.price);
					
				}
				else if(skp.productIdentifier == BillingItemsIDs.teeth_02){
					
					item02.init(skp.productIdentifier, skp.price);
					
				}
				else if(skp.productIdentifier == BillingItemsIDs.teeth_03){
					
					item03.init(skp.productIdentifier, skp.price);
					
				}
				else if(skp.productIdentifier == BillingItemsIDs.teeth_04){
					
					item04.init(skp.productIdentifier, skp.price);
					
				}
				
			}
			
		}
		
	}
	
	void iOS_purchaseSucceededEvent(StoreKitTransaction transaction){
		
		if(transaction.productIdentifier == BillingItemsIDs.teeth_01) {
			
			MoneyTeeth.addTeeth(1000f);
			
		}
		else if(transaction.productIdentifier == BillingItemsIDs.teeth_02) {
			
			MoneyTeeth.addTeeth(10000f);
			
		}
		else if(transaction.productIdentifier == BillingItemsIDs.teeth_03) {
			
			MoneyTeeth.addTeeth(100000f);
			
		}
		else if(transaction.productIdentifier == BillingItemsIDs.teeth_04) {
			
			MoneyTeeth.addTeeth(1000000f);
			
		}
		
		LoadStore.shareLoadStore().loadTeethAmount();
		
	}
	#endif
}
