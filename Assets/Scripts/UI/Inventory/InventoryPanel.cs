using Core.UI.Panels;
using UnityEngine;

namespace Game.UI.Inventory {
	public class InventoryPanel: UIPanel {
		[SerializeField] private Core.Items.Inventory _inventory;
		[SerializeField] private InventoryView[] _inventoryViews;

		private void Awake() {
			foreach (var view in _inventoryViews) {
				view.SetInventory(_inventory);
			}
		}

		public void SetInventory(Core.Items.Inventory inventory) {
			_inventory = inventory;
			foreach (var view in _inventoryViews) {
				view.SetInventory(_inventory);
			}
		}
	}
}