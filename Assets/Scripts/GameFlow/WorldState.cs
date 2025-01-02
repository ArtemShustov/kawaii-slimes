using UnityEngine;

namespace Game.GameFlow {
	public abstract class WorldState: MonoBehaviour {
		protected WorldStateMachine StateMachine { get; private set; }

		public void SetStateMachine(WorldStateMachine stateMachine) {
			StateMachine = stateMachine;
		}
		
		public abstract void OnEnter();
		public abstract void OnExit();
	}
}