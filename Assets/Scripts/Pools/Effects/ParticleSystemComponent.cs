using UnityEngine;

namespace Game.Pools.Effects {
	public class ParticleSystemComponent: EffectComponent {
		[SerializeField] private ParticleSystem _particleSystem;

		public override void Play() {
			_particleSystem.Play();
		}
	}
}