using System;
using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	[Serializable]
	public class WalkTransition: Transition {
		[SerializeField] private AbstractCharacterState _walkState;
		
		public override bool Check() {
			if (Character.Input.Move.sqrMagnitude != 0) {
				Character.Change(_walkState);
				return true;
			}
			return false;
		}
	}
}