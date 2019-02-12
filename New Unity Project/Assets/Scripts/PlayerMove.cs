using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charControl;

    private void Awake()
    {
        charControl = GetComponent<CharacterController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horiInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMove = transform.forward * vertInput;
        Vector3 rightMove = transform.right * horiInput;

        charControl.SimpleMove(forwardMove + rightMove);
    }
}
