using System.Collections.Generic;
using UnityEngine;

namespace Game.Items {
	public class Inventory: MonoBehaviour {
		[SerializeField] private List<AbstractItemStack> _items;

		public IReadOnlyList<AbstractItemStack> Items => _items;
		
		public void Add(AbstractItemStack item) {
			_items.Add(item);
		}
	}
}