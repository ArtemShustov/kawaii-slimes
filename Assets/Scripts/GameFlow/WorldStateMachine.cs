using Core.Items;
using Game.Player;
using UnityEngine;

namespace Game.GameFlow {
	public class WorldStateMachine: MonoBehaviour {
		[SerializeField] private GameCamera _camera;
		[SerializeField] private PlayerCharacter _player;
		[SerializeField] private PlayerInventory _inventory;
		
		public GameCamera Camera => _camera;
		public PlayerCharacter Player => _player;
		public PlayerInventory Inventory => _inventory;
		
		private WorldState _current;

		public void Change(WorldState state) {
			state.SetStateMachine(this);
			_current?.OnExit();
			_current = state;
			_current?.OnEnter();
		}
	}
}