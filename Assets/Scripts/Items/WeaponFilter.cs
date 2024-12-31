using Core.Items;

namespace Game.Items {
	public class WeaponFilter: ItemStackFilter {
		public override bool Check(AbstractItemStack stack) {
			return stack is WeaponStack;
		}
	}
}