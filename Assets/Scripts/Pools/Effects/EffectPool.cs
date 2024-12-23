using UnityEngine;

namespace Game.Pools.Effects {
	[CreateAssetMenu(menuName = "Pools/Effect")]
	public class EffectPool: AbstractPool<Effect> {
		[SerializeField] private Effect _prefab;
		
		protected override Effect GetNew(Transform root) {
			return Instantiate(_prefab, root);
		}
	}
}