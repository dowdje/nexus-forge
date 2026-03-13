using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character physics is controlled by ragdoll simulation.</summary>
    public class RagdollState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Enable ragdoll rigidbodies and colliders, disable main Rigidbody and animator
        }

        public void Exit()
        {
            // TODO: Disable ragdoll, re-enable main Rigidbody and animator, blend pose back
        }

        public void Update()
        {
            // TODO: Check transitions to Idle/GetUp after ragdoll settles (low velocity threshold)
        }

        public void FixedUpdate()
        {
            // TODO: Monitor ragdoll velocity to determine when character has settled
        }
    }
}
