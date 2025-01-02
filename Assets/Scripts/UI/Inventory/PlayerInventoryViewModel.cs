using Core.Items;
using Core.MVVM;
using Game.Items;
using Game.Player;

namespace Game.UI.Inventory {
	public class PlayerInventoryViewModel: IViewModel {
		public PlayerCharacter Player { get; private set; }
		public PlayerInventory Inventory { get; private set; }

		public WeaponStack PlayerWeapon => Player.WeaponSlot.Weapon;
		
		public PlayerInventoryViewModel(PlayerCharacter player, PlayerInventory inventory) {
			Player = player;
			Inventory = inventory;
		}

		public void EquipWeapon(WeaponStack stack) {
			Player.WeaponSlot.SetWeapon(stack);
		}
	}
}