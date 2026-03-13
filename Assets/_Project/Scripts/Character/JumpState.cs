using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is in the ascending phase of a jump.</summary>
    public class JumpState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Apply jump force, set animator trigger
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to DoubleJump, Fall, WallRun, LedgeGrab
        }

        public void FixedUpdate()
        {
            // TODO: Apply air control, enhanced gravity when ascending
        }
    }
}
