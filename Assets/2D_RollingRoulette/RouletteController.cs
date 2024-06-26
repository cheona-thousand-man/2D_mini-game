using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotationSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotationSpeed = 10;
        }        
        transform.Rotate(0, 0, this.rotationSpeed);
        this.rotationSpeed *= Random.Range(97, 100) * 0.01f;
    }
}
