using System.Collections.Generic;
using UnityEngine;
using NexusForge.Core;

namespace NexusForge.Audio
{
    /// <summary>
    /// Centralized audio management. Handles music, SFX, and ambient audio
    /// with pooled AudioSources for performance.
    /// </summary>
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Sources")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _ambienceSource;

        [Header("Settings")]
        [SerializeField] private int _sfxPoolSize = 16;
        [SerializeField, Range(0f, 1f)] private float _masterVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float _musicVolume = 0.7f;
        [SerializeField, Range(0f, 1f)] private float _sfxVolume = 1f;
        [SerializeField, Range(0f, 1f)] private float _ambienceVolume = 0.5f;

        private readonly List<AudioSource> _sfxPool = new();

        private void Start()
        {
            // Initialize SFX pool
            for (int i = 0; i < _sfxPoolSize; i++)
            {
                var go = new GameObject($"SFX_Source_{i}");
                go.transform.SetParent(transform);
                var source = go.AddComponent<AudioSource>();
                source.playOnAwake = false;
                _sfxPool.Add(source);
            }
        }

        /// <summary>Play a one-shot sound effect.</summary>
        public void PlaySFX(AudioClip clip, float volumeScale = 1f)
        {
            if (clip == null) return;
            var source = GetAvailableSFXSource();
            if (source == null) return;
            source.volume = _sfxVolume * _masterVolume * volumeScale;
            source.PlayOneShot(clip);
        }

        /// <summary>Play a sound effect at a world position.</summary>
        public void PlaySFXAtPoint(AudioClip clip, Vector3 position, float volumeScale = 1f)
        {
            if (clip == null) return;
            AudioSource.PlayClipAtPoint(clip, position, _sfxVolume * _masterVolume * volumeScale);
        }

        /// <summary>Cross-fade to a new music track.</summary>
        public void PlayMusic(AudioClip clip, float fadeDuration = 1f)
        {
            if (_musicSource == null || clip == null) return;
            // TODO: Implement cross-fade with coroutine
            _musicSource.clip = clip;
            _musicSource.volume = _musicVolume * _masterVolume;
            _musicSource.loop = true;
            _musicSource.Play();
        }

        /// <summary>Set the ambient audio track.</summary>
        public void SetAmbience(AudioClip clip)
        {
            if (_ambienceSource == null) return;
            _ambienceSource.clip = clip;
            _ambienceSource.volume = _ambienceVolume * _masterVolume;
            _ambienceSource.loop = true;
            _ambienceSource.Play();
        }

        private AudioSource GetAvailableSFXSource()
        {
            foreach (var source in _sfxPool)
            {
                if (!source.isPlaying) return source;
            }
            return null;
        }
    }
}
