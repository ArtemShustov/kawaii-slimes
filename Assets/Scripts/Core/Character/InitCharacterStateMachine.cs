using UnityEngine;

namespace Core.Character {
	public class InitCharacterStateMachine: MonoBehaviour {
		[SerializeField] private CharacterStateMachine _character;
		[SerializeField] private AbstractCharacterState _defaultState;
		[SerializeField] private Transform _statesRoot;

		private void Start() {
			var states = _statesRoot.GetComponents<AbstractCharacterState>();
			foreach (var state in states) {
				state.SetStateMachine(_character);
			}
			
			_character.Change(_defaultState);
		}
	}
}