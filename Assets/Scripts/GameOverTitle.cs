using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTitle : MonoBehaviour
{
    [SerializeField]
    GameObject _titleButton;

    [SerializeField]
    GameObject _gameOverText;

    [SerializeField]
    GameStatus _status;

    // Update is called once per frame
    void Update()
    {
        if (_status.GameOver)
        {
            _titleButton.SetActive(true);
            _gameOverText.SetActive(true);
        }
    }
}
