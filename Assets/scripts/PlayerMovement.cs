using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameover;
    private Rigidbody2D player;
    private float speed=10f;
    public bool gameOver = false;
    public GameObject startText;
    // Start is called before the first frame update
    void Start()
    {
        startText.SetActive(true);
        gameover.SetActive(false);
        player = GetComponent<Rigidbody2D>();
        player.isKinematic = true;
    }
    void LetsGo()
    {
        if (player.isKinematic == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startText.SetActive(false);
                player.isKinematic = false;
            }
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        ApplyForce();
    }
    private void Update()
    {
        LetsGo();
        DeadState();
    }
    void ApplyForce()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.isKinematic = true;
            player.velocity=Vector2.up * speed;
        }
    }
    void DeadState()
    {
        if (transform.position.y < 5.5)
        {
            gameOver = true;
            gameover.SetActive(true);
            player.bodyType = RigidbodyType2D.Static;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameover.SetActive(true);
            player.bodyType = RigidbodyType2D.Static;
            gameOver = true;
        }
    }
}
