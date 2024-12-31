using UnityEngine;

namespace Core.Items.Loot {
	[CreateAssetMenu(menuName = "Items/Loot table", order = -100)]
	public class LootTable: ScriptableObject {
		public AbstractItemStack[] GetRandom() => throw new System.NotImplementedException();
	}
}