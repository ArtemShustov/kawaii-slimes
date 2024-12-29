using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Items/Weapon")]
	public class Weapon: Item {
		[SerializeField] private GameObject _prefab;
		[SerializeField] private int _baseDamage;
		
		public GameObject Prefab => _prefab;
		public int Damage => _baseDamage;
	}
}