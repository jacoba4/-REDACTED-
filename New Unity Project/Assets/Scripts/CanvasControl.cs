using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public Text pressEText;
    public Image detectionImage;
    public Sprite controls;
    public Sprite firstDocument;
    public Sprite secondDocument;
    public Sprite thirdDocument;
    public Sprite fourthDocument;
    public Sprite fifthDocument;
    public Sprite sixthDocument;
    public Sprite placeholder;
    public Image documentImageSpace;

    public Sprite detectedEye;
    public Sprite transparentPhoto;

    public int docCount;
    /*public List<string> collectedDocuments;
    public bool detected = false;*/
    public bool lookingAtDocuments = false;

    public PlayerCam inUseCamera;
    public PlayerMove playerMovement;

    public int docNum;

    public bool firstFound;
    public bool secondFound;
    public bool thirdFound;
    public bool fourthFound;
    public bool fifthFound;
    public bool sixthFound;

    // Start is called before the first frame update
    void Start()
    {
        pressEText = GameObject.FindWithTag("Press E").GetComponent<Text>() as Text;
        detectionImage = GameObject.FindWithTag("Detection image").GetComponent<Image>() as Image;
        docCount = 0;
        documentImageSpace = GameObject.FindWithTag("Document space").GetComponent<Image>() as Image;
        documentImageSpace.sprite = transparentPhoto;

        docNum = 0;

        lookingAtDocuments = false;

        firstFound = false;
        secondFound = false;
        thirdFound = false;
        fourthFound = false;
        fifthFound = false;
        sixthFound = false;
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
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (docNum != 0)
                {
                    docNum -= 1;
                    PageTurn();
                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (docNum != 6)
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
        pressEText.text = "Click to Interact";
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
            ClearDocs();
            lookingAtDocuments = false;
            
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
            documentImageSpace.sprite = controls;
        }
        if (docNum == 1)
        {
            if (firstFound == true)
            {
                documentImageSpace.sprite = firstDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
        if (docNum == 2)
        {
            if (secondFound = true)
            {
                documentImageSpace.sprite = secondDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
        if (docNum == 3)
        {
            if (thirdFound = true)
            {
                documentImageSpace.sprite = thirdDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
        if (docNum == 4)
        {
            if (fourthFound = true)
            {
                documentImageSpace.sprite = fourthDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
        if (docNum == 5)
        {
            if (fifthFound = true)
            {
                documentImageSpace.sprite = fifthDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
        if (docNum == 6)
        {
            if (sixthFound = true)
            {
                documentImageSpace.sprite = sixthDocument;
            }
            else
            {
                documentImageSpace.sprite = placeholder;
            }
        }
    }
}
