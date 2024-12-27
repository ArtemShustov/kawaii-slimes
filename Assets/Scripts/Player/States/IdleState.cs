using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	public class IdleState: CharacterState {
		[Header("Transitions")]
		[SerializeField] private IdleTransition _incoming;
		[SerializeField] private Transitions _outgoing;

		public override void SetStateMachine(CharacterStateMachine character) {
			base.SetStateMachine(character);
			_incoming.SetCharacter(StateMachine);
		}
		
		public override AbstractTransition GetDefaultTransition() => _incoming;
		
		private void OnAnimatorMove() {
			var movement = StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime;
			StateMachine.Controller.Move(movement);
		}
		public override void OnUpdate(float deltaTime) {
			_outgoing.CheckAll();
		}
		public override void OnEnter() {
			_outgoing.StartTracking();
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
		}
		public override void OnExit() {
			_outgoing.StopTracking();
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
		}
	}
}