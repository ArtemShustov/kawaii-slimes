using UnityEngine;

namespace Core.Items {
	public abstract class Item: ScriptableObject {
		[SerializeField] private Sprite _icon;
		
		public Sprite Icon => _icon;

		public virtual AbstractItemStack GetStack() {
			return new CountableItemStack(this);
		}
	}
}