using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is running along a vertical surface.</summary>
    public class WallRunState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Reduce gravity, tilt camera, set animator parameters
        }

        public void Exit()
        {
            // TODO: Reset camera tilt
        }

        public void Update()
        {
            // TODO: Check transitions to Jump (wall kick), Fall (wall run expired or detached)
        }

        public void FixedUpdate()
        {
            // TODO: Apply wall run movement, gradual vertical drop
        }
    }
}
