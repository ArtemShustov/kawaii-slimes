using Core.MVVM;
using Game.Items;
using Game.Player;

namespace Game.UI.Inventory {
	public class PlayerInventoryViewModel: IViewModel {
		public PlayerCharacter Character { get; private set; }
		public Core.Items.Inventory Inventory { get; private set; }

		public WeaponStack Weapon => Character.WeaponSlot.Weapon;
		
		public PlayerInventoryViewModel(PlayerCharacter character, Core.Items.Inventory inventory) {
			Character = character;
			Inventory = inventory;
		}

		public void EquipWeapon(WeaponStack stack) {
			Character.WeaponSlot.SetWeapon(stack);
		}
	}
}