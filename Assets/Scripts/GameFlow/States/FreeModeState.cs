using System;
using UnityEngine;

namespace Game.GameFlow.States {
	public class FreeModeState: WorldStateWithUI {
		private void Awake() {
			ForeachChild((c) => c.gameObject.SetActive(false));
		}

		private void ForeachChild(Action<Transform> action) {
			foreach (var o in transform) {
				var child = (Transform)o;
				action?.Invoke(child);
			}
		}

		public override void OnEnter() {
			base.OnEnter();
			StateMachine.Player.SetInputActive(true);
			StateMachine.Camera.SetInputActive(true);
			StateMachine.Camera.SetCursorLock(true);
			ForeachChild((c) => c.gameObject.SetActive(true));
		}
		public override void OnExit() {
			base.OnExit();
			StateMachine.Player.SetInputActive(false);
			StateMachine.Camera.SetInputActive(false);
			StateMachine.Camera.SetCursorLock(false);
			ForeachChild((c) => c.gameObject.SetActive(false));
		}
	}
}