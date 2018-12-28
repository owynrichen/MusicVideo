using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class CameraMovementFollowCubes : MonoBehaviour {

    public AudioPeer _audioPeer;
    public FloatingCubes _cubes;
    public float _minDistance = 1;
    public float _speed = 0.002f;
    public GameObject _lookTarget;
    private GameObject _target;
    private float _currentDist = 0;
     
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (_target == null) {
            _target = _cubes.GetRandomCube();
            _currentDist = 0;
        }

        _currentDist = _currentDist + (_speed * _audioPeer._AmplitudeBuffer);
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _currentDist);
        float distance = Vector3.Distance(transform.position, _target.transform.position);
        // print(transform.position);
        print("Distance to " + _target.name + ": " + _currentDist);



        if (_lookTarget == null) {
            transform.LookAt(Vector3.Lerp(transform.forward, _target.transform.position, _currentDist));
        }
        else {
            // transform.RotateAround(_target.transform.position, Vector3.up, 20 * Time.deltaTime * _audioPeer._AmplitudeBuffer);
            transform.LookAt(_lookTarget.transform);
        }


        if (distance < _minDistance)
        {
            _target = _cubes.GetRandomCube();
            _currentDist = 0;
        }
    }
}
