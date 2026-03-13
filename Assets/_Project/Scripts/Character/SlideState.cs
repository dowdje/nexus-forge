using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>Character is sliding along the ground.</summary>
    public class SlideState : ICharacterState
    {
        private CharacterStateMachine _sm;

        public void Enter(CharacterStateMachine stateMachine)
        {
            _sm = stateMachine;
            // TODO: Reduce collider height, apply slide force, set animator parameters
        }

        public void Exit()
        {
            // TODO: Restore collider height
        }

        public void Update()
        {
            // TODO: Check transitions to Idle/Walk (slide ended), Fall (off edge), Jump (cancel slide)
        }

        public void FixedUpdate()
        {
            // TODO: Apply slide deceleration, slope boost if on downward slope
        }
    }
}
