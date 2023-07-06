using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed = 9f;
    int angle = 0;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool onGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sr;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;

    [SerializeField]
    private AudioSource swim,hit,point;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.gameOver)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 4f;
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _speed);
            }
        }
    }

    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (_rb.velocity.y < 0)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (onGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
            point.Play();
        }
        else if (collision.CompareTag("Column") && !GameManager.gameOver)
        {
            PlayFishDieEffect();
            gameManager.GameOver();
        }
    }

    void PlayFishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!GameManager.gameOver)
            {
                PlayFishDieEffect();
                gameManager.GameOver();
            }
            GameOver();
        }
    }

    void GameOver()
    {
        onGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sr.sprite = fishDied;
        anim.enabled = false;
    }
}
