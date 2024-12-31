using Core.Items;
using UnityEngine;

namespace Game.Items {
	public class DroppedItem: MonoBehaviour {
		private AbstractItemStack _stack;
		
		public AbstractItemStack Stack => _stack;

		public void SetStack(AbstractItemStack stack) {
			_stack = stack;
		}
	}
}