using Game.Items;
using Game.UI.Inventory.StackView;
using UnityEngine;

namespace Game.UI.Inventory.Weapons {
	public class SelectedWeaponStackView: SelectedStackView {
		[SerializeField] private SelectedWeaponButton[] _buttons;

		protected override void OnItemSelected(ItemSelectedEvent gameEvent) {
			if (gameEvent.View.Stack is WeaponStack weaponStack) {
				base.OnItemSelected(gameEvent);
				foreach (var button in _buttons) {
					button.SetStack(weaponStack);
				}
			}
		}
	}
}