using UnityEngine;

namespace Game.Character {
	public class InitCharacterStateMachine: MonoBehaviour {
		[SerializeField] private CharacterStateMachine _character;
		[SerializeField] private CharacterState _defaultState;
		[SerializeField] private Transform _statesRoot;

		private void Start() {
			var states = _statesRoot.GetComponents<CharacterState>();
			foreach (var state in states) {
				state.SetCharacter(_character);
			}
			
			_character.Change(_defaultState);
		}
	}
}