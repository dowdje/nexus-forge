using UnityEngine;

namespace NexusForge.CameraSystem
{
    /// <summary>
    /// Manages Cinemachine virtual camera priorities based on character state.
    /// Handles blending between exploration, climbing, aiming, freelook, and cutscene cameras.
    /// </summary>
    /// <remarks>
    /// Virtual cameras are configured in the Unity Editor with Cinemachine.
    /// This script controls priority values to trigger blends.
    /// Default blend: 0.3s EaseInOut.
    ///
    /// Expected virtual cameras:
    /// - ThirdPersonFollow: Default exploration camera
    /// - ClimbCamera: Tighter framing during wall climb/ledge
    /// - AimCamera: Over-shoulder aim with reduced FOV
    /// - FreeLookCamera: Debug free-look camera
    /// - CutsceneCamera: Timeline-driven camera
    /// </remarks>
    public class CameraManager : MonoBehaviour
    {
        [Header("Virtual Cameras (assign in Inspector)")]
        [SerializeField] private GameObject _thirdPersonCam;
        [SerializeField] private GameObject _climbCam;
        [SerializeField] private GameObject _aimCam;
        [SerializeField] private GameObject _freeLookCam;
        [SerializeField] private GameObject _cutsceneCam;

        private const int PriorityActive = 20;
        private const int PriorityInactive = 10;

        public enum CameraMode { ThirdPerson, Climb, Aim, FreeLook, Cutscene }

        private CameraMode _currentMode = CameraMode.ThirdPerson;
        public CameraMode CurrentMode => _currentMode;

        /// <summary>Switch to a new camera mode by adjusting Cinemachine priorities.</summary>
        public void SetCameraMode(CameraMode mode)
        {
            _currentMode = mode;
            // TODO: Get CinemachineCamera components and set Priority values
            // Active camera gets PriorityActive, all others get PriorityInactive
            Debug.Log($"[NexusForge.Camera] Switched to {mode} camera");
        }
    }
}
