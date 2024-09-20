using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _followtarget;
    [SerializeField] private float _step;
    private Vector3 _offset;

    private Vector3 _positionTarget;

    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        _offset = _camera.transform.position - _followtarget.position;
    }

    private void LateUpdate()
    {
        _positionTarget = new Vector3(_followtarget.position.x + _offset.x, _followtarget.position.y + _offset.y, _followtarget.position.z + _offset.z);

        _camera.transform.position = Vector3.Lerp(transform.position, _positionTarget, _step * Time.deltaTime);
    }
}
