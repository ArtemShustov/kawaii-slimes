using System;
using Game.Character;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Game {
	public class AiInput: MonoBehaviour {
		[SerializeField] private CharacterInput _input;
		[SerializeField] private NavMeshAgent _agent;
		[Space]
		[SerializeField] public Texture2D _targetIcon;
		[SerializeField] public Vector2 _iconSize = new Vector2(32, 32);
		
		private void Start() {
			_agent.updatePosition = false;
			_agent.updateRotation = false;
		}
		
		private void Update() {
			if (_agent.isStopped) {
				var rnd = Random.insideUnitCircle * 10f;
				var point = transform.position + new Vector3(rnd.x, 0, rnd.y);
				_agent.SetDestination(point);
				_agent.isStopped = false;
			}
			if (_agent.remainingDistance <= _agent.stoppingDistance) {
				_agent.isStopped = true;
			}

			var direction = _agent.steeringTarget - _agent.transform.position;
			_input.Move = new Vector2(direction.x, direction.z).normalized;
			
			_agent.nextPosition = transform.position;
		}

		private void OnGUI() {
			if (_agent != null && _agent.hasPath) {
				Vector3 targetPosition = _agent.destination;
				Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetPosition);
				
				if (screenPosition.z > 0) {
					screenPosition.y = Screen.height - screenPosition.y;
					
					Rect iconRect = new Rect(
						screenPosition.x - _iconSize.x / 2,
						screenPosition.y - _iconSize.y / 2,
						_iconSize.x,
						_iconSize.y
					);
					
					GUI.DrawTexture(iconRect, _targetIcon);
				}
			}
		}
	}
}