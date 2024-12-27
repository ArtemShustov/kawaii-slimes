using System.Threading;
using Core.Character;
using Core.Character.Properties;
using Core.Events;
using Game.Player;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Game.Slimes.States {
	public class DamagedState: CharacterState {
		[Header("Settings")]
		[SerializeField] private string _damagedTrigger = "Damaged";
		[SerializeField] private float _time = 1;
		[Header("Components")]
		[SerializeField] private Health _health;
		[Header("Transitions")]
		[SerializeField] private AbstractCharacterState _died;
		[SerializeField] private AbstractCharacterState _next;
		[SerializeField] private DamagedTransition _incoming;

		private bool _attackedByPlayer = false;
		private CancellationTokenSource _token;

		public void ChangeToThis(AbstractCharacter attacker) {
			_attackedByPlayer = attacker is PlayerCharacter;
			RotateTo(attacker.gameObject);
			StateMachine.Change(this);
		}
		public override void SetStateMachine(CharacterStateMachine character) {
			base.SetStateMachine(character);
			_incoming.SetCharacter(StateMachine);
		}

		public override AbstractTransition GetDefaultTransition() => _incoming;
		public void RotateTo(GameObject target) {
			Vector3 direction = target.transform.position - StateMachine.Controller.transform.position;
			direction.y = 0;

			if (direction != Vector3.zero) {
				Quaternion targetRotation = Quaternion.LookRotation(direction);
				StateMachine.Controller.transform.rotation = targetRotation;
			}
		}
		
		private void OnAnimatorMove() {
			var movement = StateMachine.Animator.GetDeltaPosition() + Physics.gravity * Time.deltaTime;
			StateMachine.Controller.Move(movement);
		}
		public override void OnUpdate(float deltaTime) { }
		public override async void OnEnter() {
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			StateMachine.Animator.SetTrigger(_damagedTrigger);
			
			_token = new CancellationTokenSource();
			await Awaitable.WaitForSecondsAsync(_time, _token.Token);
			
			StateMachine.Change(_health.Value == 0 ? _died : _next);
			if (_health.Value == 0 && _attackedByPlayer) {
				EventBus<SlimeKilledEvent>.Raise(new SlimeKilledEvent());
			}
		}
		public override void OnExit() {
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			_token.Cancel();
		}
	}
}