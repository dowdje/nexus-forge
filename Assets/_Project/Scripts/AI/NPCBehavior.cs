using UnityEngine;

namespace NexusForge.AI
{
    /// <summary>
    /// ScriptableObject defining NPC behavior parameters:
    /// patrol routes, detection ranges, and response types.
    /// </summary>
    [CreateAssetMenu(fileName = "NewNPCBehavior", menuName = "NexusForge/AI/NPC Behavior")]
    public class NPCBehavior : ScriptableObject
    {
        public enum BehaviorType { Idle, Patrol, Guard, Wander, Follow }

        [SerializeField] private BehaviorType _defaultBehavior = BehaviorType.Idle;
        [SerializeField] private float _detectionRange = 15f;
        [SerializeField] private float _attackRange = 2f;
        [SerializeField] private float _moveSpeed = 3.5f;
        [SerializeField] private float _patrolWaitTime = 3f;
        [SerializeField] private bool _isHostile;

        public BehaviorType DefaultBehavior => _defaultBehavior;
        public float DetectionRange => _detectionRange;
        public float AttackRange => _attackRange;
        public float MoveSpeed => _moveSpeed;
        public float PatrolWaitTime => _patrolWaitTime;
        public bool IsHostile => _isHostile;
    }
}
