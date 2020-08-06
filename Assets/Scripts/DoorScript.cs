using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ChestSound;
    public static DoorScript Instance;
    public int Levelload = 1;
    public GameControl gc; 
    public Text txtScore;
    private int Score = 0;
    private Animator anim;
    private BoxCollider2D box;
    [HideInInspector]
    public int CollectablesCount;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }
    IEnumerator DoorOpen()
    {
        anim.Play("DoorOpen");
        yield return new WaitForSeconds(2f);
        box.isTrigger = true;
    }
    public void DeCreamentCollectables()
    {
        CollectablesCount--;
        Score++;
        txtScore.text = "" + Score;
        if (CollectablesCount == 0)
            StartCoroutine(DoorOpen());
        audioSource.PlayOneShot(ChestSound);
    }
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            savescore();
            gc.Inputtext.text = ("Press E");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                savescore();
                SceneManager.LoadScene(Levelload);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gc.Inputtext.text = ("");
        }
    }
    void savescore()
    {
        PlayerPrefs.SetInt("points", gc.points);
    }
}
