using UnityEngine;
using TMPro;

namespace NexusForge.UI
{
    /// <summary>
    /// Controls the heads-up display: health bar, stamina bar, interaction prompts,
    /// and contextual indicators.
    /// </summary>
    public class HUDController : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private RectTransform _healthBarFill;
        [SerializeField] private TextMeshProUGUI _healthText;

        [Header("Stamina")]
        [SerializeField] private RectTransform _staminaBarFill;

        [Header("Interaction")]
        [SerializeField] private GameObject _interactionPromptPanel;
        [SerializeField] private TextMeshProUGUI _interactionPromptText;

        [Header("Crosshair")]
        [SerializeField] private GameObject _crosshair;

        /// <summary>Update the health bar display.</summary>
        public void SetHealth(float current, float max)
        {
            if (_healthBarFill != null)
                _healthBarFill.localScale = new Vector3(Mathf.Clamp01(current / max), 1, 1);
            if (_healthText != null)
                _healthText.text = $"{Mathf.CeilToInt(current)}/{Mathf.CeilToInt(max)}";
        }

        /// <summary>Update the stamina bar display.</summary>
        public void SetStamina(float current, float max)
        {
            if (_staminaBarFill != null)
                _staminaBarFill.localScale = new Vector3(Mathf.Clamp01(current / max), 1, 1);
        }

        /// <summary>Show or hide the interaction prompt.</summary>
        public void ShowInteractionPrompt(string text)
        {
            if (_interactionPromptPanel != null)
                _interactionPromptPanel.SetActive(true);
            if (_interactionPromptText != null)
                _interactionPromptText.text = text;
        }

        /// <summary>Hide the interaction prompt.</summary>
        public void HideInteractionPrompt()
        {
            if (_interactionPromptPanel != null)
                _interactionPromptPanel.SetActive(false);
        }
    }
}
