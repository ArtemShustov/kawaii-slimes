using Core.UI.Panels;
using UnityEngine;

namespace Game.UI.Inventory {
	public class InitPlayerInventoryPanel: MonoBehaviour {
		[SerializeField] private PlayerInventoryPanel _panel;
		[SerializeField] private PanelSwitcher _switcher;

		private void Awake() {
			_switcher.AddPanel(_panel);
		}
	}
}