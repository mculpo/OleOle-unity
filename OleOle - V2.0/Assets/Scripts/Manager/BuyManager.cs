using UnityEngine;
using System.Collections;

public class BuyManager : MonoBehaviour
{

	public static void buyItemLevelUp( Items _item, float _moneyItem )
	{
		if(_moneyItem <= WalletController.getValue(ItemsType.coin))
		{
			WalletController.removeItems(ItemsType.coin , _moneyItem);

			DictionaryItems.LevelUp(_item);

			DictionaryItems.playInitItems();

			StoreInterface.updateCoin();
		}
		else 
		{
			WarningManager.noMoney();
		}
	}

	public static void buyItemUtilits( Items _item, float _moneyItem )
	{
		if(_moneyItem <= WalletController.getValue(ItemsType.coin))
		{
			WalletController.removeItems(ItemsType.coin , _moneyItem);
	
			foreach(Items _args  in DictionaryItems.listItems)
			{
				if(_args.Item == ItemsType.redCard)
				{
					if(_item.Item == ItemsType.redCard)
						_args.Level++;
				}
				else if(_args.Item == ItemsType.life)
				{
					if(_item.Item == ItemsType.life)
						_args.Level++;
				}
			}
		}
		else 
		{
			WarningManager.noMoney();
		}
	}

}
