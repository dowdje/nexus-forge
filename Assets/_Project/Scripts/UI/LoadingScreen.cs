using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace NexusForge.UI
{
    /// <summary>
    /// Full-screen loading overlay with progress bar, shown during scene transitions.
    /// Subscribes to SceneLoader.OnLoadProgress.
    /// </summary>
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TextMeshProUGUI _progressText;
        [SerializeField] private TextMeshProUGUI _tipText;
        [SerializeField] private string[] _loadingTips;

        private void OnEnable()
        {
            NexusForge.Core.SceneLoader.OnLoadProgress += UpdateProgress;
        }

        private void OnDisable()
        {
            NexusForge.Core.SceneLoader.OnLoadProgress -= UpdateProgress;
        }

        /// <summary>Show the loading screen with a random tip.</summary>
        public void Show()
        {
            if (_loadingPanel != null)
                _loadingPanel.SetActive(true);

            if (_tipText != null && _loadingTips != null && _loadingTips.Length > 0)
                _tipText.text = _loadingTips[Random.Range(0, _loadingTips.Length)];
        }

        /// <summary>Hide the loading screen.</summary>
        public void Hide()
        {
            if (_loadingPanel != null)
                _loadingPanel.SetActive(false);
        }

        private void UpdateProgress(float progress)
        {
            if (_progressBar != null)
                _progressBar.value = progress;
            if (_progressText != null)
                _progressText.text = $"{progress * 100f:F0}%";
        }
    }
}
