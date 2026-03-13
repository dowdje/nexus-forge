using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Brief state when character touches ground after falling.</summary>
    public class LandState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Trigger landing animation, apply camera shake if hard landing
        }

        public void Exit() { }

        public void Update()
        {
            // TODO: Transition to Idle, Walk, or Sprint after recovery time
        }

        public void FixedUpdate()
        {
            // TODO: Dampen velocity on landing
        }
    }
}
