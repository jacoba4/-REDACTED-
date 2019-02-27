using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalStayLit : MonoBehaviour
{
    Material mat;
    Renderer render;



    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        mat = render.material;

        mat.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
