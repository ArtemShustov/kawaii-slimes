using Core.UI.Panels;
using UnityEngine;

namespace Game.UI.Inventory.WeaponForge {
	public class InitWeaponForgePanel: MonoBehaviour {
		[SerializeField] private WeaponForgePanel _panel;
		[SerializeField] private PanelSwitcher _switcher;

		private void Awake() {
			_switcher.AddPanel(_panel);
		}
	}
}