using Core.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory.StackView {
	[RequireComponent(typeof(ItemStackView))]
	public class SelectableItemStack: MonoBehaviour {
		[SerializeField] private Button _button;
		private ItemStackView _stackView;

		private void Awake() {
			_stackView = GetComponent<ItemStackView>();
		}

		private void OnButtonCLick() {
			EventBus<ItemViewSelectedEvent>.Raise(new ItemViewSelectedEvent(_stackView));
		}
		private void OnEnable() {
			_button.onClick.AddListener(OnButtonCLick);
		}
		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonCLick);
		}
	}
}