using UnityEngine;
using System.Collections;

public class CreateController : MonoBehaviour 
{
	public GameObject 	Menu,
					  	Configuration,
						Shop,
						Statistically,
						Credits,
						GameOver,
						Pause,
						LevelUp,
						Utilits,
						Accessories,
						BuyLevelUp,
						BuyUtilits,
						BuyCoin,
						WarningCoin;

	private static Transform myTransform;
	
	void Start()
	{
		myTransform = this.transform;
	}

	void createMenu()
	{
		InstanceController.createObject ( Menu, Menu.transform.position, Menu.transform.rotation );
	}
	void createConfiguration()
	{
		InstanceController.createObject( Configuration, Configuration.transform.position, Configuration.transform.rotation );
	}
	void createShop()
	{
		InstanceController.createObject( Shop, Shop.transform.position, Shop.transform.rotation );

		this.createLevelUp();

	}
	void createStatistically()
	{
		InstanceController.createObject( Statistically, Statistically.transform.position, Statistically.transform.rotation );
	}
	void createCredits()
	{
		InstanceController.createObject( Credits, Credits.transform.position, Credits.transform.rotation );
	}
	void createGameOver()
	{
		InstanceController.createObject( GameOver, GameOver.transform.position, GameOver.transform.rotation);
	}
	void createPause()
	{
		InstanceController.createObject( Pause, Pause.transform.position, Pause.transform.rotation );
	}

	#region STORE CONTROLLER

	void createBuyCoins()
	{
		GameObject _obj = InstanceController.createObject(BuyCoin, BuyCoin.transform.position, BuyCoin.transform.rotation) as GameObject;

		_obj.transform.parent = GameObject.Find("_Manager").transform;

		TouchController.layerMask = LayerMask.NameToLayer("Default");

	}

	void createLevelUp()
	{
		GameObject _obj = InstanceController.createObject( LevelUp, LevelUp.transform.position , LevelUp.transform.rotation ) as GameObject;

		_obj.transform.parent = GameObject.Find("_Manager").transform;

		_obj.name = "_box";
	}
	void createUtilits()
	{
		GameObject _obj = InstanceController.createObject( Utilits,  Utilits.transform.position, Utilits.transform.rotation ) as GameObject;

		_obj.transform.parent = GameObject.Find("_Manager").transform;

		_obj.name = "_box";
	}
	void createAccessories()
	{
		GameObject _obj = InstanceController.createObject( Accessories,  Accessories.transform.position, Accessories.transform.rotation ) as GameObject;

		_obj.transform.parent = GameObject.Find("_Manager").transform;

		_obj.name = "_box";
	}

	public void createBuyLevelUp( ItemInterface _itemInformation)
	{
		GameObject _obj = InstanceController.createObject(BuyLevelUp, BuyLevelUp.transform.position, BuyLevelUp.transform.rotation) as GameObject;

		_obj.GetComponent<BuyInterface>().ItemsInformation = _itemInformation;

		TouchController.layerMask = LayerMask.NameToLayer("Layer2");
	}

	public void createBuyUtilits( ItemInterface _itemInformation)
	{
		GameObject _obj = InstanceController.createObject(BuyUtilits, BuyUtilits.transform.position, BuyUtilits.transform.rotation) as GameObject;
		
		_obj.GetComponent<BuyInterface>().ItemsInformation = _itemInformation;
		
		TouchController.layerMask = LayerMask.NameToLayer("Layer2");
	}

	public void createWarningCoin()
	{
		InstanceController.createObject(WarningCoin, WarningCoin.transform.position, WarningCoin.transform.rotation);

		TouchController.layerMask = LayerMask.NameToLayer("Layer3");
	}

	#endregion
	public void createScene(string name)
	{
		if(name == "Shop")
		{
			this.createShop();

			StoreInterface.updateCoin();

		}
		else if(name == "Opcoes")
		{
			this.createConfiguration();
		}
		else if(name == "Menu")
		{
			this.createMenu();
		}
		else if(name == "cred")
		{
			this.createCredits();
		}
		else if(name == "Level-UP")
		{
			this.createLevelUp();
		}
		else if(name == "Utilits")
		{
			this.createUtilits();
		}
		else if(name == "Accessories")
		{
			this.createAccessories();
		}
		else if(name == "Coins")
		{
			this.createBuyCoins();
		}
	}

	public static CreateController shareCreate()
	{
		return GameObject.Find(myTransform.name).GetComponent<CreateController>();
	}
}
