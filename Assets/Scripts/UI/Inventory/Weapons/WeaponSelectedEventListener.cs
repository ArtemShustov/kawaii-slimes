using Game.Items;
using Game.UI.Inventory.StackView;
using UnityEngine;

namespace Game.UI.Inventory.Weapons {
	public class WeaponSelectedEventListener: ItemSelectedEventListener {
		[SerializeField] private WeaponButton[] _buttons;

		protected override void OnItemSelected(ItemViewSelectedEvent gameEvent) {
			if (gameEvent.View.Stack is WeaponStack weaponStack) {
				base.OnItemSelected(gameEvent);
				foreach (var button in _buttons) {
					button.SetStack(weaponStack);
				}
			}
		}
	}
}