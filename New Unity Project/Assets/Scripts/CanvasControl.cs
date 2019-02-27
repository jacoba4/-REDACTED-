using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public Text pressEText;
    public Image detectionImage;
    public Sprite firstDocument;
    public Sprite secondDocument;
    public Sprite thirdDocument;
    public Image documentImageSpace;

    public Sprite detectedEye;
    public Sprite transparentPhoto;

    public int docCount;
    public List<string> collectedDocuments;
    public bool detected = false;
    public bool lookingAtDocuments = false;

    public PlayerCam inUseCamera;
    public PlayerMove playerMovement;

    public int docNum;

    // Start is called before the first frame update
    void Start()
    {
        pressEText = GameObject.FindWithTag("Press E").GetComponent<Text>() as Text;
        detectionImage = GameObject.FindWithTag("Detection image").GetComponent<Image>() as Image;
        docCount = 0;
        documentImageSpace = GameObject.FindWithTag("Document space").GetComponent<Image>() as Image;
        documentImageSpace.sprite = transparentPhoto;

        docNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Check();
        }

        if (lookingAtDocuments == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (docNum != 0)
                {
                    docNum -= 1;
                    PageTurn();
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (docNum != 2)
                {
                    docNum += 1;
                    PageTurn();
                }
            }
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
    void Check()
    {
        if (lookingAtDocuments == false)
        {
            SeeDocuments();
            lookingAtDocuments = true;
        }
        else if (lookingAtDocuments == true)
        {
            lookingAtDocuments = false;
            ClearDocs();
        }
    }
    void SeeDocuments()
    {
        inUseCamera.allowPlayerControl = false;
        playerMovement.allowPlayerMovement = false;
        documentImageSpace.sprite = firstDocument;
    }
    void ClearDocs()
    {
        documentImageSpace.sprite = transparentPhoto;
        inUseCamera.allowPlayerControl = true;
        playerMovement.allowPlayerMovement = true;
        docNum = 0;
    }
    void PageTurn()
    {
        if (docNum == 0)
        {
            documentImageSpace.sprite = firstDocument;
        }
        if (docNum == 1)
        {
            documentImageSpace.sprite = secondDocument;
        }
        if (docNum == 2)
        {
            documentImageSpace.sprite = thirdDocument;
        }
    }
}
