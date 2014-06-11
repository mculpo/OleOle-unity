using UnityEngine;
using System.Collections;

public class ADSEventListener : MonoBehaviour {

	void OnEnable() {

#if UNITY_ANDROID
		AdMobAndroidManager.failedToReceiveAdEvent += failedToReceiveAdEvent;
		AdMobAndroidManager.leavingApplicationEvent += leavingApplicationEvent;
		AdMobAndroidManager.receivedAdEvent += receivedAdEvent;
		AdMobAndroidManager.interstitialDismissingScreenEvent += interstitialDismissingScreenEvent;
		AdMobAndroidManager.interstitialFailedToReceiveAdEvent += interstitialFailedToReceiveAdEvent;
		AdMobAndroidManager.interstitialLeavingApplicationEvent += interstitialLeavingApplicationEvent;
#elif UNITY_IPHONE
		ADBannerView.onBannerWasClicked += leavingApplicationEvent;
		ADBannerView.onBannerWasLoaded  += receivedAdEvent;
		ADInterstitialAd.onInterstitialWasLoaded  += onFullBannerLoaded;
#endif

	}	
	
	void OnDisable() {

#if UNITY_ANDROID
		AdMobAndroidManager.failedToReceiveAdEvent -= failedToReceiveAdEvent;
		AdMobAndroidManager.leavingApplicationEvent -= leavingApplicationEvent;
		AdMobAndroidManager.receivedAdEvent -= receivedAdEvent;		
		AdMobAndroidManager.interstitialDismissingScreenEvent -= interstitialDismissingScreenEvent;
		AdMobAndroidManager.interstitialFailedToReceiveAdEvent -= interstitialFailedToReceiveAdEvent;
		AdMobAndroidManager.interstitialLeavingApplicationEvent -= interstitialLeavingApplicationEvent;
#elif UNITY_IPHONE
		ADBannerView.onBannerWasClicked -= leavingApplicationEvent;
		ADBannerView.onBannerWasLoaded  -= receivedAdEvent;
		ADInterstitialAd.onInterstitialWasLoaded  -= onFullBannerLoaded;
#endif

	}
		
#if UNITY_ANDROID
	void failedToReceiveAdEvent(string error){

		StartCoroutine(ADSController.createBanner());

	}
#endif
	
	void leavingApplicationEvent(){

		StartCoroutine(ADSController.refresh());

	}
		
	
	void receivedAdEvent(){

#if UNITY_ANDROID
		StartCoroutine(ADSController.hideBanner());
#endif
		StartCoroutine(ADSController.showBanner());

	}

#if UNITY_ANDROID
	void interstitialDismissingScreenEvent(){

		StartCoroutine(ADSController.refresh());
		StartCoroutine(ADSController.hideBanner());

	}	
	
	void interstitialFailedToReceiveAdEvent(string error){

		StartCoroutine(ADSController.createFullBanner());

	}
	
	void interstitialLeavingApplicationEvent(){

		StartCoroutine(ADSController.showBanner());

	}
#endif

#if UNITY_IPHONE
	void onFullBannerLoaded(){
		
		iAd.setFullBannerReady(true);
				
	}
#endif

}