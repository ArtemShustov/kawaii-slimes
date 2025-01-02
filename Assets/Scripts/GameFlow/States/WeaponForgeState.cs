using System;
using Core.UI.Panels;
using Game.UI.Inventory.WeaponForge;
using UnityEngine;

namespace Game.GameFlow.States {
	public class WeaponForgeState: WorldState {
		[SerializeField] private PanelSwitcher _ui;

		private IUIPanel _last;
		
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
			ForeachChild((c) => c.gameObject.SetActive(true));
			_last = _ui.Current;
			var viewModel = new WeaponForgeViewModel(StateMachine.Player, StateMachine.Inventory);
			if (!_ui.Change(viewModel)) {
				Debug.LogError($"Failed to change UI to {viewModel.GetType()}");
			}
		}
		public override void OnExit() {
			ForeachChild((c) => c.gameObject.SetActive(false));
			_ui.Change(_last);
		}
	}
}