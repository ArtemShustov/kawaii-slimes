using System;
using UnityEngine;

namespace Core.Character {
	[Serializable]
	public class Transitions {
		[SerializeField] private CharacterState[] _states;

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