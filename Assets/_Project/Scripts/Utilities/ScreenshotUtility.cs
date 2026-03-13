using System;
using UnityEngine;

namespace NexusForge.Utilities
{
    /// <summary>
    /// Captures screenshots at configurable resolution.
    /// Saves to the project's Screenshots folder with timestamp filenames.
    /// </summary>
    public class ScreenshotUtility : MonoBehaviour
    {
        [SerializeField] private int _superSize = 2;
        [SerializeField] private KeyCode _screenshotKey = KeyCode.F12;

        private void Update()
        {
            if (Input.GetKeyDown(_screenshotKey))
                CaptureScreenshot();
        }

        /// <summary>Capture a screenshot and save to disk.</summary>
        public void CaptureScreenshot()
        {
            string folder = $"{Application.dataPath}/../Screenshots";
            System.IO.Directory.CreateDirectory(folder);
            string filename = $"NexusForge_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
            string path = $"{folder}/{filename}";
            UnityEngine.ScreenCapture.CaptureScreenshot(path, _superSize);
            Debug.Log($"[NexusForge] Screenshot saved: {path}");
        }
    }
}
