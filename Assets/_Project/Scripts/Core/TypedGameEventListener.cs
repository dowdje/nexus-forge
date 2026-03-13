using UnityEngine;
using UnityEngine.Events;

namespace NexusForge.Core
{
    /// <summary>
    /// Generic MonoBehaviour that subscribes to a typed GameEvent and forwards the payload.
    /// </summary>
    public abstract class TypedGameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private GameEvent<T> _gameEvent;
        [SerializeField] private UnityEvent<T> _response;

        private void OnEnable() => _gameEvent?.Register(this);
        private void OnDisable() => _gameEvent?.Unregister(this);

        /// <summary>Called when the subscribed typed event is raised.</summary>
        public void OnEventRaised(T value) => _response?.Invoke(value);
    }

    /// <summary>Listener for int-typed game events.</summary>
    public class IntGameEventListener : TypedGameEventListener<int> { }

    /// <summary>Listener for float-typed game events.</summary>
    public class FloatGameEventListener : TypedGameEventListener<float> { }

    /// <summary>Listener for string-typed game events.</summary>
    public class StringGameEventListener : TypedGameEventListener<string> { }

    /// <summary>Listener for Vector3-typed game events.</summary>
    public class Vector3GameEventListener : TypedGameEventListener<Vector3> { }
}
