using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// Trigger volume that overrides gravity for rigidbodies inside it.
    /// Supports directional, radial, inverted, and zero-gravity modes.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class GravityZone : MonoBehaviour
    {
        public enum GravityMode { Directional, Radial, Inverted, ZeroG }

        [SerializeField] private GravityMode _mode = GravityMode.Directional;
        [SerializeField] private Vector3 _gravityDirection = Vector3.down;
        [SerializeField] private float _gravityStrength = 20f;
        [SerializeField] private float _transitionSpeed = 5f;

        private void OnTriggerStay(Collider other)
        {
            if (!other.attachedRigidbody) return;
            var rb = other.attachedRigidbody;

            Vector3 gravity = _mode switch
            {
                GravityMode.Directional => _gravityDirection.normalized * _gravityStrength,
                GravityMode.Radial => (transform.position - other.transform.position).normalized * _gravityStrength,
                GravityMode.Inverted => Vector3.up * _gravityStrength,
                GravityMode.ZeroG => Vector3.zero,
                _ => UnityEngine.Physics.gravity
            };

            // Counteract default gravity and apply custom
            rb.AddForce(-UnityEngine.Physics.gravity + gravity, ForceMode.Acceleration);
        }
    }
}
