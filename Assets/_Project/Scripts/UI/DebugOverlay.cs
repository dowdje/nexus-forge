using UnityEngine;
using TMPro;

namespace NexusForge.UI
{
    /// <summary>
    /// Debug overlay showing FPS, player position, velocity, current state,
    /// and other runtime diagnostics. Toggle with F3.
    /// </summary>
    public class DebugOverlay : MonoBehaviour
    {
        [SerializeField] private GameObject _overlayPanel;
        [SerializeField] private TextMeshProUGUI _fpsText;
        [SerializeField] private TextMeshProUGUI _positionText;
        [SerializeField] private TextMeshProUGUI _velocityText;
        [SerializeField] private TextMeshProUGUI _stateText;

        private float _fpsTimer;
        private int _frameCount;

        private void Update()
        {
            if (!_overlayPanel || !_overlayPanel.activeSelf) return;

            // FPS counter
            _fpsTimer += Time.unscaledDeltaTime;
            _frameCount++;
            if (_fpsTimer >= 0.5f)
            {
                if (_fpsText != null)
                    _fpsText.text = $"FPS: {_frameCount / _fpsTimer:F0}";
                _fpsTimer = 0;
                _frameCount = 0;
            }

            // TODO: Read player position, velocity, state from PlayerController
        }

        /// <summary>Toggle the debug overlay visibility.</summary>
        public void Toggle()
        {
            if (_overlayPanel != null)
                _overlayPanel.SetActive(!_overlayPanel.activeSelf);
        }
    }
}
