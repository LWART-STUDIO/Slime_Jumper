using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody),typeof(PlayerMover))]
    public class Player : MonoBehaviour
    {
        public event UnityAction Dead;
        private Rigidbody _rigidbody;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerMover = GetComponent<PlayerMover>();
        }

        public void Die()
        {
            _rigidbody.isKinematic = true;
            _rigidbody.Sleep();
            Dead?.Invoke();
        }

        public void Restart()
        {
            
            _rigidbody.position=Vector3.zero;
            _rigidbody.WakeUp();
            _rigidbody.isKinematic = false;
            _playerMover.ResetFlip();
        }

        
    }
}
