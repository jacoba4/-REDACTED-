using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charControl;

    public bool allowPlayerMovement;

    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
        allowPlayerMovement = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (allowPlayerMovement == true)
        {
            Move();
        }
    }
    void Move()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horiInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMove = transform.forward * vertInput;
        Vector3 rightMove = transform.right * horiInput;

        charControl.SimpleMove(forwardMove + rightMove);
    }

    void OnTriggerEnter(Collider col)
    {
        print("detected");
        if(col.gameObject.transform.tag == "CameraBox")
        {
            print("detected");
            SceneManager.LoadScene("PlayState", LoadSceneMode.Single);
        }
    }

    
}
