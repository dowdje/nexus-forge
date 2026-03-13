using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Interaction
{
    /// <summary>
    /// A door that can be opened/closed via interaction or events.
    /// Supports rotation-based and sliding door animations.
    /// </summary>
    public class Door : Interactable
    {
        public enum DoorType { Rotating, Sliding }

        [SerializeField] private DoorType _doorType = DoorType.Rotating;
        [SerializeField] private float _openAngle = 90f;
        [SerializeField] private Vector3 _slideOffset = Vector3.up * 3f;
        [SerializeField] private float _openSpeed = 2f;
        [SerializeField] private bool _isLocked;
        [SerializeField] private AudioClip _openSound;
        [SerializeField] private AudioClip _closeSound;
        [SerializeField] private AudioClip _lockedSound;
        [SerializeField] private UnityEvent _onOpened;
        [SerializeField] private UnityEvent _onClosed;

        private bool _isOpen;
        private Coroutine _animationCoroutine;

        public bool IsOpen => _isOpen;
        public bool IsLocked { get => _isLocked; set => _isLocked = value; }

        public override void Interact(GameObject interactor)
        {
            if (_isLocked)
            {
                // TODO: Play locked sound, show "locked" prompt
                Debug.Log("[NexusForge.Interaction] Door is locked");
                return;
            }

            base.Interact(interactor);
            _isOpen = !_isOpen;

            // TODO: Start open/close animation coroutine based on DoorType
            if (_isOpen)
                _onOpened?.Invoke();
            else
                _onClosed?.Invoke();

            Debug.Log($"[NexusForge.Interaction] Door {(_isOpen ? "opened" : "closed")}");
        }

        /// <summary>Unlock the door programmatically (e.g., from a key pickup or lever).</summary>
        public void Unlock()
        {
            _isLocked = false;
            Debug.Log("[NexusForge.Interaction] Door unlocked");
        }
    }
}
