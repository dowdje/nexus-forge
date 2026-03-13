using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Core
{
    /// <summary>
    /// MonoBehaviour that subscribes to a GameEvent and invokes a UnityEvent response.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _response;

        private void OnEnable() => _gameEvent?.Register(this);
        private void OnDisable() => _gameEvent?.Unregister(this);

        /// <summary>Called when the subscribed event is raised.</summary>
        public void OnEventRaised() => _response?.Invoke();
    }
}
