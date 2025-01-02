using Core.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Player.States {
	public class AttackState: CharacterState {
		[Header("Settings")]
		[SerializeField] private int _unarmedDamage = 1;
		[SerializeField] private bool _hideWeapon = true;
		[SerializeField] private string _attackTrigger = "Attack";
		[SerializeField] private string _hasWeapon = "HasWeapon";
		[Header("Components")]
		[SerializeField] private AttackAnimationCallback _callback;
		[SerializeField] private AttackArea _unarmedArea;
		[SerializeField] private AttackArea _armedArea;
		[SerializeField] private WeaponSlot _weaponSlot;
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
			var area = _weaponSlot.HasWeapon ? _armedArea : _unarmedArea;
			area.Attack(_weaponSlot.HasWeapon ? _weaponSlot.Weapon.GetDamage() : _unarmedDamage);
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
			StateMachine.Animator.SetBool(_hasWeapon, _weaponSlot.HasWeapon);
			
			_outgoing.StartTracking();
			
			_callback.OnCallback += OnAttack;
			StateMachine.Animator.AnimatorMove += OnAnimatorMove;
			StateMachine.Animator.AnimationEndedCallback += OnAnimationEnded;

			_weaponSlot.Show();
			StateMachine.Animator.SetTrigger(_attackTrigger);
		}
		public override void OnExit() {
			if (_hideWeapon) {
				_weaponSlot.Hide();
			}
			
			_callback.OnCallback -= OnAttack;
			StateMachine.Animator.AnimatorMove -= OnAnimatorMove;
			StateMachine.Animator.AnimationEndedCallback -= OnAnimationEnded;
			
			_outgoing.StopTracking();
		}
	}
}