using Core.Events;
using Core.Items;
using UnityEngine;

namespace Game.Items {
	public class DroppedItemFactory: MonoBehaviour {
		[Header("Settings")]
		[SerializeField] private bool _randomRotation = true;
		[Header("Components")]
		[SerializeField] private DroppedItem _defaultPrefab;
		[SerializeField] private Transform _root;

		public DroppedItem Spawn(AbstractItemStack stack, Vector3 position) {
			var prefab = GetPrefab(stack);
			var instance = Instantiate(prefab, _root);
			instance.transform.position = position;
			if (_randomRotation) {
				instance.transform.rotation = Random.rotation;
			}
			instance.SetStack(stack);
			ApplyCustomData(instance);
			return instance;
		}
		protected virtual void ApplyCustomData(DroppedItem instance) {}

		private DroppedItem GetPrefab(AbstractItemStack stack) {
			if (stack.AbstractItem is IHasDroppedModel item) {
				var customPrefab = item.GetDroppedPrefab();
				if (customPrefab != null) {
					return customPrefab;
				}
			}
			return _defaultPrefab;
		}

		private void OnItemDropped(ItemDroppedEvent gameEvent) {
			Spawn(gameEvent.Stack, gameEvent.Position);
		}
		private void OnEnable() {
			EventBus<ItemDroppedEvent>.Event += OnItemDropped;
		}
		private void OnDisable() {
			EventBus<ItemDroppedEvent>.Event -= OnItemDropped;
		}
	}
}