using UnityEngine;

namespace NexusForge.Interaction
{
    /// <summary>
    /// An interactable item that can be picked up by the player.
    /// Adds to inventory and destroys the world object.
    /// </summary>
    public class PickupItem : Interactable
    {
        [SerializeField] private string _itemId;
        [SerializeField] private int _quantity = 1;
        [SerializeField] private AudioClip _pickupSound;
        [SerializeField] private GameObject _pickupVFX;

        public string ItemId => _itemId;
        public int Quantity => _quantity;

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            // TODO: Add to player inventory system
            // TODO: Play pickup sound and VFX
            Debug.Log($"[NexusForge.Interaction] Picked up {_itemId} x{_quantity}");

            if (_pickupVFX != null)
                Instantiate(_pickupVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
