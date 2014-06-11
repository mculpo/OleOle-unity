using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
#if UNITY_ANDROID
	using UnityEngine.SocialPlatforms;
#elif UNITY_IPHONE
	using UnityEngine.SocialPlatforms.GameCenter;
#endif

public class GPGController : MonoBehaviour {

	public static GPGController instance;

	private static string leaderBoardID = "CgkI5dqJnYIfEAIQAQ";


#if UNITY_IPHONE
	private static bool isConnected = false;
#endif

	void Awake () {

		instance = GameObject.Find(this.gameObject.name).GetComponent<GPGController>();
	}

	void Start () {

#if UNITY_ANDROID
		Social.Active = new UnityEngine.SocialPlatforms.GPGSocial();
#elif UNITY_IPHONE
		GameCenterPlatform.ShowDefaultAchievementCompletionBanner(true);
		StartCoroutine(GPGController.checkConnection());
#endif

		StartCoroutine(GPGController.signIn());

	}

#if UNITY_IPHONE
	private static IEnumerator checkConnection(){

		WWW _www = new WWW("http://www.google.com");

		yield return _www;

		if(_www.error != null){

			isConnected = false;

		}
		else{

			isConnected = true;
			
		}

	}
#endif
	
	public static IEnumerator signIn()
	{

		yield return null;

		Social.localUser.Authenticate(instance.onSignInEvent);

	}

	public static void showLeaderBoards()
	{

		if(Social.localUser.authenticated)

			Social.ShowLeaderboardUI();

		else
			instance.StartCoroutine(GPGController.signIn());

	}

	public static IEnumerator submitScore(float score)
	{
		yield return null;

		if(Social.localUser.authenticated)
		{
			Social.ReportScore((int)score, leaderBoardID, instance.onSubmitScoreEvent);

		}

		else

			Synchronization.setSynchronization();
	}


#region listeners
	
	private void onSignInEvent(bool result)
	{
		if(result)
		{
#if UNITY_ANDROID 
			Synchronization.check();
#elif UNITY_IPHONE
			Synchronization.check();
#endif
		}
	}

	private void onSubmitScoreEvent(bool result)
	{
		if(!result)
		{
			Synchronization.setSynchronization();
		}
	}

#endregion

}