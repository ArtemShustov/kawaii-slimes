using System;
using UnityEngine;

namespace Core.Items {
	[Serializable]
	public class CountableItemStack: ItemStack<CountableItem> {
		[SerializeField] private int _count;

		public int Count => _count;
		
		public CountableItemStack(CountableItem item, int count = 1): base(item) {
			_count = count;
		}

		public void SetCount(int count) {
			_count = Mathf.Max(0, count);
		}
		public void Add(int count) {
			_count += Mathf.Max(0, count);
		}
		public bool Take(int count) {
			count = Mathf.Max(0, count);
			if (CanTake(count)) {
				_count -= count;
				return true;
			}
			return false;
		}
		public bool CanTake(int count) {
			count = Mathf.Max(0, count);
			return _count >= count;
		}
	}
}