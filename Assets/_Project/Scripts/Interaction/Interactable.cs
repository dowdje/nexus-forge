using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Interaction
{
    /// <summary>
    /// Base class for all interactable objects in the world.
    /// Provides a prompt, range check, and UnityEvent hook.
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private string _promptText = "Interact";
        [SerializeField] private float _interactionRange = 2f;
        [SerializeField] private bool _requireLookAt = true;
        [SerializeField] private UnityEvent _onInteract;

        public string PromptText => _promptText;
        public float InteractionRange => _interactionRange;

        /// <summary>Execute the interaction. Called by the player interaction system.</summary>
        public virtual void Interact(GameObject interactor)
        {
            _onInteract?.Invoke();
        }

        /// <summary>Check if the interactor is within range.</summary>
        public bool IsInRange(Vector3 interactorPosition)
        {
            return Vector3.Distance(transform.position, interactorPosition) <= _interactionRange;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _interactionRange);
        }
    }
}
