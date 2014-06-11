using UnityEngine;
using System.Collections;

public class StoreCoinItem : MonoBehaviour 
{
	private bool release;

	public string id;

	void Start()
	{
		this.release = true;
	}

	public void init(string _id, string price)
	{
		this.id = _id;

		transform.FindChild("preco").GetComponent<TextMesh>().text = price;

	}
	public IEnumerator buyItem()
	{
		if(release)
		{

			transform.parent.GetComponent<Animator>().enabled = false;

			this.release = false;

			Transform _button = transform;

			Vector3 _scale = _button.localScale;

			_button.localScale = new Vector3(_button.localScale.x + 0.1f, _button.localScale.y + 0.1f, _button.localScale.z);
			
			yield return new WaitForSeconds(0.1f);
			
			_button.localScale = new Vector3(_scale.x , _scale.y , _scale.z);
			
			BillingManager.buyItem(this.id);

			BillingManager.consumeItem(this.id);

			this.release = true;

			transform.parent.GetComponent<Animator>().enabled = true;
		}
	}
}
