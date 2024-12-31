using Core.Events;
using UnityEngine;

namespace Game.UI.Inventory.StackView {
	[RequireComponent(typeof(ItemStackView))]
	public class SelectedStackView: PlayerInventoryComponent {
		[SerializeField] private GameObject _root;
		private ItemStackView _view;

		private void Awake() {
			_view = GetComponent<ItemStackView>();
			_root.SetActive(false);
		}

		protected virtual void OnItemSelected(ItemSelectedEvent gameEvent) {
			_view.SetStack(gameEvent.View.Stack);
			_root.SetActive(true);
		}
		protected virtual void OnEnable() {
			EventBus<ItemSelectedEvent>.Event += OnItemSelected;
		}
		protected virtual void OnDisable() {
			EventBus<ItemSelectedEvent>.Event -= OnItemSelected;
			_root.SetActive(false);
		}
	}
}