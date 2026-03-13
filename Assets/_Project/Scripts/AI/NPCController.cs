using UnityEngine;
using UnityEngine.AI;

namespace NexusForge.AI
{
    /// <summary>
    /// Controls NPC behavior using NavMeshAgent and behavior profiles.
    /// Handles patrol, detection, pursuit, and interaction states.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private NPCBehavior _behavior;
        [SerializeField] private Transform[] _patrolPoints;

        private NavMeshAgent _agent;
        private int _currentPatrolIndex;
        private float _waitTimer;
        private Transform _target;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            if (_behavior != null)
                _agent.speed = _behavior.MoveSpeed;
        }

        private void Update()
        {
            if (_behavior == null) return;

            // TODO: Implement full behavior state machine
            // - Detect player within range
            // - Transition between patrol/chase/attack/return states
            // - Use NavMeshAgent for pathfinding

            switch (_behavior.DefaultBehavior)
            {
                case NPCBehavior.BehaviorType.Patrol:
                    UpdatePatrol();
                    break;
                case NPCBehavior.BehaviorType.Wander:
                    // TODO: Random wander within radius
                    break;
            }
        }

        private void UpdatePatrol()
        {
            if (_patrolPoints == null || _patrolPoints.Length == 0) return;

            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            {
                _waitTimer += Time.deltaTime;
                if (_waitTimer >= _behavior.PatrolWaitTime)
                {
                    _waitTimer = 0f;
                    _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
                    _agent.SetDestination(_patrolPoints[_currentPatrolIndex].position);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (_behavior == null) return;
            Gizmos.color = _behavior.IsHostile ? Color.red : Color.green;
            Gizmos.DrawWireSphere(transform.position, _behavior.DetectionRange);
        }
    }
}
