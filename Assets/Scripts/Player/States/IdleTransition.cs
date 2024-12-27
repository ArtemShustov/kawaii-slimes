using System;
using Core.Character;
using UnityEngine;

namespace Game.Player.States {
	[Serializable]
	public class IdleTransition: Transition {
		[SerializeField] private AbstractCharacterState _idleState;
		
		public override bool Check() {
			if (Character.Input.Move.sqrMagnitude == 0) {
				Character.Change(_idleState);
				return true;
			}
			return false;
		}
	}
}