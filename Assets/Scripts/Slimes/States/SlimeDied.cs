using Game.Character;
using Game.Events;
using Game.Pools.Effects;
using UnityEngine;

namespace Game.Slimes.States {
	public class SlimeDied: CharacterState {
		[SerializeField] private EffectPool _effect;
		[SerializeField] private float _destroyDelay = 0f;
		
		public override void OnUpdate(float deltaTime) { }
		public override async void OnEnter() {
			StateMachine.Animator.SetIsDead(true);
			await Awaitable.WaitForSecondsAsync(_destroyDelay);
			
			_effect.Get().PlayAt(StateMachine.Controller.transform.position);
			EventBus<SlimeKilledEvent>.Raise(new SlimeKilledEvent());
			Destroy(StateMachine.gameObject);
		}
		public override void OnExit() {
			StateMachine.Animator.SetIsDead(false);
		}
	}
}