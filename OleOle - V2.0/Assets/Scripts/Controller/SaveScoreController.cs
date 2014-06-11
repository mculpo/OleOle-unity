using UnityEngine;
using System.Collections;

public class SaveScoreController : MonoBehaviour
{
	/// <summary>
	/// Saves the score.
	/// </summary>
	/// <param name="score">Score.</param>
	public static void saveScore( float score )
	{

		float _value  = loadScore();

		Debug.Log(_value + "::" + score);

		if( score >= _value )
		{
			SaveSystem.saveFloat(GameTimeController.BEST_TIME_KEY, score);

			GPGController.instance.StartCoroutine(GPGController.submitScore(score));

			GameObject.Find("T").GetComponent<TextMesh>().text = "submit";

		}
		else

			GameObject.Find("T").GetComponent<TextMesh>().text = "Denied";
	}

	/// <summary>
	/// Loads the score.
	/// </summary>
	/// <returns>The score.</returns>
	public static float loadScore()
	{
		if(!SaveSystem.hasObject(GameTimeController.BEST_TIME_KEY))
		{
			SaveSystem.saveFloat(GameTimeController.BEST_TIME_KEY, 0);

			return SaveSystem.loadFloat(GameTimeController.BEST_TIME_KEY);

		}
		else
			return SaveSystem.loadFloat(GameTimeController.BEST_TIME_KEY);
	}

}
