using UnityEngine;

namespace NexusForge.Character
{
    /// <summary>
    /// Defines all tunable parameters for the player character.
    /// Create via Assets > Create > NexusForge > Character > Character Profile.
    /// </summary>
    [CreateAssetMenu(fileName = "NewCharacterProfile", menuName = "NexusForge/Character/Character Profile")]
    public class CharacterProfile : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _sprintSpeed = 9f;
        [SerializeField] private float _acceleration = 12f;
        [SerializeField] private float _deceleration = 10f;
        [SerializeField, Range(0f, 1f)] private float _airControl = 0.4f;
        [SerializeField] private float _groundFriction = 6f;

        [Header("Jump")]
        [SerializeField] private float _jumpForce = 12f;
        [SerializeField] private float _doubleJumpForce = 10f;
        [SerializeField] private float _gravityMultiplier = 2f;
        [SerializeField] private float _fallGravityMultiplier = 3f;
        [SerializeField] private float _coyoteTime = 0.15f;
        [SerializeField] private float _jumpBufferTime = 0.12f;
        [SerializeField] private float _maxJumpHoldTime = 0.2f;

        [Header("Wall Run")]
        [SerializeField] private float _wallRunMinSpeed = 6f;
        [SerializeField] private float _wallRunMaxDuration = 1.5f;
        [SerializeField] private float _wallRunVerticalDropRate = 2f;
        [SerializeField] private float _wallKickForce = 8f;

        [Header("Climbing")]
        [SerializeField] private float _climbSpeed = 3f;
        [SerializeField] private float _climbStaminaCost = 10f;
        [SerializeField] private float _maxStamina = 100f;
        [SerializeField] private float _staminaRegenRate = 15f;

        [Header("Ledge")]
        [SerializeField] private float _ledgeDetectionRange = 1.5f;
        [SerializeField] private float _shimmySpeed = 2f;
        [SerializeField] private float _climbUpDuration = 0.5f;

        [Header("Slide")]
        [SerializeField] private float _slideForce = 15f;
        [SerializeField] private float _slideDuration = 0.8f;
        [SerializeField] private float _slopeBoostMultiplier = 1.5f;
        [SerializeField] private float _slideColliderHeight = 0.5f;

        [Header("Swimming")]
        [SerializeField] private float _swimSpeed = 4f;
        [SerializeField] private float _diveSpeed = 3f;
        [SerializeField] private float _buoyancyForce = 5f;
        [SerializeField] private float _oxygenDuration = 30f;

        [Header("Camera")]
        [SerializeField] private float _lookSensitivity = 2f;
        [SerializeField] private float _aimSensitivity = 1f;
        [SerializeField] private Vector3 _shoulderOffset = new(0.5f, 0f, 0f);

        // Public accessors
        public float WalkSpeed => _walkSpeed;
        public float SprintSpeed => _sprintSpeed;
        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;
        public float AirControl => _airControl;
        public float GroundFriction => _groundFriction;
        public float JumpForce => _jumpForce;
        public float DoubleJumpForce => _doubleJumpForce;
        public float GravityMultiplier => _gravityMultiplier;
        public float FallGravityMultiplier => _fallGravityMultiplier;
        public float CoyoteTime => _coyoteTime;
        public float JumpBufferTime => _jumpBufferTime;
        public float MaxJumpHoldTime => _maxJumpHoldTime;
        public float WallRunMinSpeed => _wallRunMinSpeed;
        public float WallRunMaxDuration => _wallRunMaxDuration;
        public float WallRunVerticalDropRate => _wallRunVerticalDropRate;
        public float WallKickForce => _wallKickForce;
        public float ClimbSpeed => _climbSpeed;
        public float ClimbStaminaCost => _climbStaminaCost;
        public float MaxStamina => _maxStamina;
        public float StaminaRegenRate => _staminaRegenRate;
        public float LedgeDetectionRange => _ledgeDetectionRange;
        public float ShimmySpeed => _shimmySpeed;
        public float ClimbUpDuration => _climbUpDuration;
        public float SlideForce => _slideForce;
        public float SlideDuration => _slideDuration;
        public float SlopeBoostMultiplier => _slopeBoostMultiplier;
        public float SlideColliderHeight => _slideColliderHeight;
        public float SwimSpeed => _swimSpeed;
        public float DiveSpeed => _diveSpeed;
        public float BuoyancyForce => _buoyancyForce;
        public float OxygenDuration => _oxygenDuration;
        public float LookSensitivity => _lookSensitivity;
        public float AimSensitivity => _aimSensitivity;
        public Vector3 ShoulderOffset => _shoulderOffset;
    }
}
