using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is walking at normal speed.</summary>
    public class WalkState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Set animator parameters for walking
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to Idle, Sprint, Jump, Fall, Crouch/Slide
        }

        public void FixedUpdate()
        {
            // TODO: Apply movement force based on input and walk speed
        }
    }
}
