using System;
using UnityEngine;

namespace Core.Character {
	public class CharacterAnimator: MonoBehaviour {
		[Header("Components")]
		[SerializeField] private Animator _animator;

		public Animator Animator => _animator;
		
		public event Action AnimatorMove;
		
		public event Action FootstepCallback;
		public event Action AnimationEndedCallback;

		public void ApplyBuiltinRootMotion() {
			_animator.ApplyBuiltinRootMotion();
		}
		public Vector3 GetDeltaPosition() {
			return _animator.deltaPosition;
		}

		public void SetBool(string id, bool value) {
			_animator.SetBool(id, value);
		}
		public void SetTrigger(string id) {
			_animator.SetTrigger(id);
		}
		
		protected void OnAnimatorMove() {
			AnimatorMove?.Invoke();
		}
		
		public void OnFootstepCallback() {
			FootstepCallback?.Invoke();
		}
		public void OnAnimationEndedCallback() {
			AnimationEndedCallback?.Invoke();
		}
	}
}