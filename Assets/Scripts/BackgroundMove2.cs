using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove2 : MonoBehaviour
{
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput < 0)
            transform.localScale = new Vector3(-0.31417f, 0.30289f, 0.31789f);

        if (moveInput > 0)
            transform.localScale = new Vector3(0.31417f, 0.30289f, 0.31789f);
    }
}