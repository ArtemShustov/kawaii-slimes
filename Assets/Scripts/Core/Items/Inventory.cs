using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Items {
	public class Inventory: MonoBehaviour {
		[SerializeField] private List<AbstractItemStack> _items = new List<AbstractItemStack>();

		public IReadOnlyList<AbstractItemStack> Items => _items;
		
		public void Add(AbstractItemStack stack) {
			if (stack is ICountableStack countableStack && countableStack.Count <= 0) {
				return;
			}
			if (stack is ICountableStack newStack && TryGetCountableStackOf(stack.AbstractItem, out var existingStack)) {
				existingStack.SetCount(existingStack.Count + newStack.Count);
				return;
			}
			_items.Add(stack);
		}

		private bool TryGetCountableStackOf(Item item, out ICountableStack existingStack) {
			if (TryGetStackOf(item, out var stack) && stack is ICountableStack countableStack) {
				existingStack = countableStack;
				return true;
			}
			existingStack = null;
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