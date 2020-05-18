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

    public Slider numBirdsSlider;
    public Slider birdDistSlider;

    void Start() {

        playButton.onClick.AddListener(HandlePlayback);

        numBirdsSlider.onValueChanged.AddListener(delegate { HandleBirdCountChanged(); });
        birdDistSlider.onValueChanged.AddListener(delegate { HandleBirdDistChanged(); });

        birds = new GameObject[25];
        for (int i = 0; i < 25; i++)
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

    void HandleBirdCountChanged() {
        Debug.Log(numBirdsSlider.value);
        numBirds = (int) numBirdsSlider.value;
        for (int i = 0; i < 25; i++)
        {
            if (i > numBirds) birds[i].GetComponent<Bird>().Stop();
            else birds[i].GetComponent<Bird>().Play();
        }

    }

    void HandleBirdDistChanged()
    {
        for (int i = 0; i < 25; i++)
        {
            birds[i].GetComponent<Bird>().distance = birdDistSlider.value;
        }
    }

}
