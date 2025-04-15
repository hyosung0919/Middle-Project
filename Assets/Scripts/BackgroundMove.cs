using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput < 0)
            transform.localScale = new Vector3(-0.3122735f, 0.2517831f, 0.3178861f);

        if (moveInput > 0)
            transform.localScale = new Vector3(0.3122735f, 0.2517831f, 0.3178861f);
    }
}
