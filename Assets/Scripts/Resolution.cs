using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resolution : MonoBehaviour
{
    public float hSliderValue = 0.0F;
    public int[,] resolutions = { { 640, 480 }, { 1280, 1024 }, { 1920, 1080 } };


    void OnGUI()
    {
        hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 3.0f);
        if (GUI.Button(new Rect(25, 70, 100, 30), "ApplyResolution"))
        {
            int resolutionIndex = Mathf.FloorToInt(hSliderValue);
            Screen.SetResolution(resolutions[resolutionIndex, 0], resolutions[resolutionIndex, 1], true);
        }
    }
}

