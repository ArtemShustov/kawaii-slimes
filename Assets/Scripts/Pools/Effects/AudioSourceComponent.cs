using UnityEngine;

namespace Game.Pools.Effects {
	public class AudioSourceComponent: EffectComponent {
		[SerializeField] private AudioSource _source;
		
		public override void Play() {
			_source.PlayOneShot(_source.clip);
		}
	}
}