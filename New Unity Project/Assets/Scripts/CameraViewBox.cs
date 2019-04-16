using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewBox : MonoBehaviour
{
    Shader inUseShader;
    Material mat;
    Renderer render;
    Color initialColor;
    Color finalColor;

    public bool off;
    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        mat = render.material;
        initialColor = new Color(0, 0, 0, 0f);
        finalColor = new Color(255, 0, 0, .02f);
        mat.color = finalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (off == true && done == false)
        {
            Solve();
            done = true;
        }
    }
    void Solve()
    {
        //GetComponent<BoxCollider>().enabled = false;
        mat.color = initialColor;
    }
}
