using Core.Items;
using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Items/Hat")]
	public class CommonItem: Item {
		[SerializeField] private GameObject _prefab;
		
		public GameObject Prefab => _prefab;

		public override AbstractItemStack GetStack() {
			return new CountableItemStack(this, 1);
		}
	}
}