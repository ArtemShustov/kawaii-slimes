using UnityEngine;

namespace Game.Effects {
	public class BlinkAnimation : MonoBehaviour {
		[SerializeField] private int _shapeIndex;
		[SerializeField] private SkinnedMeshRenderer _renderer;
		[SerializeField] private float _blinkDuration = 0.2f;
		[SerializeField] private float _blinkInterval = 3f;

		private float _timeSinceLastBlink;
		private float _blinkProgress;
		private bool _isBlinking;

		private void Update() {
			if (_isBlinking) {
				_blinkProgress += Time.deltaTime / _blinkDuration;
				float weight = Mathf.Clamp01(Mathf.Sin(_blinkProgress * Mathf.PI));
				_renderer.SetBlendShapeWeight(_shapeIndex, weight * 100);

				if (_blinkProgress >= 1f) {
					_isBlinking = false;
					_blinkProgress = 0f;
				}
			} else {
				_timeSinceLastBlink += Time.deltaTime;

				if (_timeSinceLastBlink >= _blinkInterval) {
					_timeSinceLastBlink = 0f;
					_isBlinking = true;
				}
			}
		}
	}
}