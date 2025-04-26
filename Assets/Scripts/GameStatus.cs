using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public bool GameOver { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        GameOver = false;
    }

}
