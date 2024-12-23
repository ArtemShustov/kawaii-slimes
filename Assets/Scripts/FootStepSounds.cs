using Game.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game {
	public class FootStepSounds: MonoBehaviour {
		[Range(0f, 1f)]
		[SerializeField] private float _defaultPitch = 1;
		[SerializeField] private float _randomPitchDelta = 0.3f;
		[SerializeField] private AudioSource _source;
		[SerializeField] private CharacterAnimator _character;

		private void OnFootstep() {
			_source.pitch = _defaultPitch + Random.Range(-_randomPitchDelta, _randomPitchDelta);
			_source.PlayOneShot(_source.clip);
		}

		private void OnEnable() {
			_character.FootstepCallback += OnFootstep;
		}
		private void OnDisable() {
			_character.FootstepCallback -= OnFootstep;
		}
	}
}