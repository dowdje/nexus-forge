using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is falling under gravity.</summary>
    public class FallState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Set animator parameters for falling
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to Land, WallRun, LedgeGrab, Swim, DoubleJump (coyote time)
        }

        public void FixedUpdate()
        {
            // TODO: Apply increased fall gravity and air control
        }
    }
}
