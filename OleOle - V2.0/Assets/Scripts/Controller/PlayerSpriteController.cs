using UnityEngine;
using System.Collections;

public class PlayerSpriteController : MonoBehaviour {

	public Sprite[] sprites;

	private SpriteRenderer spriteRenderer;

	void OnEnable () {

		PlayerBehavior.changeColorEvent += changeColor;
		PlayerBehavior.changeSpriteEvent += changeSprite;

	}

	void OnDisable () {

		PlayerBehavior.changeColorEvent -= changeColor;
		PlayerBehavior.changeSpriteEvent -= changeSprite;

	}

	void Start () {

		spriteRenderer = GetComponent<SpriteRenderer>();
	
	}

	private void changeColor(Color color){

		spriteRenderer.color = color;
		
	}

	private void changeSprite(int index){
	
		spriteRenderer.sprite = sprites[index];

	}

}