using UnityEngine;
using System.Collections;

public class PlayerBehavior : PlayerCollision {

	public Animator animator;

#region events
	public static event System.Action stopSceneryEvent;
	public static event System.Action<bool, float> moveCrowdEvent;
	public static event System.Action<Color> changeColorEvent;
	public static event System.Action<int> changeSpriteEvent;
#endregion

	protected bool isFixedSliping;
	protected CharacterController2D ownCharacterController;

	private static PlayerBehavior self;

	private CircleCollider2D circleCollider;
	private BoxCollider2D boxCollider;

	void Awake () {

		circleCollider = GetComponent<CircleCollider2D>();
		boxCollider = GetComponent<BoxCollider2D>();

		self = this;

	}

	protected virtual void Start () {

		ownCharacterController = GetComponent<CharacterController2D>();

	}

	protected override void stumble(){

		animator.SetTrigger("trupica");

		//moveCrowdEvent(false, 1.0f);

	}
	
	protected override void dead(bool isStumbling){

		if(isStumbling){

			animator.SetTrigger("trupicaMorre");

		}
		else{

			animator.SetTrigger("batemorre");

		}

		stopSceneryEvent();

		//moveCrowdEvent(true, -1.5f);
		
	}

	public void slip(bool parm){

		if(parm){

			animator.SetTrigger("escorrega");

		}

		rigidbody2D.isKinematic = parm;
				
		boxCollider.enabled = !parm;

		setTriggerCollisor(parm, parm);

	}

	public void fixedSlip(bool parm){

		animator.SetBool("escorregaBool", parm);

		isFixedSliping = parm;

		rigidbody2D.isKinematic = parm;
		
		boxCollider.enabled = !parm;
		
		setTriggerCollisor(parm, parm);
		
	}

	public void activeSelf(bool parm){

		gameObject.SetActive(parm);
		
	}

	public void setTriggerCollisor(bool boxParm, bool circleParm){

		boxCollider.isTrigger = boxParm;
		circleCollider.isTrigger = circleParm;
				
	}

	public void impulseBody(float force){

		rigidbody2D.velocity = Vector2.zero;
		ownCharacterController.jump(force);
		
	}

	public void darkenBody(bool parm){

		Color _color = new Color(0, 0, 0);

		if(!parm){

			_color = new Color(255, 255, 255);

		}

		changeColorEvent(_color);

	}

	public void changeLayer(int layer){

		gameObject.layer = layer;
		
	}

	public void changeTag(string tag){

		gameObject.tag = tag;

	}
	
	public void changeClothes(int index){

		changeSpriteEvent(index);
		
	}

	public void immunize(bool parm){

		if(parm){

			changeTag("Immunized");

		}
		else{

			changeTag("Player");

		}
		
		immunized = parm;
		
	}

	public static PlayerBehavior Get {
		get {
			return PlayerBehavior.self;
		}
	}

}