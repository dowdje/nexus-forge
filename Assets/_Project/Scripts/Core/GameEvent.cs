using System.Collections.Generic;
using UnityEngine;

namespace NexusForge.Core
{
    /// <summary>
    /// ScriptableObject-based event channel for decoupled communication.
    /// Create instances via Assets > Create > NexusForge > Events > Game Event.
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameEvent", menuName = "NexusForge/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new();

        /// <summary>Raise the event, notifying all registered listeners.</summary>
        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        /// <summary>Register a listener to receive this event.</summary>
        public void Register(GameEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        /// <summary>Unregister a listener from this event.</summary>
        public void Unregister(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}
