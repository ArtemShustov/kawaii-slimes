using Core.Events;
using Core.Items;
using Game.Items;
using UnityEngine;

namespace Game {
	public class SpawnDroppedItem: MonoBehaviour {
		[SerializeField] private int _count = 1;
		[SerializeField] private CountableItem _item;

		private void Start() {
			Spawn();
			Destroy(this);
		}

		public void Spawn() {
			var stack = new CountableItemStack(_item, _count);
			EventBus<ItemDroppedEvent>.Raise(new ItemDroppedEvent(stack, transform.position));
		}
	}
}