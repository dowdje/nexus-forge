using UnityEngine;

namespace NexusForge.Environment
{
    /// <summary>
    /// Manages weather state transitions and applies visual/audio effects.
    /// Supports: Clear, Cloudy, Rain, Storm, Snow, Fog.
    /// </summary>
    public class WeatherController : MonoBehaviour
    {
        public enum WeatherState { Clear, Cloudy, Rain, Storm, Snow, Fog }

        [SerializeField] private WeatherState _currentWeather = WeatherState.Clear;
        [SerializeField] private float _transitionDuration = 5f;

        [Header("VFX References")]
        [SerializeField] private ParticleSystem _rainParticles;
        [SerializeField] private ParticleSystem _snowParticles;
        [SerializeField] private ParticleSystem _fogParticles;

        [Header("Audio")]
        [SerializeField] private AudioSource _weatherAudioSource;
        [SerializeField] private AudioClip _rainAmbience;
        [SerializeField] private AudioClip _stormAmbience;
        [SerializeField] private AudioClip _windAmbience;

        public WeatherState CurrentWeather => _currentWeather;

        private float _transitionProgress = 1f;
        private WeatherState _targetWeather;

        /// <summary>Begin transitioning to a new weather state.</summary>
        public void SetWeather(WeatherState newWeather)
        {
            if (newWeather == _currentWeather) return;
            _targetWeather = newWeather;
            _transitionProgress = 0f;
        }

        private void Update()
        {
            if (_transitionProgress >= 1f) return;

            _transitionProgress += Time.deltaTime / _transitionDuration;
            if (_transitionProgress >= 1f)
            {
                _currentWeather = _targetWeather;
                ApplyWeatherState(_currentWeather);
            }

            // TODO: Lerp VFX emission rates, audio volumes, fog density during transition
        }

        private void ApplyWeatherState(WeatherState state)
        {
            // TODO: Enable/disable particle systems, set audio clips, adjust HDRP fog
            Debug.Log($"[NexusForge.Environment] Weather changed to {state}");
        }
    }
}
