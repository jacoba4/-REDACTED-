using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public Text pressEText;
    public Image detectionImage;
    public Sprite firstDocument;
    public Image documentImageSpace;

    public Sprite detectedEye;
    public Sprite transparentPhoto;

    public int docCount;
    public List<string> collectedDocuments;
    public bool detected = false;
    public bool lookingAtDocuments = false;

    public PlayerCam inUseCamera;
    public PlayerMove playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        pressEText = GameObject.FindWithTag("Press E").GetComponent<Text>() as Text;
        detectionImage = GameObject.FindWithTag("detectionImage").GetComponent<Image>() as Image;
        docCount = 0;
        documentImageSpace = GameObject.FindWithTag("document space").GetComponent<Image>() as Image;
        documentImageSpace.sprite = transparentPhoto;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && lookingAtDocuments == false)
        {
            SeeDocuments();
            lookingAtDocuments = true;
        }
        if (lookingAtDocuments == true && Input.GetKey(KeyCode.Q))
        {
            lookingAtDocuments = false;
        }
        if (detected == true)
        {
            detectionImage.sprite = detectedEye;
        }
        if (detected == false)
        {
            detectionImage.sprite = transparentPhoto;
        }
    }
    public void PressE()
    {
        pressEText.text = "Press E to Interact";
    }
    public void ClearText()
    {
        pressEText.text = "";
    }
    void SeeDocuments()
    {
        inUseCamera.allowPlayerControl = false;
        playerMovement.allowPlayerMovement = false;
        documentImageSpace.sprite = firstDocument;
    }
}
