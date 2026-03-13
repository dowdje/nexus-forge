using System;
using System.IO;
using UnityEngine;

namespace NexusForge.Utilities
{
    /// <summary>
    /// Captures screenshots at configurable resolution.
    /// Saves to the project's Screenshots folder with timestamp filenames.
    /// Uses a RenderTexture approach to avoid the ScreenCaptureModule dependency.
    /// </summary>
    public class ScreenshotUtility : MonoBehaviour
    {
        [SerializeField] private int _superSize = 2;
        [SerializeField] private KeyCode _screenshotKey = KeyCode.F12;

        private void Update()
        {
            if (Input.GetKeyDown(_screenshotKey))
                StartCoroutine(CaptureScreenshot());
        }

        /// <summary>Capture a screenshot and save to disk.</summary>
        public System.Collections.IEnumerator CaptureScreenshot()
        {
            yield return new WaitForEndOfFrame();

            int w = Screen.width * _superSize;
            int h = Screen.height * _superSize;
            var tex = new Texture2D(w, h, TextureFormat.RGB24, false);

            var rt = RenderTexture.GetTemporary(w, h, 24);
            var cam = Camera.main;
            if (cam == null) yield break;

            cam.targetTexture = rt;
            cam.Render();

            RenderTexture.active = rt;
            tex.ReadPixels(new Rect(0, 0, w, h), 0, 0);
            tex.Apply();

            cam.targetTexture = null;
            RenderTexture.active = null;
            RenderTexture.ReleaseTemporary(rt);

            string folder = Path.Combine(Application.dataPath, "..", "Screenshots");
            Directory.CreateDirectory(folder);
            string filename = $"NexusForge_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
            string path = Path.Combine(folder, filename);

            File.WriteAllBytes(path, tex.EncodeToPNG());
            Destroy(tex);

            Debug.Log($"[NexusForge] Screenshot saved: {path}");
        }
    }
}
