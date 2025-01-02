using Core.Items;
using Game.Player;

namespace Game.UI.Inventory.WeaponForge {
	public class WeaponForgeViewModel: PlayerInventoryViewModel {
		public WeaponForgeViewModel(PlayerCharacter player, PlayerInventory inventory): base(player, inventory) { }

		public PlayerInventoryViewModel GetAsPlayerInventory() {
			return this;
		}
	}
}