using Game.Character;
using UnityEngine;

namespace Game.UI {
	public class HealthBar: MonoBehaviour {
		[SerializeField] private Health _health;
		[SerializeField] private float _renderDist = 10;
		[Space]
		[SerializeField] private Transform _bar;
		[SerializeField] private MeshRenderer _meshRenderer;
		[SerializeField] private Camera _camera;
		private MaterialPropertyBlock _propertyBlock;

		private readonly static int FillProperty = Shader.PropertyToID("_Fill");
		
		private void Awake() {
			_propertyBlock = new MaterialPropertyBlock();
		}
		private void Start() {
			if (!_camera) {
				_camera = Camera.main;
			}
		}
		private void Update() {
			AlignToCamera();
			UpdateEnable();
		}

		private bool IsNeedToShow() {
			var isNearCamera = Vector3.Distance(_bar.transform.position, _camera.transform.position) <= _renderDist;
			var isDamaged = !_health.IsMax;
			return isDamaged && isNearCamera;
		}
		private void UpdateEnable() {
			var isNeedToShow = IsNeedToShow();
			if (_meshRenderer.enabled != isNeedToShow) {
				_meshRenderer.enabled = isNeedToShow;
			}
		}
		private void UpdateFill() {
			_meshRenderer.GetPropertyBlock(_propertyBlock);
			var fill = _health.Value / (float)_health.Max;
			_propertyBlock.SetFloat(FillProperty, fill);
			_meshRenderer.SetPropertyBlock(_propertyBlock);
		}
		private void AlignToCamera() {
			if (_camera != null) {
				var camXform = _camera.transform;
				var forward = _bar.position - camXform.position;
				forward.Normalize();
				var up = Vector3.Cross(forward, camXform.right);
				_bar.rotation = Quaternion.LookRotation(forward, up);
			}
		}

		private void OnHealthChanged(int newValue) {
			UpdateFill();
		}
		private void OnEnable() {
			_health.Changed += OnHealthChanged;
			UpdateFill();
		}
		private void OnDisable() {
			_health.Changed -= OnHealthChanged;
		}
	}
}