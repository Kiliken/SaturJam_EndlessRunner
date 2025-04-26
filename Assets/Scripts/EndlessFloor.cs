using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EndlessFloor : MonoBehaviour
{
    [SerializeField]
    GameStatus _status;

    [SerializeField]
    private GameObject[] _prefabs;

    [SerializeField]
    private float _speed;

    private List<GameObject> _tiles = new List<GameObject>();

    private int _tileNum = 6;

    [SerializeField]
    Text _timeText;

    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        float pos = -30;
        _tiles.Add(Instantiate(_prefabs[0], this.transform));
        _tiles[0].transform.position = new Vector3(0, 0, pos);
        pos += 30;
        _tiles.Add(Instantiate(_prefabs[0], this.transform));
        _tiles[1].transform.position = new Vector3(0, 0, pos);
        pos += 30;
        _tiles.Add(Instantiate(_prefabs[0], this.transform));
        _tiles[2].transform.position = new Vector3(0, 0, pos);
        pos += 30;
        for (int i=3; i< _tileNum; i++)
        {
            _tiles.Add(Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], this.transform));
            _tiles[i].transform.position = new Vector3(0, 0, pos);
            pos += 30;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_status.GameOver)
            return;

        _timer += Time.deltaTime * _speed;
        _timeText.text = $"SCORE: {(int)_timer}";
        foreach (GameObject t in _tiles)
        {
            t.transform.position += Vector3.back * _speed *Time.deltaTime;
        }
        if (_tiles[0].transform.position.z < -30)
        {
            Destroy(_tiles[0]);
            _tiles.RemoveAt(0);
            _tiles.Add(Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], this.transform));
            _tiles[_tileNum -1].transform.position = _tiles[_tileNum - 2].transform.position + new Vector3(0,0,30);
        }
    }
}
