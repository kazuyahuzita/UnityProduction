using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public GameObject baby;
    public BaseMiniGame game;

    public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;


    public Sprite babyImage;
    public Sprite fatImage;
    public Sprite NormalImage;
    public Sprite machoImage;

    public AudioSource myAudio; //é©êgÇÃâπåπ
    public AudioClip SE_Muscle;
    public AudioClip SE_Rough;
    public bool isOut;
    public bool isAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //é©êgÇÃâπåπÇéÊìæ

        baby.GetComponent<SpriteRenderer>().sprite = babyImage;
        isOut = false;
        isAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOut) return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Normal")
        {
            baby.GetComponent<SpriteRenderer>().sprite = NormalImage;
            Destroy(collision.gameObject);
            game.GameScore = score;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Rough);
                isAudio = true;
            }

            isOut = true;
        }
        else if(collision.gameObject.tag == "Fat")
        {
            baby.GetComponent<SpriteRenderer>().sprite = fatImage;
            Destroy(collision.gameObject);
            game.GameScore = score1;

            isOut = true;
        }
        else if(collision.gameObject.tag == "macho")
        {
            baby.GetComponent<SpriteRenderer>().sprite = machoImage;
            Destroy(collision.gameObject);
            game.GameScore = score2;
            if (!isAudio)
            {
                myAudio.PlayOneShot(SE_Muscle);
                isAudio = true;
            }

            isOut = true;
        }
    }
}
