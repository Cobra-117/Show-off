using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireworksGradient : MonoBehaviour
{
    public VisualEffect vfxGraph;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         Gradient gradient = new Gradient();

        // Customize the gradient based on your requirements
        Color[] colors = new Color[3];
        colors[0] = new Color(1f, 1f, 1f); 
        colors[1] = new Color(0f, 1f, 1f); 
        colors[2] = new Color(1f, 0.5f, 0f); 

        float[] intensities = new float[2];
        intensities[0] = 10f;
        intensities[1] = 4f;


        GradientColorKey[] colorKeys = new GradientColorKey[3];
        colorKeys[0].color = colors[0] * intensities[0];
        colorKeys[0].time = 0f;

        colorKeys[1].color = colors[1] *intensities[1];
        colorKeys[1].time = 0.06f; // 6% of the gradient

        colorKeys[2].color = colors[2];
        colorKeys[2].time = 1f;

        gradient.colorKeys = colorKeys;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1f; // Starting alpha value (255)
        alphaKeys[0].time = 0f;

        alphaKeys[1].alpha = 188f / 255f; // Ending alpha value (188)
        alphaKeys[1].time = 1f;

        gradient.alphaKeys = alphaKeys;

        // Assign the gradient to the VFX Graph
        vfxGraph.SetGradient("Gradient balls", gradient);
    }
}