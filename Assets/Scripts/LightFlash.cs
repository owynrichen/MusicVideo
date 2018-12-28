using UnityEngine;
using System.Collections;

public class LightFlash : MonoBehaviour
{
    public AudioPeer _audioPeer;
    public float _baseIntensity = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Light l = GetComponent<Light>();
        l.intensity = _baseIntensity * _audioPeer._AmplitudeBuffer;
    }
}
