using Core.MVVM;
using UnityEngine;

namespace Game.UI.Inventory {
	public class PlayerInventoryComponent: MonoBehaviour {
		protected PlayerInventoryViewModel ViewModel { get; private set; }

		public virtual void Bind(PlayerInventoryViewModel viewModel) {
			ViewModel = viewModel;
		}
	}
}