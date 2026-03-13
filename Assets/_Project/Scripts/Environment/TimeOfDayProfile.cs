using UnityEngine;

namespace NexusForge.Environment
{
    /// <summary>
    /// ScriptableObject defining visual parameters for a specific time of day or biome mood.
    /// Used by DayNightCycle to blend lighting, sky, and fog settings.
    /// </summary>
    [CreateAssetMenu(fileName = "NewTimeOfDayProfile", menuName = "NexusForge/Environment/Time of Day Profile")]
    public class TimeOfDayProfile : ScriptableObject
    {
        [Header("Sun")]
        [SerializeField] private Gradient _sunColor;
        [SerializeField] private AnimationCurve _sunIntensity = AnimationCurve.Linear(0, 0, 1, 1);

        [Header("Ambient")]
        [SerializeField] private Gradient _ambientColor;
        [SerializeField] private AnimationCurve _ambientIntensity = AnimationCurve.Linear(0, 0.2f, 1, 0.2f);

        [Header("Fog")]
        [SerializeField] private Gradient _fogColor;
        [SerializeField] private AnimationCurve _fogDensity = AnimationCurve.Linear(0, 0.01f, 1, 0.01f);

        [Header("Sky")]
        [SerializeField] private AnimationCurve _skyExposure = AnimationCurve.Linear(0, 1, 1, 1);

        public Gradient SunColor => _sunColor;
        public AnimationCurve SunIntensity => _sunIntensity;
        public Gradient AmbientColor => _ambientColor;
        public AnimationCurve AmbientIntensity => _ambientIntensity;
        public Gradient FogColor => _fogColor;
        public AnimationCurve FogDensity => _fogDensity;
        public AnimationCurve SkyExposure => _skyExposure;
    }
}
