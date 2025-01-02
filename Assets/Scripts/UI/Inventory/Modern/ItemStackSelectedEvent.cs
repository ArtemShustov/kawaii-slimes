using Core.Events;
using Core.Items;

namespace Game.UI.Inventory.Modern {
	public class ItemStackSelectedEvent: IGameEvent {
		public AbstractItemStack Stack { get; private set; }

		public ItemStackSelectedEvent(AbstractItemStack stack) {
			Stack = stack;
		}
	}
}