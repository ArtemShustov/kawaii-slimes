using Core.Items;
using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Factories/Dropped item")]
	public class DroppedItemFactory: ScriptableObject {
		[SerializeField] private DroppedItem _defaultPrefab;

		public DroppedItem Spawn(Transform root, AbstractItemStack stack) {
			var prefab = GetPrefab(stack);
			var instance = Instantiate(prefab, root);
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
	}
}