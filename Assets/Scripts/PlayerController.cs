using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpforce;
   
    public delegate void PlayersAction();
    public static event PlayersAction OnObstacleOvioded;
    public static event PlayersAction Ondeath;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0);
            rb.AddForce(Vector3.up * jumpforce);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x < 0.3)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if(collision.collider.CompareTag("obstacle"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(Ondeath!= null)
            {
                Ondeath();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("point"))
        {
            if(OnObstacleOvioded!= null)
            {
                OnObstacleOvioded();
            }
         
        }
        if (collision.CompareTag("Finish"))
        {
            if (OnObstacleOvioded != null)
            {
                OnObstacleOvioded();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
