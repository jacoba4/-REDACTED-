﻿using System.Collections;
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
    GameObject lastSeen;
    LightUpObject objectShader;

    public GameObject PuzzleCam;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
        //allowPlayerControl = true;
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
        RaycastHit hit;
        if (allowPlayerControl == true)
        {
            CameraRotation();
            Debug.DrawRay(transform.position,transform.forward, Color.green,.01f);
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
            {
                if (seenItem == false && hit.transform.tag != "Untagged")
                {
                    mainCanvas.SendMessage("PressE");
                    seenItem = true;

                    lastSeen = hit.transform.gameObject;
                    objectShader = lastSeen.GetComponent<LightUpObject>();

                    objectShader.isLit = true;
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
                if (seenItem == true)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
                    {
                        Vector3 targetDir = lastSeen.transform.position - transform.position;
                        float angle = Vector3.Angle(targetDir, transform.forward);
                        if (hit.transform.tag == "Untagged" && angle > 15)
                        {
                            mainCanvas.SendMessage("ClearText");
                            seenItem = false;
                            objectShader.isLit = false;
                        }
                    }
                }
            }
            if (!Physics.Raycast(transform.position, transform.forward, out hit, 10.0f))
            {
                Vector3 targetDir = lastSeen.transform.position - transform.position;
                float angle = Vector3.Angle(targetDir, transform.forward);
                if (angle > 15)
                {
                    seenItem = false;
                    mainCanvas.SendMessage("ClearText");
                    objectShader.isLit = false;
                }
                
            }

            if (allowPlayerControl == false)
            {
                Vector3 targetDir = lastSeen.transform.position - transform.position;
                float angle = Vector3.Angle(targetDir, transform.forward);
                if (angle > 15)
                {
                    seenItem = false;
                    mainCanvas.SendMessage("ClearText");
                    objectShader.isLit = false;
                }
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
