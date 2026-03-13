using UnityEngine;

namespace NexusForge.Utilities
{
    /// <summary>
    /// Utility MonoBehaviour for drawing persistent debug gizmos in the scene.
    /// Useful for visualizing trigger zones, paths, and detection ranges.
    /// </summary>
    public class DebugGizmoDrawer : MonoBehaviour
    {
        public enum GizmoShape { Sphere, Cube, WireSphere, WireCube, Line }

        [SerializeField] private GizmoShape _shape = GizmoShape.WireSphere;
        [SerializeField] private Color _color = Color.green;
        [SerializeField] private float _size = 1f;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private Transform _lineEnd;
        [SerializeField] private bool _onlyWhenSelected = true;

        private void OnDrawGizmos()
        {
            if (_onlyWhenSelected) return;
            DrawGizmo();
        }

        private void OnDrawGizmosSelected()
        {
            if (!_onlyWhenSelected) return;
            DrawGizmo();
        }

        private void DrawGizmo()
        {
            Gizmos.color = _color;
            Vector3 pos = transform.position + _offset;

            switch (_shape)
            {
                case GizmoShape.Sphere:
                    Gizmos.DrawSphere(pos, _size);
                    break;
                case GizmoShape.Cube:
                    Gizmos.DrawCube(pos, Vector3.one * _size);
                    break;
                case GizmoShape.WireSphere:
                    Gizmos.DrawWireSphere(pos, _size);
                    break;
                case GizmoShape.WireCube:
                    Gizmos.DrawWireCube(pos, Vector3.one * _size);
                    break;
                case GizmoShape.Line:
                    if (_lineEnd != null)
                        Gizmos.DrawLine(pos, _lineEnd.position);
                    break;
            }
        }
    }
}
