using UnityEngine;
using System.Collections;
using System.Threading;

public class InstanceController : MonoBehaviour {

	public static Object createObject(Object prefab){

		return createObject(prefab, Vector2.zero);

	}

	public static Object createObject(Object prefab, Vector2 position){

		return createObject(prefab, position, Quaternion.identity);
		
	}

	public static Object createObject(Object prefab, Vector2 position, Quaternion rotation){

		return Instantiate(prefab, position, rotation);

	}

	private static Object instantiateOnThread(Object prefab, Vector2 position, Quaternion rotation){

		Object _object = Instantiate(prefab, position, rotation);

		return _object;

	}

}