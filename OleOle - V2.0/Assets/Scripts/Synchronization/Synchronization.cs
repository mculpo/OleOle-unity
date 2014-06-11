using UnityEngine;
using System.Collections;

public class Synchronization : MonoBehaviour {

	public static void check() 
	{
		if(hasSynchronization())
		{
			deleteSynchronization();

			playSynchronization();
		}
	}

	public static void setSynchronization()
	{
		SaveSystem.saveInt("synchronization", 1);
	}

	private static bool hasSynchronization()
	{
		if(SaveSystem.hasObject("synchronization"))
		{

			return true;

		}
		else
		{

			return false;

		}

	}

	private static void deleteSynchronization()
	{

		SaveSystem.deleteObject("synchronization");

	}

	private static void playSynchronization()
	{
		
		int _value = SaveSystem.loadInt(GameTimeController.BEST_TIME_KEY);
		
		GPGController.instance.StartCoroutine(GPGController.submitScore(_value));
		
	}
}