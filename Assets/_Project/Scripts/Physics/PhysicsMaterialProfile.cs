using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// ScriptableObject pairing a PhysicMaterial with gameplay metadata:
    /// footstep sounds, impact particles, and movement modifiers.
    /// </summary>
    [CreateAssetMenu(fileName = "NewPhysicsMaterialProfile", menuName = "NexusForge/Physics/Material Profile")]
    public class PhysicsMaterialProfile : ScriptableObject
    {
        [Header("Physics Material")]
        [SerializeField] private PhysicMaterial _physicMaterial;

        [Header("Surface Properties")]
        [SerializeField] private string _surfaceName = "Default";
        [SerializeField] private float _movementSpeedModifier = 1f;
        [SerializeField] private float _footstepVolume = 1f;

        [Header("Audio")]
        [SerializeField] private AudioClip[] _footstepClips;
        [SerializeField] private AudioClip _impactClip;

        [Header("VFX")]
        [SerializeField] private GameObject _impactParticlePrefab;
        [SerializeField] private GameObject _footstepParticlePrefab;

        public PhysicMaterial PhysicMaterial => _physicMaterial;
        public string SurfaceName => _surfaceName;
        public float MovementSpeedModifier => _movementSpeedModifier;
        public float FootstepVolume => _footstepVolume;
        public AudioClip[] FootstepClips => _footstepClips;
        public AudioClip ImpactClip => _impactClip;
        public GameObject ImpactParticlePrefab => _impactParticlePrefab;
        public GameObject FootstepParticlePrefab => _footstepParticlePrefab;
    }
}
