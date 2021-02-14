using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public string playerInput;

    void FixedUpdate()
    {
        float input = Input.GetAxisRaw(playerInput);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, input) * speed;
    }
}
