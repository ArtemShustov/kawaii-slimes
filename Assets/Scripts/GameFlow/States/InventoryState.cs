using System;
using UnityEngine;

namespace Game.GameFlow.States {
	public class InventoryState: GameStateWithUI {
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
			ForeachChild((c) => c.gameObject.SetActive(true));
		}
		public override void OnExit() {
			base.OnExit();
			ForeachChild((c) => c.gameObject.SetActive(false));
		}
	}
}