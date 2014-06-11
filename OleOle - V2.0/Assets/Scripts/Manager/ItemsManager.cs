using UnityEngine;
using System.Collections;

public class ItemsManager : MonoBehaviour 
{
	private static Items _item; 

	public static Items getItemsUtilities(ItemsType itemType)
	{
		_item = new Items(); 

		if(itemType == ItemsType.blackSuitcase)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		else if(itemType == ItemsType.mother)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		else if(itemType == ItemsType.rocket)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		else if(itemType == ItemsType.soap)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		else if(itemType == ItemsType.whistle)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		else if(itemType == ItemsType.redCard)
		{
			_item.items(0, 1, itemType);
		}
		else if(itemType == ItemsType.life)
		{
			_item.items(0, 1, itemType);
		}
		else if(itemType == ItemsType.stretcher)
		{
			_item.items(0, getTimeItem(0, itemType), itemType);
		}
		return _item;
	}

	public static int getMoneyItem( int _level, ItemsType _item )
	{
		if(_item == ItemsType.blackSuitcase)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else if(_item == ItemsType.mother)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else if(_item == ItemsType.rocket)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else if(_item == ItemsType.soap)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else if(_item == ItemsType.stretcher)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else if(_item == ItemsType.whistle)
		{
			if(_level == 0)
				return 1000;
			else if(_level == 1)
				return 2000;
			else if(_level == 2)
				return 3000;
			else if(_level == 3)
				return 4000;
			else if(_level == 4)
				return 5000;
			return -1;
		}
		else
			return 0;
	}
	
	public static float getTimeItem( int _level, ItemsType _item )
	{
		if(_item == ItemsType.blackSuitcase)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else if(_item == ItemsType.mother)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else if(_item == ItemsType.rocket)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else if(_item == ItemsType.soap)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else if(_item == ItemsType.stretcher)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else if(_item == ItemsType.whistle)
		{
			if(_level == 0)
				return 5;
			else if(_level == 1)
				return 5;
			else if(_level == 2)
				return 5;
			else if(_level == 3)
				return 5;
			else if(_level == 4)
				return 5;
			return -1;
		}
		else
			return 0;
	}

}
