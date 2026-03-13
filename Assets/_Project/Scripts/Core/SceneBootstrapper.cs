using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NexusForge.Core
{
    /// <summary>
    /// Entry point for the game. Loads from Boot.unity, initializes persistent
    /// managers, then loads the first gameplay scene.
    /// </summary>
    public class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private string _firstSceneName = "Sandbox";

        private IEnumerator Start()
        {
            // TODO: Initialize persistent manager systems (audio, input, save, etc.)
            Debug.Log("[NexusForge] Bootstrapping...");

            yield return SceneLoader.LoadSceneAsync(_firstSceneName, LoadSceneMode.Additive);

            Debug.Log($"[NexusForge] Loaded {_firstSceneName}");
        }
    }
}
