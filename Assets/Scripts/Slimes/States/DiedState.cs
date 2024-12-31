using Core.Character;
using UnityEngine;

namespace Game.Slimes.States {
	public class DiedState: AbstractCharacterState {
		[SerializeField] private SlimeCharacter _character;
		
		public override void OnUpdate(float deltaTime) { }
		public override void OnEnter() {
			_character.OnDied();
		}
		public override void OnExit() { }
	}
}