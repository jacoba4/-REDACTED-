using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    Shader inUseShader;
    Material mat;
    Renderer render;
    Color initialColor;
    Color finalColor;
    public CameraViewBox redBox;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        mat = render.material;
        initialColor = mat.color;
        finalColor = new Color(255, 0, 0, .05f);
        mat.color = finalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Solved()
    {
        print("block disable");
        GetComponent<BoxCollider>().enabled = false;
        mat.color = initialColor;
        redBox.off = true;
    }
}
