using UnityEngine;

namespace Game.Items {
	public class ItemStack<T>: AbstractItemStack where T: Item {
		[SerializeField] private T _item;

		public override Item AbstractItem => _item;
		public T Item => _item;
	}
}