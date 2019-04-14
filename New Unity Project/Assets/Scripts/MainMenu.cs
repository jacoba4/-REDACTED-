using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image controlImage;
    public Sprite controlScreen;

    public Image titleScreenSpace;
    public Sprite titleScreen;

    public Sprite transparent;
    // Start is called before the first frame update
    void Start()
    {
        titleScreenSpace.sprite = titleScreen;
        controlImage.sprite = transparent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            controlImage.sprite = transparent;
        }
    }
    void ChangeScene ()
    {
        SceneManager.LoadScene("Alpha", LoadSceneMode.Single);
    }
    void ShowControls()
    {
        controlImage.sprite = controlScreen;
    }
}
