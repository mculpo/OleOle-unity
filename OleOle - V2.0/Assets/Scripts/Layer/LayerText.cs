using UnityEngine;
using System.Collections;

public class LayerText : MonoBehaviour {

	public string nome;
	public int sortLayer;
	
	void Start ()
	{
		// Set the sorting layer of the textMesh.
		renderer.sortingLayerName = nome;
		renderer.sortingOrder = sortLayer;
	}
}
