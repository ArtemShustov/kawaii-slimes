using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	public class ArmedIdleState: AbstractCharacterState {
		[Header("Components")]
		[SerializeField] private WeaponSlot _weapon;
		[Header("Transitions")]
		[SerializeField] private AbstractCharacterState _next;
		[SerializeField] private Transitions _outgoing;
		
		private void OnAnimationEnded() {
			StateMachine.Change(_next);
		}

		public override void OnUpdate(float deltaTime) {
			_outgoing.CheckAll();
		}
		public override void OnEnter() {
			StateMachine.Animator.AnimationEndedCallback += OnAnimationEnded;
			_outgoing.StartTracking();
		}
		public override void OnExit() {
			StateMachine.Animator.AnimationEndedCallback -= OnAnimationEnded;
			_outgoing.StopTracking();
			_weapon.Hide();
		}
	}
}