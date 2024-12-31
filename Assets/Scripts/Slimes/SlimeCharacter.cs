using Core.Character;
using Core.Events;
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
		[Header("Components")]
		[SerializeField] private AiInput _input;

		public void SetNoAi() {
			_input.enabled = false;
		}

		public void OnDied() {
			_effect.Get().PlayAt(transform.position);
			
			var stack = _loot.GetStack(_count);
			EventBus<ItemDroppedEvent>.Raise(new ItemDroppedEvent(stack, transform.position));
			
			Destroy(gameObject);
		}
	}
}