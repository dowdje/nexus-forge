using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is sprinting at increased speed.</summary>
    public class SprintState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Set animator parameters for sprinting
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to Walk, Idle, Jump, Fall, Slide
        }

        public void FixedUpdate()
        {
            // TODO: Apply movement force based on input and sprint speed
        }
    }
}
