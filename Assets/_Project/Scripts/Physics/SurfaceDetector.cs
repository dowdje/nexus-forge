using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// Raycasts downward to identify the surface material below the character,
    /// returning the associated PhysicsMaterialProfile for footstep sounds and effects.
    /// </summary>
    public class SurfaceDetector : MonoBehaviour
    {
        [SerializeField] private float _rayDistance = 1.5f;
        [SerializeField] private LayerMask _surfaceLayers;
        [SerializeField] private PhysicsMaterialProfile _defaultProfile;
        [SerializeField] private PhysicsMaterialProfile[] _knownProfiles;

        /// <summary>The currently detected surface profile.</summary>
        public PhysicsMaterialProfile CurrentSurface { get; private set; }

        private void FixedUpdate()
        {
            if (UnityEngine.Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _rayDistance, _surfaceLayers))
            {
                var mat = hit.collider.sharedMaterial;
                CurrentSurface = FindProfile(mat) ?? _defaultProfile;
            }
            else
            {
                CurrentSurface = _defaultProfile;
            }
        }

        private PhysicsMaterialProfile FindProfile(PhysicMaterial mat)
        {
            if (mat == null || _knownProfiles == null) return null;
            foreach (var profile in _knownProfiles)
            {
                if (profile != null && profile.PhysicMaterial == mat)
                    return profile;
            }
            return null;
        }
    }
}
