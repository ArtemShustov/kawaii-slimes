using Core.Character;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Game.Slimes {
	public class AiInput: MonoBehaviour {
		[SerializeField] private CharacterInput _input;
		[SerializeField] private NavMeshAgent _agent;
		
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
	}
}