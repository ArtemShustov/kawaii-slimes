using System;
using UnityEngine;

namespace Game.Player {
	public class AttackAnimationCallback: MonoBehaviour {
		public event Action OnCallback;
		
		private void OnAttackCallback() {
			OnCallback?.Invoke();
		}
	}
}