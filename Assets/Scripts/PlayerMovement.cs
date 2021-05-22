 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public player localPlayer;
    AudioSource playerDestroySound;
    public AudioClip playerDestroyClip;
    public GameObject replayButton;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        playerDestroySound = GameObject.Find("SoundManager").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal, vertical) * playerSpeed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, localPlayer.xMin, localPlayer.xMax), Mathf.Clamp(rb.position.y, localPlayer.yMin, localPlayer.yMax));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(gameObject);
            playerDestroySound.clip = playerDestroyClip;
            playerDestroySound.Play();
            
        }
        

    }
    public void GoToNextScene()
    {
        SceneManager.LoadScene(2);
        replayButton.SetActive(true);
        backButton.SetActive(true);
    }
   
            
   
    public void Replaygame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [System.Serializable]
    public class player
    {
        public float xMin, xMax, yMin, yMax;
    }

}


