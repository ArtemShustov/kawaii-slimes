using Game.Items;

namespace Game.UI.Inventory.Weapons {
	public class SelectedWeaponButton: PlayerInventoryComponent {
		protected WeaponStack Weapon { get; private set; }

		public virtual void SetStack(WeaponStack stack) {
			Weapon = stack;
		}
	}
}