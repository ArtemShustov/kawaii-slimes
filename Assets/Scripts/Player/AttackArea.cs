using Core.Character;
using Core.Character.Properties;
using UnityEngine;

namespace Game.Player {
	public class AttackArea: MonoBehaviour {
		[Header("Components")]
		[SerializeField] private AbstractCharacter _self;
		[SerializeField] private BoxCollider _collider;
		[SerializeField] private AudioSource _source;

		public void Attack(int damage) {
			_source.PlayOneShot(_source.clip);
			var contacts = Physics.OverlapBox(
				_collider.transform.TransformPoint(_collider.center),
				_collider.size / 2f
			);
			foreach (var contact in contacts) {
				if (contact.gameObject == _self?.gameObject) {
					continue;
				}
				if (contact.gameObject.TryGetComponent<IAttackable>(out var attackable)) {
					attackable.TakeDamage(_self, damage);
				}
			}
		}
	}
}