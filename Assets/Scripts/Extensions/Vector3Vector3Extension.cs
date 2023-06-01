using UnityEngine;

namespace Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 RandomPointOnCircleEdge(float radius,Vector3 position)
        {
            var vector2 = Random.insideUnitCircle.normalized * radius;
            return new Vector3(vector2.x, vector2.y, 0)+position;
        }
    }
}
