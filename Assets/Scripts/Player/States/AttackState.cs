using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	public class AttackState: CharacterState {
		[Header("Settings")]
		[SerializeField] private string _attackTrigger = "Attack";
		[SerializeField] private AttackAnimationCallback _callback;
		[SerializeField] private AttackArea _attackArea;
		[Header("Transitions")]
		[SerializeField] private AbstractCharacterState _idle;
		[SerializeField] private AttackTransition _incoming;
		[SerializeField] private Transitions _outgoing;
		
		public override void SetStateMachine(CharacterStateMachine character) {
			base.SetStateMachine(character);
			_incoming.SetCharacter(StateMachine);
		}
		
		public override AbstractTransition GetDefaultTransition() => _incoming;
		
		private void OnAttack() {
			_attackArea.Attack();
		}
		private void OnAnimationEnded() {
			StateMachine.Change(_idle);
		}
		private void OnAnimatorMove() {
			var movement = StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime;
			StateMachine.Controller.Move(movement);
		}
		public override void OnUpdate(float deltaTime) {
			_outgoing.CheckAll();
		}
		public override void OnEnter() {
			_outgoing.StartTracking();
			
			_callback.OnCallback += OnAttack;
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			StateMachine.Animator.AnimationEndedCallback += OnAnimationEnded;
			
			StateMachine.Animator.SetTrigger(_attackTrigger);
		}
		public override void OnExit() {
			_callback.OnCallback -= OnAttack;
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			StateMachine.Animator.AnimationEndedCallback -= OnAnimationEnded;
			
			_outgoing.StopTracking();
		}
	}
}