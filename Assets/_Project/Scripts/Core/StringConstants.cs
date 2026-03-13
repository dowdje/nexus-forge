namespace NexusForge.Core
{
    /// <summary>
    /// Centralized string constants to avoid magic strings throughout the codebase.
    /// </summary>
    public static class StringConstants
    {
        // Scene names
        public const string SceneBoot = "Boot";
        public const string SceneSandbox = "Sandbox";
        public const string ScenePhysicsLab = "PhysicsLab";
        public const string SceneTraversalGym = "TraversalGym";

        // Animation parameters
        public const string AnimSpeed = "Speed";
        public const string AnimGrounded = "Grounded";
        public const string AnimJump = "Jump";
        public const string AnimFall = "Fall";
        public const string AnimClimb = "Climb";
        public const string AnimSwim = "Swim";

        // Tags
        public const string TagPlayer = "Player";
        public const string TagMainCamera = "MainCamera";

        // Log prefixes
        public const string LogCore = "[NexusForge.Core]";
        public const string LogCharacter = "[NexusForge.Character]";
        public const string LogPhysics = "[NexusForge.Physics]";
        public const string LogEnvironment = "[NexusForge.Environment]";
    }
}
