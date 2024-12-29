using Game.Player;
using Game.UI;
using UnityEngine;

namespace Game.GameFlow {
	public class GameStateMachine: MonoBehaviour {
		private GameState _current;

		public void Change(GameState state) {
			_current?.OnExit();
			_current = state;
			_current?.OnEnter();
		}
	}
}