using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject scoreUI;
    [SerializeField]
    GameObject noticeUI; 
    [SerializeField]
    GameObject snowGenerator;
    bool gameState = false;
    int score;
    
    void Start()
    {
        noticeUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (scoreUI.activeSelf)
                {
                    scoreUI.SetActive(false);
                }
                noticeUI.SetActive(false);
                score = 0;
                gameState = true;
                snowGenerator.SetActive(true);
                StartGame();
            }
        }

    }
    public void StartGame()
    {
        scoreUI.SetActive(true);
        UpdateUI();
    }

    public void getScore(int plus)
    {
        score += plus;
        UpdateUI();
    }

    public void EndGame()
    {
        snowGenerator.SetActive(false);
        noticeUI.SetActive(true);
        noticeUI.GetComponent<Text>().text = $"게임 종료";
        Invoke("RestartGame", 2.0f);
    }

    public void RestartGame()
    {
        noticeUI.GetComponent<Text>().text = $"게임 시작\n(마우스 클릭)";
        gameState = false;
    }

    public void UpdateUI()
    {
        scoreUI.GetComponent<Text>().text = $"점수: {score}";
    }
}
