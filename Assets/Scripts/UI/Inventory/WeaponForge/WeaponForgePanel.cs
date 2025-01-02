using Core.Events;
using Core.Items;
using Core.UI.Panels;
using Game.Items;
using Game.UI.Inventory.Modern;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.UI.Inventory.WeaponForge {
	public class WeaponForgePanel: UIPanel<WeaponForgeViewModel> {
		[Header("Weapon upgrade")]
		[SerializeField] private CountableItem _resource;
		[SerializeField] private string _upgradeRootName = "Item";
		[SerializeField] private string _requiredItemViewName = "RequiredItem";
		[Header("Inventory")]
		[SerializeField] private VisualTreeAsset _itemStackPrefab;
		[SerializeField] private string _inventoryContainerName = "ItemsContainer";
		[Header("Settings")]
		[SerializeField] private VisualTreeAsset _ui;
		[SerializeField] private UIDocument _document;

		private WeaponForgeViewModel _viewModel;
		
		private VisualElement _inventoryContainer;
		private VisualElement _upgradeRoot;
		private VisualElement _requiredItemView;

		#region UIPanel
		public override void Bind(WeaponForgeViewModel viewModel) {
			base.Bind(viewModel);
			_viewModel = viewModel;
		}
		public override void Show() {
			base.Show();
			_document.visualTreeAsset = _ui;
			
			_upgradeRoot = _document.rootVisualElement.Q<VisualElement>(_upgradeRootName);
			_requiredItemView = _upgradeRoot.Q<VisualElement>(_requiredItemViewName);
			_inventoryContainer = _document.rootVisualElement.Q<VisualElement>(_inventoryContainerName);
			
			foreach (var itemStack in _viewModel.Inventory.Items) {
				if (itemStack is WeaponStack weaponStack) {
					AddItem(weaponStack);
				}
			}
			HideUpgradeView();
		}
		#endregion
		
		#region Invernal
		private void AddItem(WeaponStack stack) {
			var viewModel = new WeaponStackViewModel(stack);
			var view = _itemStackPrefab.Instantiate();
			view.dataSource = viewModel;
			
			_inventoryContainer.Add(view);
		}
		private void ClearItems() {
			var container = _document.rootVisualElement.Q<VisualElement>(_inventoryContainerName);
			container.Clear();
		}

		private void ShowUpgradeViewFor(WeaponStack weaponStack) {
			var requiredVirtualStack = new CountableItemStack(_resource, 0);
			
			_upgradeRoot.dataSource = new UpgradeWeaponViewModel(weaponStack, ViewModel.Inventory, requiredVirtualStack);
			_requiredItemView.dataSource = new ItemStackViewModel(requiredVirtualStack);
			
			ShowUpgradeView();
		}
		private void ShowUpgradeView() {
			_upgradeRoot.style.display = DisplayStyle.Flex;
		}
		private void HideUpgradeView() {
			_upgradeRoot.style.display = DisplayStyle.None;
		}
		#endregion

		#region Events
		private void OnItemStackSelected(ItemStackSelectedEvent gameEvent) {
			if (gameEvent.Stack is not WeaponStack weaponStack) {
				HideUpgradeView();
				return;
			}
			ShowUpgradeViewFor(weaponStack);
		}
		private void OnEnable() {
			EventBus<ItemStackSelectedEvent>.Event += OnItemStackSelected;
		}
		private void OnDisable() {
			EventBus<ItemStackSelectedEvent>.Event -= OnItemStackSelected;
		}
		#endregion
	}
}