using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>
    /// Main player controller. Initializes the state machine and holds references
    /// to all character subsystems.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(CharacterStateMachine))]
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterProfile _profile;

        /// <summary>The character state machine driving behavior.</summary>
        public CharacterStateMachine StateMachine { get; private set; }

        // Ground detection
        [SerializeField] private LayerMask _groundLayers;
        [SerializeField] private float _groundCheckDistance = 0.2f;

        /// <summary>Whether the character is currently grounded.</summary>
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            StateMachine = GetComponent<CharacterStateMachine>();
        }

        private void Start()
        {
            StateMachine.ChangeState(new IdleState());
        }

        private void FixedUpdate()
        {
            IsGrounded = UnityEngine.Physics.SphereCast(
                transform.position + Vector3.up * 0.5f,
                0.3f,
                Vector3.down,
                out _,
                _groundCheckDistance + 0.5f,
                _groundLayers
            );
        }
    }
}
