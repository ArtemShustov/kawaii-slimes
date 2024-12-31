using Core.Items;
using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Items/Hat")]
	public class Hat: Item {
		[SerializeField] private GameObject _prefab;
		
		public GameObject Prefab => _prefab;
	}
}