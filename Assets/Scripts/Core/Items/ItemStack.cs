using System;
using UnityEngine;

namespace Core.Items {
	[Serializable]
	public class ItemStack<T>: AbstractItemStack where T: Item {
		[field: SerializeField] public T Item { get; protected set; }

		public ItemStack(T item) {
			Item = item;
		}

		public override Item AbstractItem => Item;
	}
}