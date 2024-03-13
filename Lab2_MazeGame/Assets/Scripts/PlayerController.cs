using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    private CharacterController controller;

    private int count;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        moveDirection.y -= 9.81f * Time.deltaTime;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }

        if (count >= 13)
        {
            if (other.gameObject.CompareTag("FinishCube"))
            {
                other.gameObject.SetActive(false);

                winTextObject.SetActive(true);
            }
        }
        

    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();

    }
}
