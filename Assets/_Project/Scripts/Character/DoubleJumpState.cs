using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is performing a second jump in mid-air.</summary>
    public class DoubleJumpState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Apply double jump force, set animator trigger
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to Fall, WallRun, LedgeGrab
        }

        public void FixedUpdate()
        {
            // TODO: Apply air control and gravity
        }
    }
}
