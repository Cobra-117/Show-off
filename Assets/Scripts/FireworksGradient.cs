using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireworksGradient : MonoBehaviour
{
    public VisualEffect vfxGraph;

    // Update is called once per frame
    public void ChangeColor(int winnerID)
    {
        Gradient gradient = new Gradient();
        Color[] colors = new Color[3];


        switch (winnerID)
        {
            case 1:
                colors[1] = new Color(0f, 0f, 1f);
                break;
            case 2:
                colors[1] = new Color(1f, 0f, 0f);
                break;
            case 3:
                colors[1] = new Color(0f, 1f, 0f);
                break;
            case 4:
                colors[1] = new Color(1f, 0.92f, 0.016f);
                break;
            case 5:
                colors[1] = new Color(1.0f, 0.64f, 0.0f);
                break;
            case 6:
                // code block
                break;
            case 7:
                // code block
                break;
            case 8:
                // code block
                break;
            default:
                // code block
                break;
        }

        // Customize the gradient based on your requirements
        
        colors[0] = new Color(1f, 1f, 1f);
        //color from player is set in switch above
        colors[2] = new Color(1f, 0.5f, 0f);

        float[] intensities = new float[3];
        intensities[0] = 10f;
        intensities[1] = 10f;
        intensities[2] = 4f;

        GradientColorKey[] colorKeys = new GradientColorKey[3];
        colorKeys[0].color = colors[0] * intensities[0];
        colorKeys[0].time = 0f;

        colorKeys[1].color = colors[1] * intensities[1];
        colorKeys[1].time = 0.06f; // 6% of the gradient

        colorKeys[2].color = colors[2]*intensities[2];
        colorKeys[2].time = 1f;

        gradient.colorKeys = colorKeys;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1f; // Starting alpha value (255)
        alphaKeys[0].time = 0f;

        alphaKeys[1].alpha = 0.3f; // Ending alpha value (188)
        alphaKeys[1].time = 1f;

        gradient.alphaKeys = alphaKeys;

        // Assign the gradient to the VFX Graph
        vfxGraph.SetGradient("Gradient balls", gradient);
    }
}
