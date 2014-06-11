using UnityEngine;
using System.Collections;

public abstract class SceneryManager : MonoBehaviour {

	public Vector2 position;

	public abstract void instanciateScenery(ObjectMovement objectMovement);

}