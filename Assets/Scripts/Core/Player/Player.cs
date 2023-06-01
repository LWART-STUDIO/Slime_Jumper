using UnityEngine;
using UnityEngine.Events;

namespace Core.Player
{
    public class Player : MonoBehaviour
    {
        public event UnityAction Dead;

        public void Die()
        {
            Dead?.Invoke();
        }

        
    }
}
