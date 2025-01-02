using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

namespace Game {
	public class ChangeLocale: MonoBehaviour {
		[SerializeField] private InputAction _button = new InputAction(
			name: "Button",
			type: InputActionType.Button,
			binding: "<Keyboard>/F6"
		);

		private void OnButton(InputAction.CallbackContext obj) {
			var locales = LocalizationSettings.AvailableLocales.Locales;
			var current = locales.IndexOf(LocalizationSettings.SelectedLocale);
			var newLocale = current + 1 >= locales.Count ? 0 : current + 1;
			LocalizationSettings.SelectedLocale = locales[newLocale];
		}
		private void OnEnable() {
			_button.Enable();
			_button.performed += OnButton;
		}
		private void OnDisable() {
			_button.Disable();
			_button.performed -= OnButton;
		}
	}
}