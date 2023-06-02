using System;
using Extensions;
using UnityEngine;

namespace Core.VFX
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ReturnParticleToPool : MonoBehaviour
    {
        private void OnParticleSystemStopped()
        {
            gameObject.Recycle();
        }
    }
}
