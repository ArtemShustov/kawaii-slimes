using Core.Items;
using Game.Items;
using UnityEngine;

namespace Game {
	public class SpawnDroppedItem: MonoBehaviour {
		[SerializeField] private int _count = 1;
		[SerializeField] private Item _item;
		[SerializeField] private DroppedItemFactory _factory;

		private void Awake() {
			Spawn();
			Destroy(this);
		}

		public void Spawn() {
			_factory.Spawn(transform, new CountableItemStack(_item, _count));
		}
	}
}