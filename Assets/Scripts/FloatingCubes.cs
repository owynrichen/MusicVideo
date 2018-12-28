using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCubes : MonoBehaviour {

    public AudioPeer _audioPeer;
    public GameObject _sampleCubePrefab;
    public float _positionRange = 50;
    private GameObject[] _cubes = new GameObject[2048];

    private float _curPosRange = 50;

    float pRange() {
        return Random.Range(-_positionRange, _positionRange);
    }

    Vector3 pos() {
        return new Vector3(pRange(), pRange(), pRange());
    }

    public GameObject GetRandomCube() {
        return _cubes[(int)Random.Range(0, 2047)];
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 2048; i++) {
            GameObject _cube = Instantiate<GameObject>(_sampleCubePrefab);
            _cube.transform.position = this.transform.position;
            // _cube.transform.localPosition = new Vector3(2.5, 2.5, 2.5);
            _cube.transform.parent = this.transform;
            _cube.transform.name = "Cube" + i;
            _cube.transform.localScale = new Vector3(5, 5, 5);
            _cube.transform.rotation = Random.rotation;
            _cube.transform.position = pos();
            
            _cubes[i] = _cube;
        }
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 2048; i++)
        {
            if (_curPosRange != _positionRange) {
                _curPosRange = _positionRange;
                _cubes[i].transform.position = pos();
            }

            _cubes[i].transform.Rotate(Vector3.up, 10 * _audioPeer._audioBandBuffer64[i % 63]);
            _cubes[i].transform.localScale = Vector3.one * 5 * (0.5f + _audioPeer._audioBandBuffer64[i % 7]);
        }
    }
}
