using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject car;
    public GameObject tree;
    GameObject distance;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        tree = GameObject.Find("tree");
        distance = GameObject.Find("Distance");    
    }

    // Update is called once per frame
    void Update()
    {
        float length = tree.transform.position.x - car.transform.position.x;
        distance.GetComponent<Text>().text = "목표 지점까지 " + length.ToString("F2") + "m";
    }

    public void GameEndText()
    {
        if (distance != null)
        {
            Text distanceText = distance.GetComponent<Text>();
            if (distanceText != null)
            {
                distanceText.text = "게임 종료";
            }
            else
            {
                Debug.LogError("DistanceText 컴포넌트를 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("Distance 오브젝트를 찾을 수 없습니다!");
        }
        
        // 자동차 조작 정지
        car.GetComponent<CarController>().enabled = false;
        Invoke("GameRestart", 2.0f);
    }

    public void GameRestart()
    {
        if (distance != null)
        {
            Text distanceText = distance.GetComponent<Text>();
            if (distanceText != null)
            {
                distanceText.text = "게임 시작";
            }
            else
            {
                Debug.LogError("DistanceText 컴포넌트를 찾을 수 없습니다!");
            }
        }
        else
        {
            Debug.LogError("Distance 오브젝트를 찾을 수 없습니다!");
        }

        // 자동차 위기 초기화
        car.transform.position = new Vector2(-7f, -3.15f);
        // 자동차 조작 시작
        car.GetComponent<CarController>().enabled = true;
    }
}
