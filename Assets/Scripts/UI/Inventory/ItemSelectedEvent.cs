using Core.Events;
using Game.UI.Inventory.StackView;

namespace Game.UI.Inventory {
	public class ItemSelectedEvent: IGameEvent {
		public ItemStackView View { get; private set; }

		public ItemSelectedEvent(ItemStackView view) {
			View = view;
		}
	}
}