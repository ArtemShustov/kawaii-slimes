using System;
using UnityEngine;

namespace Core.Character.Properties {
	public class Health: MonoBehaviour, IAttackable {
		[SerializeField] private int _max = 1;
		public int _current;
		
		public int Value => _current;
		public int Max => _max;
		public bool IsMax => _current >= _max;
		
		public event DamagedEvent Damaged;
		public event Action<int> Changed;

		private void Awake() {
			SetHealth(_max);
		}

		public void TakeDamage(AbstractCharacter from, int damage) {
			SetHealth(_current -= damage);
			Damaged?.Invoke(from, damage);
		}
		public void SetHealth(int health) {
			_current = Mathf.Clamp(health, 0, _max);
			Changed?.Invoke(_current);
		}
		
		public delegate void DamagedEvent(AbstractCharacter from, int damage);
	}
}