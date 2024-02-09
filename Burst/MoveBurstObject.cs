using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBurstObject : MonoBehaviour
{

    public BaseMiniGame game;
    public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;

    [SerializeField] float MoveSpeed = 4.0f;
    [SerializeField] int direction =1;

    //�T�C�Y�ύX�p�̕ϐ�
    [SerializeField] float SizeX =1;
    [SerializeField] float SizeY =1;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject EffectImage;
    //�ړ������n�_��Transform
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    // public�Ő錾���Ainspector�Őݒ�\�ɂ���
    //dart:����
    public Sprite DartSprite;
    public Sprite BurstSprite;
    public Sprite BigBurstSprite;
    public Sprite NoneSprite;
    //���e�𗎂Ƃ����߂Ƀ��W�b�h�{�f�B��G�����������ǉ�
    Rigidbody2D rdbody2D;
    //CenterPosition�ɂ���GameObject�Ɣ�r���ă|�C���g�𔻒肳����
    [SerializeField] GameObject CenterPosition;
    [SerializeField] bool isBurst;
    //BaseGame��IsEnd�𑗂邽�߂ɁABurstMiniGame�ɑ���悤
    public bool isOut;

    public AudioSource audio;
    public AudioClip SE_Dart;
    public AudioClip SE_Burst;
    public AudioClip SE_BigBurst;
    bool isAudio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rdbody2D = GetComponent<Rigidbody2D>();
        EffectImage.SetActive(false);
        isBurst = false;
        isAudio = false;
    }

    void OnMouseDown()
    {
        rdbody2D.gravityScale = 5.0f;
        var alpha = Bomb.GetComponent<SpriteRenderer>().color.a;
        alpha -= 0.2f * Time.deltaTime;
        MoveSpeed = 0.0f;
    }


    private void Update()
    {
        var posX = transform.position.x;
        var posY = transform.position.y;
        var centerPosX = CenterPosition.transform.position.x;
        //�������甚�e��ω�������
        if (transform.position.y < -2.8f)
        {

            //�l�ɂ��
            if (Mathf.Abs(posX - centerPosX) > 0.0f && Mathf.Abs(posX - centerPosX) <= 2.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BigBurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_BigBurst);
                    isAudio = true;
                }

                game.GameScore = score2;
                isOut = true;

            }
            else if (Mathf.Abs(posX - centerPosX) > 2.0f && Mathf.Abs(posX - centerPosX) <= 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = BurstSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Burst);
                    isAudio = true;
                }

                game.GameScore = score1;
                isOut = true;
            }
            else if (Mathf.Abs(posX - centerPosX) > 4.0f)
            {
                EffectImage.SetActive(true);

                EffectImage.GetComponent<SpriteRenderer>().sprite = DartSprite;
                if (!isAudio)
                {
                    audio.PlayOneShot(SE_Dart);
                    isAudio = true;
                }

                game.GameScore = score;
                isOut = true;

            }
        }

    }
    private void FixedUpdate()
    {
        var PosY = transform.position.y;

        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime * direction, PosY, 0);

        var bombScale = Bomb.transform.localScale;
        SizeX = Mathf.Sin(SizeX);
        SizeY =Mathf.Sin(SizeY);
        bombScale = new Vector3(SizeX, SizeY, 1f);

    }
}
