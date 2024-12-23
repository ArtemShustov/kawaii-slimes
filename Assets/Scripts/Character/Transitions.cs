using System;
using UnityEngine;

namespace Game.Character {
	[Serializable]
	public class Transitions {
		[SerializeField] private CharacterStateWithTransition[] _states;

		public bool CheckAll() {
			foreach (var state in _states) {
				var result = state.GetDefaultTransition().Check();
				if (result) {
					return true;
				}
			}
			return false;
		}
		public void StartTracking() {
			foreach (var state in _states) {
				state.GetDefaultTransition().StartTracking();
			}
		}
		public void StopTracking() {
			foreach (var state in _states) {
				state.GetDefaultTransition().StopTracking();
			}
		}
	}
}