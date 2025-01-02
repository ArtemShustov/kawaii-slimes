using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Items {
	public class Inventory: MonoBehaviour {
		[SerializeField] private List<AbstractItemStack> _items = new List<AbstractItemStack>();

		public IReadOnlyList<AbstractItemStack> Items => _items;
		
		public void Add(AbstractItemStack stack) {
			if (stack is CountableItemStack countableStack) {
				if (countableStack.Count <= 0) {
					return;
				}
				if (TryGetCountableStackOf(countableStack.Item, out var existingStack)) {
					existingStack.SetCount(existingStack.Count + countableStack.Count);
					return;
				}
			}
			_items.Add(stack);
		}
		public bool CanTake(CountableItem item, int count) {
			if (TryGetCountableStackOf(item, out var stack)) {
				return stack.Count >= count;
			}
			return false;
		}
		public bool Take(CountableItem item, int count) {
			count = Mathf.Abs(count);
			if (TryGetCountableStackOf(item, out var stack) && stack.Count >= count) {
				stack.SetCount(stack.Count - count);
				if (stack.Count == 0) {
					_items.Remove(stack);
				}
				return true;
			}
			return false;
		}
		public int GetCountOf(CountableItem item) {
			return TryGetCountableStackOf(item, out var stack) ? stack.Count : 0;
		}

		public bool TryGetCountableStackOf(CountableItem item, out CountableItemStack result) {
			if (TryGetStackOf(item, out var stack) && stack is CountableItemStack countableStack) {
				result = countableStack;
				return true;
			}
			result = null;
			return false;
		}
		private bool TryGetStackOf(Item item, out AbstractItemStack stack) {
			stack = GetStackOf(item);
			return stack != null;
		}
		private AbstractItemStack GetStackOf(Item item) {
			return _items.FirstOrDefault(stack => stack.AbstractItem == item);
		}
	}
}