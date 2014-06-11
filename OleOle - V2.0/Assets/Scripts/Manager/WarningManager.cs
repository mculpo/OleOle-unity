using UnityEngine;
using System.Collections;

public class WarningManager : MonoBehaviour
{
	public static void noMoney()
	{
		CreateController.shareCreate().createWarningCoin();
	}
}
