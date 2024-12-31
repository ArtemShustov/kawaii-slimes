using Core.Events;

namespace Core.Items {
	public class PlayerInventory: Inventory {
		private void OnItemCollected(ItemCollectedByPlayerEvent gameEvent) {
			base.Add(gameEvent.Stack);
		}
		private void OnEnable() {
			EventBus<ItemCollectedByPlayerEvent>.Event += OnItemCollected;
		}
		private void OnDisable() {
			EventBus<ItemCollectedByPlayerEvent>.Event -= OnItemCollected;
		}
	}
}