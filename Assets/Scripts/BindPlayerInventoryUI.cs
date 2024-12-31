using System;
using Core.Items;
using Game.Player;
using Game.UI.Inventory;
using UnityEngine;

namespace Game {
	[Obsolete("For testing purposes only")]
	public class BindPlayerInventoryUI: MonoBehaviour {
		[SerializeField] private PlayerCharacter _character;
		[SerializeField] private PlayerInventory _inventory;
		[SerializeField] private PlayerInventoryPanel _ui;

		private void Awake() {
			_ui.Bind(new PlayerInventoryViewModel(_character, _inventory));
		}
	}
}