using Core.Character;
using Game.Pools.Effects;
using UnityEngine;

namespace Game.Slimes.States {
	public class DiedState: AbstractCharacterState {
		[Header("Settings")]
		[SerializeField] private EffectPool _effect;
		
		public override void OnUpdate(float deltaTime) { }
		public override void OnEnter() {
			_effect.Get().PlayAt(StateMachine.gameObject.transform.position);
			Destroy(StateMachine.gameObject);
		}
		public override void OnExit() { }
	}
}