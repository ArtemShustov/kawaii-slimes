using Game.Events;
using Game.Slimes;
using UnityEngine;

namespace Game {
	public class GameStats: MonoBehaviour {
		[SerializeField] private GUIStyle _style;
		private int _slimesKilled = 0;

		private void OnSlimeKilled(SlimeKilledEvent gameEvent) {
			_slimesKilled++;
		}
		
		private void OnGUI() {
			GUILayout.Label($"Slimes killed: {_slimesKilled}", _style);
		}
		private void OnEnable() {
			EventBus<SlimeKilledEvent>.Event += OnSlimeKilled;
		}
		private void OnDisable() {
			EventBus<SlimeKilledEvent>.Event -= OnSlimeKilled;
		}
	}
}