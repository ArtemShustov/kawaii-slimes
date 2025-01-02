using Core.Events;
using Game.UI.Inventory.StackView;

namespace Game.UI.Inventory {
	public class ItemViewSelectedEvent: IGameEvent {
		public ItemStackView View { get; private set; }

		public ItemViewSelectedEvent(ItemStackView view) {
			View = view;
		}
	}
}