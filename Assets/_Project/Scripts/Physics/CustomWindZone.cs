using UnityEngine;

namespace NexusForge.Physics
{
    /// <summary>
    /// Applies directional and turbulent wind forces to rigidbodies within a trigger zone.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class CustomWindZone : MonoBehaviour
    {
        [SerializeField] private Vector3 _windDirection = Vector3.right;
        [SerializeField] private float _windStrength = 10f;
        [SerializeField] private float _turbulence = 2f;
        [SerializeField] private float _turbulenceFrequency = 1f;

        private void OnTriggerStay(Collider other)
        {
            if (!other.attachedRigidbody) return;

            float noise = Mathf.PerlinNoise(Time.time * _turbulenceFrequency, 0f) * 2f - 1f;
            Vector3 force = _windDirection.normalized * _windStrength;
            force += Random.insideUnitSphere * (_turbulence * noise);

            other.attachedRigidbody.AddForce(force, ForceMode.Force);
        }
    }
}
