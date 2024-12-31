using Core.Events;
using Core.Items;
using UnityEngine;

namespace Game.Items {
	public class PlayerItemCollector: MonoBehaviour {
		private void OnTriggerEnter(Collider other) {
			if (other.TryGetComponent<DroppedItem>(out var droppedItem)) {
				EventBus<ItemCollectedByPlayerEvent>.Raise(new ItemCollectedByPlayerEvent(droppedItem.Stack));
				Destroy(droppedItem.gameObject);
			}
		}
	}
}