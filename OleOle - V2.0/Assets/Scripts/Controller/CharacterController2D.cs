using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),
                  typeof(Collider2D))]
public class CharacterController2D : MonoBehaviour {

	public Transform groundCheck;
	public LayerMask layerGroundType;

	private bool grounded = false,
				 facingRight = true;
	private float groundRadius = 0.2f;
	private Rigidbody2D rigid2d;

	void Start () {

		rigid2d = rigidbody2D;
	
	}

	void FixedUpdate () {

		this.grounded = Physics2D.OverlapCircle(this.groundCheck.position, this.groundRadius, this.layerGroundType);

		if(rigid2d.velocity.x > 0 && !facingRight){

			facingRight = !facingRight;

		}
		else if(rigid2d.velocity.x < 0 && facingRight){

			facingRight = !facingRight;

		}
	
	}

	public void move(Vector2 motion){

		rigid2d.velocity = motion;

	}

	public void jump(float force){

		rigid2d.AddForce(new Vector2(0, force));
		
	}

	public bool isGrounded {
		get {
			return this.grounded;
		}
	}
	
	public bool isFacingRight {
		get {
			return this.facingRight;
		}
	}
	
	public Vector2 motion {
		get {
			return this.rigid2d.velocity;
		}
	}

}