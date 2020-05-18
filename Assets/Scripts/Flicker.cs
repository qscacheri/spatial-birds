using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    private float rotation = 45f;
    private float noisePos;
    public float minRotation = 10;
    public float maxRotation = 45;
    // Start is called before the first frame update
    void Start()
    {
        noisePos = Random.Range(0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        noisePos += .01f;
        rotation = ScaleValue(Mathf.PerlinNoise(noisePos, 0), 0f, 1f, minRotation, maxRotation);
        transform.rotation = Quaternion.Euler(rotation, 0, 0);
    }

    float ScaleValue(float input, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return ((input - inputMin) / (inputMax - inputMin)) * (outputMax - outputMin) + outputMin;
    }

}
