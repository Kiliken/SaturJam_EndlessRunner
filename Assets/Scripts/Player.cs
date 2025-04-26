using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    private float[] _posPos = {-2,0,2};

    private Rigidbody _rb;
    private Transform _transform;


    private Vector2 _mousePos;
    
    private bool _isJumping = false;

    [SerializeField]
    GameStatus _status;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_status.GameOver)
            return;

        if (!Physics.Raycast(_transform.position, Vector3.down, out var hit, 100f, ~LayerMask.NameToLayer("Player"))) 
            Debug.LogError("No Raycast");

        if (hit.distance <= 0.99f)
            _isJumping = false;

        Inputs();
    }

    void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float y = Input.mousePosition.y - _mousePos.y;
            float x = Input.mousePosition.x - _mousePos.x;
            if (y < Mathf.Abs(x * 2))
            {
                if (x > 0)
                    Move('R');
                else
                    Move('L');
            }
            else
                Jump();
        }
    }

    private void Jump()
    {
        if (_isJumping)
            return;

        _isJumping = true;

        _transform.position = _transform.position + new Vector3(0, 3, 0);

    }

    private void Move(char side)
    {
        if (_transform.position.x == _posPos[0] && side == 'L')
            return;
        if (_transform.position.x == _posPos[2] && side == 'R')
            return;

        switch (side)
        {
            case 'R':
                _transform.position = _transform.position + new Vector3(2,0,0);
                break;
            case 'L':
                _transform.position = _transform.position + new Vector3(-2, 0, 0);
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            _status.GameOver = true;
        }
    }
}
