using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>
    /// Manages character state transitions and delegates updates to the active state.
    /// </summary>
    public class CharacterStateMachine : MonoBehaviour
    {
        /// <summary>The currently active character state.</summary>
        public ICharacterState CurrentState { get; private set; }

        /// <summary>The previously active character state.</summary>
        public ICharacterState PreviousState { get; private set; }

        [SerializeField] private CharacterProfile _profile;

        /// <summary>The character profile containing all tunable parameters.</summary>
        public CharacterProfile Profile => _profile;

        /// <summary>Cached Rigidbody component.</summary>
        public Rigidbody Rigidbody { get; private set; }

        /// <summary>Cached CapsuleCollider component.</summary>
        public CapsuleCollider Collider { get; private set; }

        /// <summary>Cached PlayerInputHandler component.</summary>
        public PlayerInputHandler InputHandler { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<CapsuleCollider>();
            InputHandler = GetComponent<PlayerInputHandler>();
        }

        /// <summary>Transition to a new state.</summary>
        public void ChangeState(ICharacterState newState)
        {
            PreviousState = CurrentState;
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter(this);
        }

        private void Update() => CurrentState?.Update();
        private void FixedUpdate() => CurrentState?.FixedUpdate();
    }
}
