using UnityEngine;
using System.Collections;

public class TransactionLayerSceneryListener : LayerSceneryListener {

#region events
	public static event System.Action onStartTransactionSceneryEvent;
	public static event System.Action<ObjectMovement> onBecameVisibleTransactionSceneryEvent;
#endregion

	void Start () {

		onStartTransactionSceneryEvent();

	}

	protected override void onBecameVisible(){
		base.onBecameVisible();

		onBecameVisibleTransactionSceneryEvent(objectMovement);
		
	}

}