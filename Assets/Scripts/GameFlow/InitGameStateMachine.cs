using UnityEngine;

namespace Game.GameFlow {
	public class InitGameStateMachine: MonoBehaviour {
		[SerializeField] private GameState _default;
		[SerializeField] private GameStateMachine _machine;

		private void Start() {
			_machine.Change(_default);
		}
	}
}