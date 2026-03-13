using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is swimming in a water volume.</summary>
    public class SwimState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Switch to swim movement mode, set animator parameters, start oxygen timer
        }

        public void Exit()
        {
            // TODO: Reset oxygen timer, restore normal movement mode
        }

        public void Update()
        {
            // TODO: Check transitions to Idle/Walk (exited water), Dive (submerge), oxygen depletion
        }

        public void FixedUpdate()
        {
            // TODO: Apply buoyancy, swim movement based on input, drain oxygen when submerged
        }
    }
}
