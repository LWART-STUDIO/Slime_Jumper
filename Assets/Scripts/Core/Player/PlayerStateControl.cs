using Core.Camera;
using UnityEngine;

namespace Core.Player
{
    public class PlayerStateControl : MonoBehaviour
    {
        [SerializeField] private Player _target;
        [SerializeField] private CameraMover _cameraMover;
        private void Update()
        {
            if (_cameraMover.TargetScreenPosition.y < 0)
            {
                _target.Die();
            }
        }
    }
}
