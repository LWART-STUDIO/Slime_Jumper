using System;
using Core.Camera;
using UnityEngine;
using Zenject;

namespace Core.Level
{
    public class LevelProgressControl : MonoBehaviour
    {
        [Inject] private Player.Player _player;
        [Inject] private CameraMover _cameraMover;

        private void OnEnable()
        {
            _player.Dead += Restart;
        }

        private void Restart()
        {
            _cameraMover.MoveToStartPoint();
            _player.Restart();
        }

        private void OnDisable()
        {
            _player.Dead -= Restart;
        }
    }
}
