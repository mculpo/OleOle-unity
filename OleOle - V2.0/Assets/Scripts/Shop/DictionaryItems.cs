using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DictionaryItems : MonoBehaviour
{
	public static Dictionary<ItemsType, Items> items = new Dictionary<ItemsType, Items>();

	public static ArrayList listItems = new ArrayList();

	public static event Action initItems;
	
	private static string saveListName = "listItensSave";

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
		init();
		WalletController.addCoins(1200000);
	}

	
	/// <summary>
	/// Init this instance.
	/// </summary>
	public static void init()
	{
		if(!SaveSystem.hasObject(saveListName))
			createList();

		loadItems();

		loadDictionary();
		
		//playInitItems();
	}

	public static void playInitItems()
	{
		initItems();
	}

	/// <summary>
	/// Saves the items.
	/// </summary>
	public static void saveItems()
	{
		SaveSystem.save(saveListName, listItems);
	}



	/// <summary>
	/// Loads the items.
	/// </summary>
	public static void loadItems()
	{
		if(SaveSystem.hasObject(saveListName))
			listItems = (ArrayList)SaveSystem.load(saveListName, typeof(ArrayList));
	}



	/// <summary>
	/// Loads the dictionary.
	/// </summary>
	public static void loadDictionary()
	{
		if(items == null)
		{
			foreach( Items _items in listItems )
			{
				items.Add(_items.Item, _items);
			}
		}
	}




	/// <summary>
	/// Realoads the dictionary.
	/// </summary>
	public static void realoadDictionary()
	{
		items.Clear();
		loadDictionary();
	}




	/// <summary>
	/// Gets the value.
	/// </summary>
	/// <returns>The value.</returns>
	/// <param name="itemsType">Items type.</param>
	public static float getValue( ItemsType itemsType )
	{
		Items _item; 

		items.TryGetValue(itemsType, out _item);

		return _item.Value;
	}




	/// <summary>
	/// Gets the level.
	/// </summary>
	/// <returns>The level.</returns>
	/// <param name="itemsType">Items type.</param>
	public static int getLevel( ItemsType itemsType )
	{
		Items _item; 
		
		items.TryGetValue(itemsType, out _item);
		
		return _item.Level;
	}




	/// <summary>
	/// Gets the type.
	/// </summary>
	/// <returns>The type.</returns>
	/// <param name="itemsType">Items type.</param>
	public static ItemsType getType( ItemsType itemsType )
	{
		Items _item; 
		
		items.TryGetValue(itemsType, out _item);
		
		return _item.Item;
	}


	/// <summary>
	/// Levels up.
	/// </summary>
	/// <param name="_item">_item.</param>
	public static void LevelUp( Items _item )
	{
		
		_item.Level++;

		_item.Value = ItemsManager.getTimeItem(_item.Level, _item.Item);
		
		int index = 0;

		ArrayList _items = new ArrayList();

			foreach(Items item in listItems)
			{
				if(item.Item == _item.Item)
					_items.Add(_item);
				else
					_items.Add(item);
			}

		listItems = _items;

		saveItems();

		realoadDictionary();
	}



	/// <summary>
	/// Creates the list.
	/// </summary>
	private static void createList()
	{
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.rocket));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.mother));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.soap));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.blackSuitcase));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.whistle));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.life));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.redCard));
		listItems.Add(ItemsManager.getItemsUtilities(ItemsType.stretcher));

		saveItems();
	}
}
