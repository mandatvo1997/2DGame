using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip JumpSound;
    public AudioClip HurtSound;
    public AudioClip BananaSound;
    public AudioClip HeartSound;
    public AudioClip ShoesSound;
    public float speed = 50f, maxspeed = 3,maxjump =5, jumpPow = 220f;
    public bool grounded = true, faceright = true, doublejump = false;
    public int ourHealth;
    public int maxhealth = 5;
    public Rigidbody2D r2;
    public Animator anim;
    public GameControl gc;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gc = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
        ourHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
                audioSource.PlayOneShot(JumpSound);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow *1f);
                    audioSource.PlayOneShot(JumpSound);
                }
            }
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        // giới hạn tốc độ
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
        if (r2.velocity.y > maxjump)
            r2.velocity = new Vector2(r2.velocity.x,maxjump);
        if (r2.velocity.y < -maxjump)
            r2.velocity = new Vector2(r2.velocity.x,-maxjump);
        if (h > 0 && !faceright)
        {
            Flip();
        }
        if (h < 0 && faceright)
        {
            Flip();
        }
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f,r2.velocity.y);
        }
        if(ourHealth<=0)
        {
            Death();
        }
    }
    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < gc.points)
            PlayerPrefs.SetInt("highscore", gc.points);
    }
    // Chạm Spike mất máu và đẩy lùi
    public void Damage(int damage)
    {
        ourHealth -= damage;
        gameObject.GetComponent<Animation>().Play("Player_Hurt");
        audioSource.PlayOneShot(HurtSound);
    }
    public void KnockBack(float Knowpow, Vector2 Knockdirec)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Knockdirec.x * -100f, Knockdirec.y * Knowpow));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("banana"))
        {
            Destroy(collision.gameObject);
            gc.points += 1;
            audioSource.PlayOneShot(BananaSound);
        }
        if (collision.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            ourHealth = 5;
            audioSource.PlayOneShot(HeartSound);
        }
        if (collision.CompareTag("shoes"))
        {
            Destroy(collision.gameObject);
            maxspeed = 6;
            speed = 100f;
            StartCoroutine(timecount(5));
            audioSource.PlayOneShot(ShoesSound);
        }
    }
    IEnumerator timecount (float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 3f;
        speed = 50f;
        yield return 0;
    }
}
