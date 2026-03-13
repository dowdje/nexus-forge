using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Interaction
{
    /// <summary>
    /// A toggle lever that switches between on/off states.
    /// </summary>
    public class LeverSwitch : Interactable
    {
        [SerializeField] private bool _isOn;
        [SerializeField] private UnityEvent _onActivated;
        [SerializeField] private UnityEvent _onDeactivated;
        [SerializeField] private Transform _leverPivot;
        [SerializeField] private float _leverAngle = 45f;

        public bool IsOn => _isOn;

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            _isOn = !_isOn;

            if (_isOn)
                _onActivated?.Invoke();
            else
                _onDeactivated?.Invoke();

            // TODO: Animate lever pivot rotation
            Debug.Log($"[NexusForge.Interaction] Lever switched {(_isOn ? "ON" : "OFF")}");
        }
    }
}
