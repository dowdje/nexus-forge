using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is hanging from a ledge.</summary>
    public class LedgeGrabState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Snap to ledge position, disable gravity, set animator parameters
        }

        public void Exit()
        {
            // TODO: Re-enable gravity
        }

        public void Update()
        {
            // TODO: Check transitions to ClimbUp (Idle), Shimmy left/right, Fall (drop), Jump (leap up)
        }

        public void FixedUpdate()
        {
            // TODO: Apply shimmy movement along ledge based on input
        }
    }
}
