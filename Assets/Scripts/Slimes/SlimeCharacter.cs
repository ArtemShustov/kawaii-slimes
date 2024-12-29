using Core.Character;
using UnityEngine;

namespace Game.Slimes {
	public class SlimeCharacter: AbstractCharacter {
		[SerializeField] private AiInput _input;

		public void SetNoAi() {
			_input.enabled = false;
		}
	}
}