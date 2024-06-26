using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < -8) {}
            else
            {
                transform.Translate(-0.05f, 0, 0);
            }
        }   

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > 8) {}
            else
            {
                transform.Translate(0.05f, 0, 0);
            }
        }
    }
}
