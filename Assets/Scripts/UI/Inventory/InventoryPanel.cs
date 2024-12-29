using UnityEngine;

namespace Game.UI.Inventory {
	public class InventoryPanel: UIPanel {
		public override void Show() {
			base.Show();
			Debug.Log("InventoryPanel.Show()");
		}
	}
}