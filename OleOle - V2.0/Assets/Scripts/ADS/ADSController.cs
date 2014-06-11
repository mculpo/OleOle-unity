using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ADSController : MonoBehaviour {

	public static ADSController instance;

	public static float maxTimeShowFullBanner = 120.0f,
	lastTimeShowedFullBanner;
	
	public static bool fullBannerLocked;

	void Awake () {

#if UNITY_ANDROID
		AdMobAndroid.init("");
#endif

		StartCoroutine(ADSController.createBanner());

	}

	void Start () {

		instance = GameObject.Find(this.gameObject.name).GetComponent<ADSController>();

	}

	public static IEnumerator createBanner(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.createBanner("", AdMobAndroidAd.phone320x50, AdMobAdPlacement.BottomCenter);
#elif UNITY_IPHONE
		iAd.createBanner(ADBannerView.Type.Banner, ADBannerView.Layout.BottomCenter);
#endif

	}

	public static IEnumerator refresh(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.refreshAd();
#elif UNITY_IPHONE
		iAd.destroyBanner();
		iAd.createBanner(ADBannerView.Type.Banner, ADBannerView.Layout.BottomCenter);
#endif

	}

	public static IEnumerator destroyBanner(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.destroyBanner();
#elif UNITY_IPHONE
		iAd.destroyBanner();
#endif
			
	}

	public static IEnumerator showBanner(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.hideBanner(false);
#elif UNITY_IPHONE
		iAd.showBanner(true);
#endif
				
	}

	public static IEnumerator hideBanner(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.hideBanner(true);
#elif UNITY_IPHONE
		iAd.showBanner(false);
#endif
				
	}

	public static IEnumerator createFullBanner(){
		
		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.requestInterstital("");
#elif UNITY_IPHONE
		iAd.createFullBanner();
#endif
						
	}
	public static bool isFullBannerReady(){
		
		if(!fullBannerLocked){
			
			return fullBannerLocked;
			
		}
		else{
			
			#if UNITY_ANDROID
			return AdMobAndroid.isInterstitalReady();
			#elif UNITY_IPHONE
			return iAd.isFullBannerReady();
			#endif
			
		}
		
	}
	public static IEnumerator showFullBanner(){

		yield return null;

#if UNITY_ANDROID
		AdMobAndroid.displayInterstital();
#elif UNITY_IPHONE
		iAd.showFullBanner();
#endif

	}

	public static void canCreateFullBanner() {
		
		if(!fullBannerLocked){
			
			if((ADSController.lastTimeShowedFullBanner + maxTimeShowFullBanner) < Time.time){
				
				fullBannerLocked = true;
				
				instance.StartCoroutine(ADSController.createFullBanner());
				
			}
			
		}
		
	}
}
