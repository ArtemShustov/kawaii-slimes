using UnityEngine;

namespace Game.Character.States {
	public class Walk: CharacterState {
		[Header("State settings")]
		[SerializeField] private float _rotateSpeed = 10;
		[SerializeField] private CharacterState _idleState;
		[Header("Additional transition")]
		[SerializeField] private Transitions _transitions;
		
		private void OnAnimatorMove() {
			StateMachine.Controller.Move(StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime);
		}
		
		public override void OnUpdate(float deltaTime) {
			var moveDirection = StateMachine.Input.GetRelatedMove();
			
			if (moveDirection.sqrMagnitude == 0) {
				StateMachine.Change(_idleState);
				return;
			}
			if (_transitions.CheckAll()) {
				return;
			}
			
			var targetRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.y));
			StateMachine.Controller.transform.rotation = Quaternion.Slerp(
				StateMachine.Controller.transform.rotation, 
				targetRotation, 
				deltaTime * _rotateSpeed
			);
		}
		public override void OnEnter() {
			StateMachine.Animator.SetIsWalking(true);
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			_transitions.StartTracking();
		}
		public override void OnExit() {
			StateMachine.Animator.SetIsWalking(false);
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			_transitions.StopTracking();
		}
	}
}