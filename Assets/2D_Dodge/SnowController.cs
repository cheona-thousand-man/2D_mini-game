using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    GameObject gameManager;
    [SerializeField]
    private int voidPoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!!");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);

        if(transform.position.y < -4.5f)
        {
            gameManager.GetComponent<GameManager>().getScore(voidPoint);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("OnTriggerEnter2D");    

        gameManager.GetComponent<GameManager>().EndGame();
    }
}
