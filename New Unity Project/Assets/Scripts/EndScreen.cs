using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Image endScreenSpace;
    public Sprite endScreen;
    // Start is called before the first frame update
    void Start()
    {
        endScreenSpace.sprite = endScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Exit()
    {
        Application.Quit();
    }
    void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
