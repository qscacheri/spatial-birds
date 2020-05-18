﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUISlider : MonoBehaviour
{
    public GUISkin skin;
    private void OnGUI()
    {
        GUI.skin = skin;

        // Now create any Controls you like, and they will be displayed with the custom Skin
        GUILayout.Button("I am a re-Skinned Button");

        // You can change or remove the skin for some Controls but not others
        GUI.skin = null;

        // Any Controls created here will use the default Skin and not the custom Skin
        GUILayout.Button("This Button uses the default UnityGUI Skin");
    }

}