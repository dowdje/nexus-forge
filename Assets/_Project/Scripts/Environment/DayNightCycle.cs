using UnityEngine;

namespace NexusForge.Environment
{
    /// <summary>
    /// Controls the day/night cycle by rotating a directional light (sun) and
    /// updating lighting/sky parameters over a configurable day length.
    /// Default full cycle: 24 minutes.
    /// </summary>
    public class DayNightCycle : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Light _sunLight;
        [SerializeField] private TimeOfDayProfile _profile;

        [Header("Cycle Settings")]
        [SerializeField] private float _dayLengthMinutes = 24f;
        [SerializeField, Range(0f, 1f)] private float _timeOfDay = 0.25f;
        [SerializeField] private bool _pauseCycle;

        /// <summary>Current time of day normalized 0-1 (0 = midnight, 0.25 = sunrise, 0.5 = noon).</summary>
        public float TimeOfDay => _timeOfDay;

        private void Update()
        {
            if (_pauseCycle || _dayLengthMinutes <= 0) return;

            _timeOfDay += Time.deltaTime / (_dayLengthMinutes * 60f);
            if (_timeOfDay >= 1f) _timeOfDay -= 1f;

            UpdateSun();
            UpdateLighting();
        }

        private void UpdateSun()
        {
            if (_sunLight == null) return;
            // Rotate sun: 0 = below horizon, 0.25 = sunrise (0°), 0.5 = noon (90°), 0.75 = sunset (180°)
            float sunAngle = (_timeOfDay - 0.25f) * 360f;
            _sunLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);
        }

        private void UpdateLighting()
        {
            if (_profile == null || _sunLight == null) return;

            _sunLight.color = _profile.SunColor.Evaluate(_timeOfDay);
            _sunLight.intensity = _profile.SunIntensity.Evaluate(_timeOfDay);

            // TODO: Update HDRP Volume profile fog, ambient, and sky exposure
            // via VolumeProfile overrides at runtime
        }

        /// <summary>Set time of day directly (0-1).</summary>
        public void SetTimeOfDay(float t)
        {
            _timeOfDay = Mathf.Repeat(t, 1f);
            UpdateSun();
            UpdateLighting();
        }
    }
}
