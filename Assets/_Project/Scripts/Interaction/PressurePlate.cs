using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Interaction
{
    /// <summary>
    /// A pressure plate that activates when sufficient weight is applied.
    /// Triggers events on press and release.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class PressurePlate : MonoBehaviour
    {
        [SerializeField] private float _requiredMass = 1f;
        [SerializeField] private UnityEvent _onPressed;
        [SerializeField] private UnityEvent _onReleased;
        [SerializeField] private Transform _plateVisual;
        [SerializeField] private float _pressDepth = 0.05f;

        private bool _isPressed;
        private float _currentMass;

        public bool IsPressed => _isPressed;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody != null)
                _currentMass += other.attachedRigidbody.mass;

            if (!_isPressed && _currentMass >= _requiredMass)
            {
                _isPressed = true;
                _onPressed?.Invoke();
                // TODO: Animate plate visual downward
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody != null)
                _currentMass -= other.attachedRigidbody.mass;

            if (_isPressed && _currentMass < _requiredMass)
            {
                _isPressed = false;
                _onReleased?.Invoke();
                // TODO: Animate plate visual back up
            }
        }
    }
}
