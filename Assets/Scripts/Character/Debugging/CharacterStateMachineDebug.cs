using System;
using UnityEngine;

namespace Game.Character.Debugging {
	public class CharacterStateMachineDebug: MonoBehaviour {
		[SerializeField] private CharacterStateMachine _machine;
		private Camera _camera;
		private GUIStyle _style;
		
		private void Awake() {
			_camera = Camera.main;
			_style = new GUIStyle();
			_style.alignment = TextAnchor.UpperCenter;
			_style.fontSize = 36;
		}

		private void OnGUI() {
			var screenPosition = _camera.WorldToScreenPoint(transform.position);
			if (screenPosition.z > 0) {
				var rect = new Rect(screenPosition.x, Screen.height - screenPosition.y, 0, 0);
				GUI.Label(rect, $"State: {_machine.CurrentState?.GetType().Name}", _style);
			}
		}
	}
}