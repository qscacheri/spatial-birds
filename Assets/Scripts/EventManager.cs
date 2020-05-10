using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnSoundStartDelegate();
    public static OnSoundStartDelegate onSoundStart;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
