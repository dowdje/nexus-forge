using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NexusForge.Core
{
    /// <summary>
    /// Utility for async scene loading with progress reporting.
    /// </summary>
    public static class SceneLoader
    {
        /// <summary>Event fired during load with progress 0-1.</summary>
        public static event Action<float> OnLoadProgress;

        /// <summary>Load a scene asynchronously with optional progress callbacks.</summary>
        public static IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var op = SceneManager.LoadSceneAsync(sceneName, mode);
            if (op == null) yield break;

            op.allowSceneActivation = false;

            while (op.progress < 0.9f)
            {
                OnLoadProgress?.Invoke(op.progress / 0.9f);
                yield return null;
            }

            OnLoadProgress?.Invoke(1f);
            op.allowSceneActivation = true;
        }

        /// <summary>Unload a scene asynchronously.</summary>
        public static IEnumerator UnloadSceneAsync(string sceneName)
        {
            var op = SceneManager.UnloadSceneAsync(sceneName);
            if (op == null) yield break;
            while (!op.isDone) yield return null;
        }
    }
}
