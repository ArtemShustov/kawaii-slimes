using Core.Events;
using Core.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Inventory {
	public class ItemStackView: MonoBehaviour, IPointerClickHandler {
		[SerializeField] private ItemStackViewFeature[] _features;
		private AbstractItemStack _itemStack;

		public AbstractItemStack Stack => _itemStack;
		
		public void Bind(AbstractItemStack itemStack) {
			_itemStack = itemStack;
			foreach (var feature in _features) {
				feature.Apply(_itemStack);
			}
		}
		public void OnPointerClick(PointerEventData eventData) {
			EventBus<ItemSelectedEvent>.Raise(new ItemSelectedEvent(this));
		}
	}
}