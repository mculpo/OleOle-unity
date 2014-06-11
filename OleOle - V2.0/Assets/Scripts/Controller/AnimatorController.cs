using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour 
{
	protected Animator anim;
	protected string nameScene;

	protected virtual void Start()
	{
		anim = GetComponent<Animator>();
		anim.enabled = true;
	}
}
