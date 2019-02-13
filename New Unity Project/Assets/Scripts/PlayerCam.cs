using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Some of movement and camera adapted from https://www.youtube.com/watch?v=n-KX8AeGK7E&t=913s
public class PlayerCam : MonoBehaviour
{
    private bool seenItem = false;
    public CanvasControl canControl;

    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    public bool allowPlayerControl;

    public GameObject PuzzleCam;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        allowPlayerControl = true;
        mouseXInputName = "Mouse X";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Canvas mainCanvas = GameObject.FindObjectOfType<Canvas>();
        if (allowPlayerControl == true)
        {
            CameraRotation();
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f) && hit.transform.tag == "test")
            {
                if (seenItem == false)
                {
                    mainCanvas.SendMessage("PressE");
                    seenItem = true;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.transform.tag == "document")
                    {
                        canControl.docCount += 1;
                        canControl.collectedDocuments.Add(hit.transform.gameObject.name);
                        Destroy(hit.transform.gameObject);
                    }

                    if (hit.transform.GetComponent<Camera>() != null)
                    {
                        print("yep");
                        allowPlayerControl = false;
                        GetComponent<Camera>().enabled = false;
                        PuzzleCam.GetComponent<Camera>().enabled = true;
                    }
                }
            }
            else if (seenItem == true && !Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
            {
                mainCanvas.SendMessage("ClearText");
                seenItem = false;
            }
        }
    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRot(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRot(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRot(float val)
    {
        Vector3 eulerRot = transform.eulerAngles;
        eulerRot.x = val;
        transform.eulerAngles = eulerRot;
    }

    public void Solved()
    {
        allowPlayerControl = true;
        GetComponent<Camera>().enabled = true;
        PuzzleCam.GetComponent<Camera>().enabled = false;
    }

    
}
