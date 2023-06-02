using System;
using Core.Walls;
using Obi;
using UnityEngine;

namespace Core.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform _wallCheck;
        [SerializeField] private float _wallSlideSpeed;
        [SerializeField] private Vector2 _jumpVelocity;

        private Rigidbody _rigidbody;
        private float _wallCheckRadius = 0.5f;
        private int _jumpDirectionX = 1;
        private int _maxJumpCount = 2;
        private int _currentJumpCount;
        private float _currentJumpTime;
        private float _maxJumpTime = 0.5f;

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Jump();
        }

        private void FixedUpdate()
        {
            Collider[] colliders = Physics.OverlapSphere(_wallCheck.position, _wallCheckRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<Wall>())
                {
                    _currentJumpCount = 0;
                    _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, Mathf.Clamp(_rigidbody.velocity.y, -_wallSlideSpeed, float.MaxValue));
                    return;
                }
            }
            
        }

        private void Jump()
        {
            Vector2 velocity;
        
            if (Input.GetMouseButton(0) && _currentJumpTime < _maxJumpTime && _currentJumpCount < _maxJumpCount)
            {
                _currentJumpTime += Time.deltaTime;
                velocity = new Vector2(_jumpDirectionX * _jumpVelocity.x, _jumpVelocity.y);
                _rigidbody.velocity = velocity;
           
            }

            if (Input.GetMouseButtonUp(0) && _currentJumpCount < _maxJumpCount)
            {
                _currentJumpTime = 0;
                _currentJumpCount++;
                Flip();
            }
        }

        private void Flip()
        {
            _jumpDirectionX *= -1;
        }

        public void ResetFlip()
        {
            _jumpDirectionX = 1;
        }
    }
}
