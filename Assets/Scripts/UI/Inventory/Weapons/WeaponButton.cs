using System;
using Core.MVVM;
using Game.Items;
using UnityEngine;

namespace Game.UI.Inventory.Weapons {
	public class WeaponButton: MonoBehaviour, IPlayerInventoryComponent {
		protected WeaponStack Weapon { get; private set; }
		protected PlayerInventoryViewModel ViewModel { get; private set; }
		
		public Type ViewModelType => typeof(PlayerInventoryViewModel);

		public virtual void Bind(PlayerInventoryViewModel viewModel) {
			ViewModel = viewModel;
		}
		public virtual void SetStack(WeaponStack stack) {
			Weapon = stack;
		}
	}
}