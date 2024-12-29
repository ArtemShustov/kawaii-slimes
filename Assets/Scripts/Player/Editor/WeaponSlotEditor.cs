using UnityEditor;
using UnityEngine;

namespace Game.Player.Editor {
	[CustomEditor(typeof(WeaponSlot))]
	public class WeaponSlotEditor: UnityEditor.Editor {
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			if (!Application.isPlaying) {
				return;
			}

			var slot = target as WeaponSlot;
			if (GUILayout.Button("Set weapon to null")) {
				slot.SetWeapon(null);
			}
			if (GUILayout.Button("Update weapon")) {
				slot.SetWeapon(slot.Weapon);
			}
		}
	}
}