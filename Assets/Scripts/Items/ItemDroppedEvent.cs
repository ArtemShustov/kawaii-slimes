using Core.Events;
using Core.Items;
using UnityEngine;

namespace Game.Items {
	public class ItemDroppedEvent: IGameEvent {
		public AbstractItemStack Stack { get; private set; }
		public Vector3 Position { get; private set; }

		public ItemDroppedEvent(AbstractItemStack stack, Vector3 position) {
			Position = position;
			Stack = stack;
		}
	}
}