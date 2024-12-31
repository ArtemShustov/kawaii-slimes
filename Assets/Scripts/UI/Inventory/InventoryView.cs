using System;
using Core.Items;
using Game.UI.Inventory.StackView;
using UnityEngine;

namespace Game.UI.Inventory {
	public class InventoryView: PlayerInventoryComponent {
		[Header("Settings")]
		[SerializeField] private bool _showOnEnable = true;
		[SerializeField] private ItemStackView _stackViewPrefab;
		[Header("Components")]
		[SerializeField] private ItemStackFilter _filter;
		[SerializeField] private Transform _container;
		private Core.Items.Inventory _inventory;

		public void Show() {
			Func<AbstractItemStack, bool> filter = _filter ? _filter.Check : (stack) => true;
			Show(filter);
		}
		public void Show(Func<AbstractItemStack, bool> filter) {
			Clear();
			if (_inventory == null) {
				return;
			}
			
			foreach (var stack in _inventory.Items) {
				if (filter.Invoke(stack)) {
					var instance = Instantiate(_stackViewPrefab, _container);
					instance.SetStack(stack);
				}
			}
		}
		private void Clear() {
			foreach (Transform child in _container) {
				Destroy(child.gameObject);
			}
		}

		public override void Bind(PlayerInventoryViewModel viewModel) {
			base.Bind(viewModel);
			_inventory = viewModel.Inventory;
		}

		private void OnEnable() {
			if (_showOnEnable) {
				Show();
			}
		}
	}
}