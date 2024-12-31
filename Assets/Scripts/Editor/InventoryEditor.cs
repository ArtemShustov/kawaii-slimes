using Core.Items;
using UnityEditor;
using UnityEngine;

namespace Game.Editor {
	[CustomEditor(typeof(Inventory))]
	public class InventoryEditor: UnityEditor.Editor {
		private bool _inventoryFoldout = false;
		
		public override void OnInspectorGUI() {
			DrawDefaultInspector();

			if (!Application.isPlaying) {
				return;
			}
			Inventory inventory = (Inventory)target;
			
			_inventoryFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(_inventoryFoldout, "Inventory items");
			EditorGUI.indentLevel += 1;
			if (_inventoryFoldout) {
				foreach (var stack in inventory.Items) {
					GUILayout.Label($"{stack.AbstractItem.name}({stack.AbstractItem.GetType()}) in ({stack.GetType()}) stack");
				}
			}
			EditorGUI.indentLevel -= 1;
			EditorGUILayout.EndFoldoutHeaderGroup();
		}
	}
}