using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// Object that fractures into pieces when receiving an impact above the force threshold.
    /// </summary>
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private float _forceThreshold = 50f;
        [SerializeField] private GameObject _fracturedPrefab;
        [SerializeField] private AudioClip _destructionSound;
        [SerializeField] private GameObject _destructionVFX;
        [SerializeField] private float _debrisLifetime = 5f;

        private bool _isDestroyed;

        private void OnCollisionEnter(Collision collision)
        {
            if (_isDestroyed) return;
            if (collision.impulse.magnitude < _forceThreshold) return;

            Destruct(collision.GetContact(0).point);
        }

        /// <summary>Trigger destruction at the given world-space point.</summary>
        public void Destruct(Vector3 point)
        {
            if (_isDestroyed) return;
            _isDestroyed = true;

            // TODO: Spawn fractured prefab, apply explosion force to pieces
            // TODO: Play destruction sound and VFX
            // TODO: Destroy debris after _debrisLifetime

            if (_fracturedPrefab != null)
            {
                var fracture = Instantiate(_fracturedPrefab, transform.position, transform.rotation);
                Destroy(fracture, _debrisLifetime);
            }

            if (_destructionVFX != null)
                Instantiate(_destructionVFX, point, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
