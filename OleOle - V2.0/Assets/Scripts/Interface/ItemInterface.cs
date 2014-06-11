using UnityEngine;
using System.Collections;

public class ItemInterface : MonoBehaviour 
{
	public ItemsType itemType; 

	public SpriteRenderer imageRender;

	public TextMesh value;

	public GameObject Buy;

	public Items items;

	void Start()
	{
		initItems();
	}

	void OnEnable()
	{
		TouchController.onTouchEvent += onTouchEvent;
		DictionaryItems.initItems += initItems;
	}
	
	void OnDisable()
	{
		TouchController.onTouchEvent -= onTouchEvent;
		DictionaryItems.initItems -= initItems;
	}

	void initItems ()
	{
		init();
	}

	void onTouchEvent (string obj)
	{
		Buy.name = items.Item.ToString();

		if(obj == Buy.name)
		{
			if(TouchController.collider.tag != "Utilits")
				CreateController.shareCreate().createBuyLevelUp(this);
			else
				CreateController.shareCreate().createBuyUtilits(this);
		}
	}

	void init()
	{
		foreach( Items _items in DictionaryItems.listItems)
		{
			if( itemType == _items.Item )
			{
				items = _items;
			}
		}
	
		if(items.Level >= 4)
		{
			value.text = "FULL";

			Buy.SetActive(false);
		}

		else
		{
			value.text = ItemsManager.getMoneyItem(items.Level, items.Item).ToString();
		}
	}
}
