using System;
using Core.Walls;
using Extensions;
using UnityEngine;

namespace Core.Player
{
    public class ParticleCreate : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;

        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.collider.GetComponent<Wall>())
            {
                var point = collision.contacts[0].point;
                var position = point + (transform.position - point).normalized * 0.1f;
                _particle.Spawn(point, Quaternion.identity);
                _particle.transform.up=(transform.position - point).normalized;
            }
        }
    }
}
