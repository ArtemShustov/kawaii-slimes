using UnityEngine;

namespace Game.Character.States {
	public class Damaged: CharacterStateWithTransition {
		[Header("State settings")]
		[SerializeField] private float _timer = 2;
		[SerializeField] private CharacterState _nextState;
		[SerializeField] private CharacterState _diedState;
		[SerializeField] private Health _health;
		[Header("Default transition")]
		[SerializeField] private DamagedTransition _transition;

		public void RotateTo(GameObject target) {
			Vector3 direction = target.transform.position - StateMachine.Controller.transform.position;
			direction.y = 0;

			if (direction != Vector3.zero) {
				Quaternion targetRotation = Quaternion.LookRotation(direction);
				StateMachine.Controller.transform.rotation = targetRotation;
			}
		}

		public override void SetCharacter(CharacterStateMachine character) {
			base.SetCharacter(character);
			_transition.Init(character, this);
		}
		public override Transition GetDefaultTransition() {
			return _transition;
		}

		private void OnAnimatorMove() {
			StateMachine.Controller.Move(StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime);
		}

		public override void OnUpdate(float deltaTime) { }
		public override async void OnEnter() {
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			
			StateMachine.Animator.PlayDamaged();
			await Awaitable.WaitForSecondsAsync(_timer);

			if (_health.Value <= 0) {
				StateMachine.Change(_diedState);
				return;
			}
			StateMachine.Change(_nextState);
		}
		public override void OnExit() {
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
		}
	}
}