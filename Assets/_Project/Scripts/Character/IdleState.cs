using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is stationary on the ground.</summary>
    public class IdleState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Set animator parameters, reset velocity
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Check transitions to Walk, Sprint, Jump, Fall, Crouch/Slide, Interact
        }

        public void FixedUpdate()
        {
            // TODO: Apply ground friction to slow residual velocity
        }
    }
}
