using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	public class WalkState: CharacterState {
		[Header("Settings")]
		[SerializeField] private float _rotateSpeed = 10f;
		[SerializeField] private string _isWalking = "IsWalking";
		[Header("Transitions")]
		[SerializeField] private WalkTransition _incoming;
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
			if (_outgoing.CheckAll()) {
				return;
			}
			
			var moveDirection = StateMachine.Input.GetRelatedMove();
			var targetRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.y));
			StateMachine.Controller.transform.rotation = Quaternion.Slerp(
				StateMachine.Controller.transform.rotation, 
				targetRotation, 
				deltaTime * _rotateSpeed
			);
		}
		public override void OnEnter() {
			_outgoing.StartTracking();
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			StateMachine.Animator.SetBool(_isWalking, true);
		}
		public override void OnExit() {
			_outgoing.StopTracking();
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			StateMachine.Animator.SetBool(_isWalking, false);
		}
	}
}