using UnityEngine;

namespace NexusForge.Audio
{
    /// <summary>
    /// Trigger zone that changes the ambient audio when the player enters.
    /// Blends between ambient tracks based on proximity.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class AmbientZone : MonoBehaviour
    {
        [SerializeField] private AudioClip _ambienceClip;
        [SerializeField, Range(0f, 1f)] private float _volume = 0.5f;
        [SerializeField] private float _fadeTime = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            var audioManager = AudioManager.Instance;
            if (audioManager != null)
            {
                // TODO: Implement fade transition
                audioManager.SetAmbience(_ambienceClip);
            }
        }
    }
}
