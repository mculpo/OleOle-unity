using UnityEngine;
using System.Collections;

public class InputWalletTest : MonoBehaviour {

	void Awake () {

		WalletController.addItems(ItemsType.blackSuitcase, 10);

		WalletController.addItems(ItemsType.rocket, 20);

		WalletController.addItems(ItemsType.stretcher, 20);

		WalletController.addItems(ItemsType.mother, 20);

		WalletController.addItems(ItemsType.soap, 20);
	
	}

}