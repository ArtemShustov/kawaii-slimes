using Core.Events;

namespace Core.Items {
	public class ItemCollectedByPlayerEvent: IGameEvent {
		private AbstractItemStack _stack;
		
		public AbstractItemStack Stack => _stack;

		public ItemCollectedByPlayerEvent(AbstractItemStack stack) {
			_stack = stack;
		}
	}
}