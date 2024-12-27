using System;
using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	[Serializable]
	public class AttackTransition: Transition {
		[SerializeField] private AbstractCharacterState _state;
		
		private void OnButton() {
			Character.Change(_state);
		}
		
		public override void StartTracking() {
			Character.Input.Attack += OnButton;
		}
		public override void StopTracking() {
			Character.Input.Attack -= OnButton;
		}
	}
}