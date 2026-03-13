using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// Applies buoyancy forces to rigidbodies submerged in water volumes.
    /// Works with the Water layer trigger colliders.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Buoyancy : MonoBehaviour
    {
        [SerializeField] private float _buoyancyForce = 15f;
        [SerializeField] private float _waterDrag = 3f;
        [SerializeField] private float _waterAngularDrag = 1f;
        [SerializeField] private float _waterSurfaceY = 0f;
        [SerializeField] private float _submergeDepth = 2f;

        private Rigidbody _rb;
        private float _defaultDrag;
        private float _defaultAngularDrag;
        private bool _isSubmerged;

        public bool IsSubmerged => _isSubmerged;
        public float SubmergedFraction { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _defaultDrag = _rb.linearDamping;
            _defaultAngularDrag = _rb.angularDamping;
        }

        private void FixedUpdate()
        {
            if (!_isSubmerged) return;

            float depth = _waterSurfaceY - transform.position.y;
            SubmergedFraction = Mathf.Clamp01(depth / _submergeDepth);

            // Apply upward buoyancy force proportional to submersion
            _rb.AddForce(Vector3.up * (_buoyancyForce * SubmergedFraction), ForceMode.Acceleration);

            // Increase drag when submerged
            _rb.linearDamping = Mathf.Lerp(_defaultDrag, _waterDrag, SubmergedFraction);
            _rb.angularDamping = Mathf.Lerp(_defaultAngularDrag, _waterAngularDrag, SubmergedFraction);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                _isSubmerged = true;
                _waterSurfaceY = other.bounds.max.y;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                _isSubmerged = false;
                _rb.linearDamping = _defaultDrag;
                _rb.angularDamping = _defaultAngularDrag;
            }
        }
    }
}
