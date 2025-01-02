using UnityEngine;

namespace Game.GameFlow {
	public class InitGameStateMachine: MonoBehaviour {
		[SerializeField] private WorldState _default;
		[SerializeField] private WorldStateMachine _machine;

		private void Start() {
			_machine.Change(_default);
		}
	}
}