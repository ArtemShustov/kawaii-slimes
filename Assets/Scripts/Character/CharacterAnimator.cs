using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Character {
	public class CharacterAnimator: MonoBehaviour {
		[Header("Animations")]
		[SerializeField] private string _damaged = "Damage";
		[SerializeField] private string _attack = "Attack";
		[SerializeField] private string _isWalking = "IsWalking";
		[SerializeField] private string _isDead = "IsDead";
		[Header("Components")]
		[SerializeField] private Animator _animator;

		public Animator Animator => _animator;
		
		public event Action AnimatorMove;

		public event Action AttackCallback;
		public event Action FootstepCallback;

		protected void OnAnimatorMove() {
			AnimatorMove?.Invoke();
		}
		public void ApplyBuiltinRootMotion() {
			_animator.ApplyBuiltinRootMotion();
		}
		public Vector3 GetDeltaPosition() {
			return _animator.deltaPosition;
		}

		public void PlayAttack() {
			_animator.SetTrigger(_attack);
		}
		public void PlayDamaged() {
			_animator.SetTrigger(_damaged);
		}
		public void SetIsWalking(bool isWalking) {
			_animator.SetBool(_isWalking, isWalking);
		}
		public void SetIsDead(bool isDead) {
			_animator.SetBool(_isDead, isDead);
		}

		public void OnAttackCallback() {
			AttackCallback?.Invoke();
		}
		public void OnFootstepCallback() {
			FootstepCallback?.Invoke();
		}
	}
}