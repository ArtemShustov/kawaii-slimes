using Core.Events;
using Core.Items;
using Game.UI.Inventory;
using Game.UI.Inventory.StackView;
using UnityEngine;

namespace Game.UI {
	public class ItemCollectingLog: MonoBehaviour {
		[SerializeField] private ItemStackView _prefab;
		[SerializeField] private Transform _container;

		private void OnItemCollected(ItemCollectedByPlayerEvent gameEvent) {
			var view = Instantiate(_prefab, _container);
			view.SetStack(gameEvent.Stack);
		}
		private void OnEnable() {
			EventBus<ItemCollectedByPlayerEvent>.Event += OnItemCollected;
		}
		private void OnDisable() {
			EventBus<ItemCollectedByPlayerEvent>.Event -= OnItemCollected;
		}
	}
}