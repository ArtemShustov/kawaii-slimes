using Core.Items;
using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Items/Money")]
	public class Money: CountableItem {
		public override AbstractItemStack GetStack() {
			return new CountableItemStack(this, 0);
		}
	}
}