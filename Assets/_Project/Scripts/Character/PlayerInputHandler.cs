using UnityEngine;
using UnityEngine.InputSystem;

namespace NexusForge.Character
{
    /// <summary>
    /// Wraps the Input System, caching input values each frame for consumption
    /// by the state machine and other systems.
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        /// <summary>Current movement input vector (WASD / left stick).</summary>
        public Vector2 MoveInput { get; private set; }

        /// <summary>Current look input vector (mouse delta / right stick).</summary>
        public Vector2 LookInput { get; private set; }

        /// <summary>True the frame jump was pressed.</summary>
        public bool JumpPressed { get; private set; }

        /// <summary>True while jump is held down.</summary>
        public bool JumpHeld { get; private set; }

        /// <summary>True while sprint is held down.</summary>
        public bool SprintHeld { get; private set; }

        /// <summary>True the frame crouch was pressed.</summary>
        public bool CrouchPressed { get; private set; }

        /// <summary>True the frame interact was pressed.</summary>
        public bool InteractPressed { get; private set; }

        /// <summary>True the frame attack was pressed.</summary>
        public bool AttackPressed { get; private set; }

        /// <summary>True the frame alt-attack was pressed.</summary>
        public bool AltAttackPressed { get; private set; }

        /// <summary>True the frame dodge was pressed.</summary>
        public bool DodgePressed { get; private set; }

        // Called by Input System via PlayerInput component or direct bindings
        public void OnMove(InputAction.CallbackContext ctx) => MoveInput = ctx.ReadValue<Vector2>();
        public void OnLook(InputAction.CallbackContext ctx) => LookInput = ctx.ReadValue<Vector2>();
        public void OnJump(InputAction.CallbackContext ctx)
        {
            JumpPressed = ctx.started;
            JumpHeld = ctx.performed;
        }
        public void OnSprint(InputAction.CallbackContext ctx) => SprintHeld = ctx.performed;
        public void OnCrouch(InputAction.CallbackContext ctx) => CrouchPressed = ctx.started;
        public void OnInteract(InputAction.CallbackContext ctx) => InteractPressed = ctx.started;
        public void OnAttack(InputAction.CallbackContext ctx) => AttackPressed = ctx.started;
        public void OnAltAttack(InputAction.CallbackContext ctx) => AltAttackPressed = ctx.started;
        public void OnDodge(InputAction.CallbackContext ctx) => DodgePressed = ctx.started;

        private void LateUpdate()
        {
            // Reset one-shot inputs at end of frame
            JumpPressed = false;
            CrouchPressed = false;
            InteractPressed = false;
            AttackPressed = false;
            AltAttackPressed = false;
            DodgePressed = false;
        }
    }
}
