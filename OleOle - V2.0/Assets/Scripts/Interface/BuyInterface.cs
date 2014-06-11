using UnityEngine;
using System.Collections;

public class BuyInterface : MonoBehaviour 
{
	private ItemInterface itemInformation;

	public SpriteRenderer image;

	public TextMesh value,
					descrition,
					name;

	public GameObject[] level;

	void OnEnable()
	{
		TouchController.onTouchEvent += onTouchEvent;
		WarningCoinInterface.buyCoin += buyCoin;
	}
	
	void OnDisable()
	{
		TouchController.onTouchEvent -= onTouchEvent;
		WarningCoinInterface.buyCoin -= buyCoin;
	}
	
	void Start()
	{
		this.init();
	}

	void buyCoin ()
	{
		this.close();
	}

	void onTouchEvent (string obj)
	{
		if(obj == "Buy_Item")
		{
			if(TouchController.collider.tag != "Utilits")
			{
				if(itemInformation.items.Level <= 4)
				{
					BuyManager.buyItemLevelUp(itemInformation.items, System.Convert.ToSingle(itemInformation.value.text));

					if(itemInformation.items.Level >= 4)
					{
						Destroy(this.gameObject);

						TouchController.layerMask = LayerMask.NameToLayer("Default");
					}

					this.init();
				}
			}
			else
			{
				BuyManager.buyItemUtilits(itemInformation.items, System.Convert.ToSingle(itemInformation.value.text));
			}
		}
		else if(obj == "Close")
		{
			this.close();

			TouchController.layerMask = LayerMask.NameToLayer("Default");
		}
	}

	void init()
	{
		this.value.text = ItemsManager.getMoneyItem(itemInformation.items.Level, itemInformation.items.Item).ToString();

		this.image.sprite = this.itemInformation.imageRender.sprite;

		this.levelInformation();
	}

	void close()
	{
		Destroy(this.gameObject);
	}

	void levelInformation()
	{
		if(transform.tag != "Utilits")
		{
			int _level = this.itemInformation.items.Level;

			for(int i = 1; i <= _level; i++)
			{
				level[i - 1].SetActive(true);
			}
		}
	}

	public ItemInterface ItemsInformation 
	{
		get
		{
			return this.itemInformation;
		}
		set 
		{
			itemInformation = value;
		}
	}
}
