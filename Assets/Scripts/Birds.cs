using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Birds : MonoBehaviour
{
    public Button playButton;
    public GameObject bird;
    public int numBirds = 5;
    private GameObject[] birds;
    private bool isPlaying = false;
    void Start() {

        playButton.onClick.AddListener(HandlePlayback);

        birds = new GameObject[numBirds];
        for (int i = 0; i < numBirds; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
            birds[i] = Instantiate(bird, pos, transform.rotation);
            birds[i].transform.SetParent(transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandlePlayback()
    {
        if (isPlaying)
        {
            for (int i = 0; i < numBirds; i++)
            {
                birds[i].GetComponent<Bird>().Stop();
            }
        }

        else
        {
            for (int i = 0; i < numBirds; i++)
            {
                birds[i].GetComponent<Bird>().Play();
            }
        }

        isPlaying = !isPlaying;
    }
}
