using Core.Items;
using UnityEngine;

namespace Game.UI.Inventory.StackView {
	public class ItemStackView: MonoBehaviour {
		[SerializeField] private ItemStackViewFeature[] _features;
		private AbstractItemStack _itemStack;

		public AbstractItemStack Stack => _itemStack;
		
		public void SetStack(AbstractItemStack itemStack) {
			_itemStack = itemStack;
			foreach (var feature in _features) {
				feature.Apply(_itemStack);
			}
		}
	}
}