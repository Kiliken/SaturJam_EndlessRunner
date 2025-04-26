using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform _target;

    private Transform _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _camera.position = Vector3.MoveTowards(_camera.position, new Vector3(_camera.position.x, _target.position.y + 2f, _camera.position.z), Time.deltaTime);
                           //new Vector3(_camera.position.x, _target.position.y + 2f, _camera.position.z);
    }
}
