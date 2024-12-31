using System;
using System.Linq;
using Core.Items;
using UnityEngine;

namespace Game.Items {
	[CreateAssetMenu(menuName = "Items/Weapon")]
	public class Weapon: Item, IHasDroppedModel {
		[SerializeField] private UpgradeStage[] _upgradeLevels;
		[SerializeField] private GameObject _prefab;
		[SerializeField] private DroppedItem _droppedPrefab;
 		
		public GameObject Prefab => _prefab;

		public override AbstractItemStack GetStack() {
			return new WeaponStack(this, 1);
		}
		public DroppedItem GetDroppedPrefab() => _droppedPrefab;

		#region API
		public int GetMaxLevel() {
			return _upgradeLevels.Max(entry => entry.Level);
		}
		public int GetMinLevel() {
			return _upgradeLevels.Min(entry => entry.Level);
		}
		public int GetMinDamage() {
			return _upgradeLevels.Min(entry => entry.Damage);
		}
		public int GetMaxDamage() {
			return _upgradeLevels.Max(entry => entry.Damage);
		}
		public int GetMaxExperience() {
			return _upgradeLevels.Max(entry => entry.Experience);
		}
		public UpgradeStage GetUpgradeStage(int experience) {
			if (experience <= 0) return _upgradeLevels.First();
			if (experience >= GetMaxExperience()) return _upgradeLevels.Last();

			for (int i = 0; i < _upgradeLevels.Length - 1; i++) {
				var currentLevel = _upgradeLevels[i];
				var nextLevel = _upgradeLevels[i + 1];

				if (experience >= currentLevel.Experience && experience < nextLevel.Experience) {
					var expProgress = (float)(experience - currentLevel.Experience) / (nextLevel.Experience - currentLevel.Experience);
					var level = Mathf.FloorToInt(Mathf.Lerp(currentLevel.Level, nextLevel.Level, expProgress));
					var damage = Mathf.FloorToInt(Mathf.Lerp(currentLevel.Damage, nextLevel.Damage, expProgress));
					
					return new UpgradeStage(level, experience, damage);
				}
			}
			
			return _upgradeLevels.First();
		}
		#endregion
		
		[Serializable]
		public struct UpgradeStage {
			[field: SerializeField] public int Level { get; private set; }
			[field: SerializeField] public int Experience { get; private set; }
			[field: SerializeField] public int Damage { get; private set; }

			public UpgradeStage(int level, int experience, int damage) {
				Level = level;
				Experience = experience;
				Damage = damage;
			}
		}
	}
}