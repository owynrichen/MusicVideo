using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfStuff : MonoBehaviour {
    public AudioPeer _audioPeer;
    public GameObject _sampleCubePrefab;
    public float _maxScale;

    private GameObject[] _cubes = new GameObject[64];

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 64; i++) {
            GameObject _cube = Instantiate<GameObject>(_sampleCubePrefab);
            _cube.transform.position = this.transform.position;
            _cube.transform.parent = this.transform;
            _cube.transform.name = "Cube" + i;
            _cube.transform.localScale = new Vector3(10, 10, 10);
            this.transform.eulerAngles = new Vector3(0, 5.625f * i, 0);
            _cube.transform.position = Vector3.forward * 100;
            _cubes[i] = _cube;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 64; i++) {
            _cubes[i].transform.localScale = new Vector3(10, (_audioPeer._audioBandBuffer64[i] * _maxScale) + 2, 10);
        }
	}
}
