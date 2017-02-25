using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHologram : MonoBehaviour {

    public int matIndex = 0;
    public Vector2 AnimRate = new Vector2(1.0f, 0.0f);
    public string textureName = "_MainTex";

    Vector2 Offset = Vector2.zero;

    private void LateUpdate()
    {
        Offset += (AnimRate * Time.deltaTime);

        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[matIndex].SetTextureOffset(textureName, Offset);
        }
    }


}
