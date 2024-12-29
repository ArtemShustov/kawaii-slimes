using System;
using Game.Player;
using UnityEngine;

namespace Game.GameFlow.States {
	public class FreeModeState: GameState {
		[SerializeField] private PlayerCharacter _player;
		[SerializeField] private GameCamera _camera;

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
			_player.SetInputActive(true);
			_camera.SetInputActive(true);
			_camera.SetCursorLock(true);
			ForeachChild((c) => c.gameObject.SetActive(true));
		}
		public override void OnExit() {
			_player.SetInputActive(false);
			_camera.SetInputActive(false);
			_camera.SetCursorLock(false);
			ForeachChild((c) => c.gameObject.SetActive(false));
		}
	}
}