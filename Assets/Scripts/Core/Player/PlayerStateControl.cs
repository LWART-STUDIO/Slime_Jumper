using Core.Camera;
using UnityEngine;
using Zenject;

namespace Core.Player
{
    public class PlayerStateControl : MonoBehaviour
    {
        [Inject] private Player _target;
        [Inject] private CameraMover _cameraMover;
        private void Update()
        {
            if (_cameraMover.TargetScreenPosition.y < 0)
            {
                _target.Die();
            }
        }
    }
}
