using UnityEngine;

namespace Game.Items {
	public class Hat: Item {
		[SerializeField] private GameObject _prefab;
		
		public GameObject Prefab => _prefab;
	}
}