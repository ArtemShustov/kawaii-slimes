using UnityEngine;

namespace Game.Character.States {
	public class Attack: CharacterStateWithTransition {
		[Header("State settings")]
		[SerializeField] private AbstractCharacter _self;
		[SerializeField] private BoxCollider _attackArea;
		[SerializeField] private float _time = 2;
		[SerializeField] private AudioSource _source;
		[SerializeField] private CharacterState _nextState;
		[Header("Default transition")]
		[SerializeField] private AttackTransition _transition;
		
		private void AttackInArea() {
			_source.PlayOneShot(_source.clip);
			
			var contacts = Physics.OverlapBox(
				_attackArea.transform.position + _attackArea.center, 
				_attackArea.size / 2f
			);
			foreach (var contact in contacts) {
				if (contact.gameObject == _self?.gameObject) {
					continue;
				}
				if (contact.gameObject.TryGetComponent<IAttackable>(out var attackable)) {
					attackable.TakeDamage(_self, 1);
				}
			}
		}

		public override void SetCharacter(CharacterStateMachine character) {
			base.SetCharacter(character);
			_transition.Init(character, this);
		}
		public override AbstractTransition GetDefaultTransition() {
			return _transition;
		}

		private void OnAnimatorMove() {
			StateMachine.Controller.Move(StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime);
		}
		public override void OnUpdate(float deltaTime) { }
		public override async void OnEnter() {
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			StateMachine.Animator.AttackCallback += AttackInArea;
			StateMachine.Animator.PlayAttack();
			
			await Awaitable.WaitForSecondsAsync(_time);
			
			StateMachine.Change(_nextState);
		}
		public override void OnExit() {
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			StateMachine.Animator.AttackCallback -= AttackInArea;
		}
	}
}