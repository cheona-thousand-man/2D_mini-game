using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 15.0f;
    float maxWalkSpeed = 2.0f;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
            animator.SetBool("IsJump", true);
            isJumping = true;
            Debug.Log($"Jump started");
        }

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // 스피드 제한하여 이동
        if (speedx < this.maxWalkSpeed)
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        // 움직이는 방향에 따라 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 맞춰 에니메이션 속도 변경
        if (this.rigid2D.velocity.y > 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
            this.animator.speed = 1.0f;

        // 플레이어가 화면 밖으로 나가면 처음부터 다시 시작
        if (transform.position.x < -2.5f || transform.position.x > 2.5f)
        {
            animator.SetBool("IsJump", false);
            isJumping = false;
            Debug.Log("화면을 벗어났습니다.");
            SceneManager.LoadScene("JumpClearScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "flag")
        {
            animator.SetBool("IsJump", false);
            isJumping = false;
            Debug.Log("게임 종료");
            SceneManager.LoadScene("JumpClearScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Collider2D myCollider = GetComponent<CircleCollider2D>();
        if (isJumping && other.gameObject.CompareTag("cloud") && myCollider != null)
        {
            if (this.rigid2D.velocity.y == 0)
            {
                isJumping = false;
                animator.SetBool("IsJump", false);
                Debug.Log($"Jump ended: {isJumping}");
            }
        }
    }
}