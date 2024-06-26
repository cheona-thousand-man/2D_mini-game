using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPosition;
    GameDirector gameDirector; 
    GameObject tree;

    void Start()
    {
        tree = GameObject.Find("tree");
        // GameEndText()가 의존성 있어서, 오브젝트에 삽입된 돌아가는 객체를 가져와야 함
        gameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
        }        
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPosition = Input.mousePosition;
            float swipeLength = endPosition.x - startPosition.x;
            if(swipeLength > 0) // 뒤로 드래그 하면 이동하지 않게
            {
                speed = swipeLength / 1000.0f;
            }
            else
            {
                speed = 0;
            }
        }
        Move();
        CheckCollieTree();
    }

    void Move()
    {
        transform.Translate(speed, 0, 0);
        speed *= 0.98f;
    }

    void CheckCollieTree()
    {
        if ((tree.transform.position.x - transform.position.x) < 1.7f)
        {
            speed = 0;
            gameDirector.GameEndText();
        }
    }
}
 