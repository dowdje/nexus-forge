using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is climbing a climbable surface.</summary>
    public class ClimbState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Disable gravity, set animator parameters for climbing
        }

        public void Exit()
        {
            // TODO: Re-enable gravity
        }

        public void Update()
        {
            // TODO: Check transitions to LedgeGrab (top), Fall (stamina depleted or detach), Jump (jump off wall)
        }

        public void FixedUpdate()
        {
            // TODO: Apply climb movement based on input, drain stamina
        }
    }
}
