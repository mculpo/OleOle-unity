using UnityEngine;
using System.Collections;

public class Items
{
	private int level;
	private float value;
	private ItemsType item;

	public Items()
	{
		this.level = 0;
		this.value = 0;
		this.item = ItemsType.empty;
	}

	public Items (int level, float time, ItemsType item)
	{
		this.level = level;
		this.value = time;
		this.item = item;
	}

	public void items (int level, float time, ItemsType item)
	{
		this.level = level;
		this.value = time;
		this.item = item;
	}
	
	public int Level
	{
		get
		{
			return this.level;
		}
		set
		{
			level = value;
		}
	}

	public float Value
	{
		get
		{
			return this.value;
		}
		set
		{
			value = value;
		}
	}

	public ItemsType Item
	{
		get
		{
			return this.item;
		}
		set
		{
			item = value;
		}
	}
}
