using System.Collections.Generic;
using UnityEngine;

namespace NexusForge.Core
{
    /// <summary>
    /// Generic ScriptableObject-based event channel carrying a payload of type T.
    /// </summary>
    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<TypedGameEventListener<T>> _listeners = new();

        /// <summary>Raise the event with a typed payload.</summary>
        public void Raise(T value)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }

        /// <summary>Register a typed listener to receive this event.</summary>
        public void Register(TypedGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        /// <summary>Unregister a typed listener from this event.</summary>
        public void Unregister(TypedGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }

    /// <summary>Event channel carrying an int payload.</summary>
    [CreateAssetMenu(fileName = "NewIntEvent", menuName = "NexusForge/Events/Int Event")]
    public class IntGameEvent : GameEvent<int> { }

    /// <summary>Event channel carrying a float payload.</summary>
    [CreateAssetMenu(fileName = "NewFloatEvent", menuName = "NexusForge/Events/Float Event")]
    public class FloatGameEvent : GameEvent<float> { }

    /// <summary>Event channel carrying a string payload.</summary>
    [CreateAssetMenu(fileName = "NewStringEvent", menuName = "NexusForge/Events/String Event")]
    public class StringGameEvent : GameEvent<string> { }

    /// <summary>Event channel carrying a Vector3 payload.</summary>
    [CreateAssetMenu(fileName = "NewVector3Event", menuName = "NexusForge/Events/Vector3 Event")]
    public class Vector3GameEvent : GameEvent<Vector3> { }
}
