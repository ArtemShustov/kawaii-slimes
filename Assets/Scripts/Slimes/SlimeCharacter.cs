using Core.Character;
using Core.Items;
using Game.Items;
using Game.Pools.Effects;
using UnityEngine;

namespace Game.Slimes {
	public class SlimeCharacter: AbstractCharacter {
		[Header("Settings")]
		[SerializeField] private EffectPool _effect;
		[SerializeField] private int _count = 1;
		[SerializeField] private CountableItem _loot;
		[SerializeField] private DroppedItemFactory _factory;
		[Header("Components")]
		[SerializeField] private AiInput _input;

		public void SetNoAi() {
			_input.enabled = false;
		}

		public void OnDied() {
			_effect.Get().PlayAt(transform.position);
			_factory.Spawn(null, _loot.GetStack(_count)).transform.position = transform.position;
			Destroy(gameObject);
		}
	}
}