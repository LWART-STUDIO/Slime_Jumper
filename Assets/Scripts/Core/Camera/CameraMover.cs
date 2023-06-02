using UnityEngine;
using Zenject;

namespace Core.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraMover : MonoBehaviour
    {
        [Inject] private Player.Player _target;
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _horizontalSpeed;
        [SerializeField] private float _shearEdge;
    
        private UnityEngine.Camera _camera;
        private Vector2 _targetScreenPosition;
        private float _widthEdgeInPixel;
        private float _heightEdgeInPixel;
        private Vector3 _startPosition;

        public Vector2 TargetScreenPosition => _targetScreenPosition;
    
        private void OnEnable()
        {
            _camera = GetComponent<UnityEngine.Camera>();
            _widthEdgeInPixel = _shearEdge * _camera.pixelWidth;
            _heightEdgeInPixel = 0.5f * _camera.pixelHeight;
            _startPosition = transform.position;
        }
    
       
    
        private void FixedUpdate()
        {
            _targetScreenPosition = _camera.WorldToScreenPoint(_target.transform.position);
            Vector3 cameraPosition = _camera.transform.position;
    
            if (_targetScreenPosition.x < _widthEdgeInPixel || _targetScreenPosition.x > _camera.pixelWidth - _widthEdgeInPixel)
            {
                cameraPosition.x = Mathf.MoveTowards(_camera.transform.position.x, _target.transform.position.x, _horizontalSpeed * Time.deltaTime);
                _camera.transform.position = cameraPosition;
            }
    
            if( _targetScreenPosition.y > _heightEdgeInPixel)
            {
                cameraPosition.y = Mathf.MoveTowards(_camera.transform.position.y, _target.transform.position.y, _verticalSpeed * Time.deltaTime);
                _camera.transform.position = cameraPosition;
            }
            
        }

        public void MoveToStartPoint()
        {
            _camera.transform.position = _startPosition;
        }

    }
}
