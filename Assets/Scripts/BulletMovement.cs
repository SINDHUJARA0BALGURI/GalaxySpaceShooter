using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D bulletRb;
    AudioSource enemyDestroySound;
    public AudioClip enemyClip;
    ScoreManager scoreManager;
    //public int score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
         scoreManager = FindObjectOfType<ScoreManager>();
        enemyDestroySound = GameObject.Find("SoundManager").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        bulletRb.velocity = new Vector2(0, 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            enemyDestroySound.clip = enemyClip;
            enemyDestroySound.Play();
            scoreManager.IncrementScore();
            
        }
       
    }
}
