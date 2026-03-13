namespace NexusForge.Character
{
    /// <summary>
    /// Interface for character state machine states.
    /// </summary>
    public interface ICharacterState
    {
        /// <summary>Called when entering this state.</summary>
        void Enter(CharacterStateMachine stateMachine);

        /// <summary>Called when exiting this state.</summary>
        void Exit();

        /// <summary>Called every frame while this state is active.</summary>
        void Update();

        /// <summary>Called every fixed update while this state is active.</summary>
        void FixedUpdate();
    }
}
