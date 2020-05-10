using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip[] chirps;
    private AudioSource source;
    private float timeBetween;
    private float timeEllapsed = 0;
    private bool counting = false;
    private bool startedPlayback = false;
    private float pitch = 1;
    private bool isPlaying = false;
    public float distance = 10f;

    private Vector3 noisePositions;

    void Start()
    {
        source = GetComponent<AudioSource>();
        noisePositions = new Vector3(Random.Range(0f, 1000f), Random.Range(0f, 1000f), Random.Range(0f, 1000f));
    }

    float ScaleValue(float input, float inputMin, float inputMax, float outputMin, float outputMax)
    {
        return ((input - inputMin) / (inputMax - inputMin)) * (outputMax - outputMin) + outputMin;
    }

    // Update is called once per frame
    void Update()
    {

        noisePositions.x += .01f;
        noisePositions.y += .01f;
        noisePositions.z += .01f;

        Vector3 positionChange = new Vector3();
        positionChange.x = ScaleValue(Mathf.PerlinNoise(noisePositions.x, 0), 0, 1, -distance, distance);
        positionChange.y = ScaleValue(Mathf.PerlinNoise(noisePositions.y, 0), 0, 1, -distance, distance);
        positionChange.z = ScaleValue(Mathf.PerlinNoise(noisePositions.z, 0), 0, 1, -distance, distance);

        if (transform.position.x + positionChange.x < -4 || transform.position.x + positionChange.x > 4)
            positionChange.x *= -1;
        if (transform.position.y + positionChange.y < -4 || transform.position.y + positionChange.y > 4)
            positionChange.y *= -1;
        if (transform.position.z + positionChange.z < -4 || transform.position.z + positionChange.z > 4)
            positionChange.z *= -1;

        transform.position += positionChange;

        if (!isPlaying) return;


        if (!source.isPlaying & !counting)
        {
            timeEllapsed = 0;
            counting = true;
            timeBetween = Random.Range(0.5f, 5f);
            pitch = Random.Range(-2f, 2f);
            //source.pitch = pitch;
        }

        else if (counting)
        {
            timeEllapsed += Time.deltaTime;
            if (timeEllapsed > timeBetween)
            {
                source.clip = chirps[Random.Range(0, 9)];
                source.Play();
                startedPlayback = true;
                counting = false;
            }
        }

    }

    public void Play()
    {
        isPlaying = true;
        timeBetween = Random.Range(0.5f, 5f);
        pitch = Random.Range(-2f, 2f);

    }

    public void Stop() {
        Debug.Log("Stopping");
        isPlaying = false;
        source.Stop();
        counting = false;
    }

}
