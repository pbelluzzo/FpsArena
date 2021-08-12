using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputController : MonoBehaviour
{
    [Header("Key Definitions")]
    [SerializeField] KeyCode runKey;
    [SerializeField] KeyCode jumpKey;
    [Space(15)]
    [SerializeField] TwoAxisEvent mouseAxisEvent;
    [SerializeField] TwoAxisEvent HorizontalAxisEvent;
    [SerializeField] BoolEvent runInputEvent;
    [SerializeField] UnityEvent jumpInputEvent; 

    void FixedUpdate()
    {
        CheckHorizontalInput();
        CheckRunInput();
        CheckMouseAxisInput();
        CheckJumpInput();
    }

    private void CheckMouseAxisInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseAxisEvent.Invoke(mouseX,mouseY);
    }

    private void CheckHorizontalInput()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        HorizontalAxisEvent.Invoke(xMovement, zMovement);
    }

    private void CheckRunInput()
    {

        if (Input.GetKey(runKey))
        {
            runInputEvent.Invoke(true);
            return;
        }
        runInputEvent.Invoke(false);
    }

    private void CheckJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
            jumpInputEvent.Invoke();
    }
}
