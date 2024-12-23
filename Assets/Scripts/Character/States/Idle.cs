using UnityEngine;

namespace Game.Character.States {
	public class Idle: CharacterState {
		[Header("State settings")]
		[SerializeField] private CharacterState _walkingState;
		[Header("Additional transition")]
		[SerializeField] private Transitions _transitions;
		
		private void OnAnimatorMove() {
			StateMachine.Controller.Move(StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime);
		}

		public override void OnUpdate(float deltaTime) {
			if (StateMachine.Input.Move.sqrMagnitude > 0) {
				StateMachine.Change(_walkingState);
				return;
			}
			_transitions.CheckAll();
		}
		public override void OnEnter() {
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			_transitions.StartTracking();
		}
		public override void OnExit() {
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			_transitions.StopTracking();
		}
	}
}