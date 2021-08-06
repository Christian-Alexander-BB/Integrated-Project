using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    float moveZDirection;
    float moveXDirection;

    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        moveZDirection = Input.GetAxis("Vertical");
        moveXDirection = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(moveXDirection, 0, moveZDirection) * Time.deltaTime * moveSpeed);
    }
}
