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

    //サイズ変更用の変数
    [SerializeField] float SizeX =1;
    [SerializeField] float SizeY =1;

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject EffectImage;
    //移動する二地点のTransform
    [SerializeField] private Transform _LeftEdge;
    [SerializeField] private Transform _RightEdge;
    // publicで宣言し、inspectorで設定可能にする
    //dart:砂煙
    public Sprite DartSprite;
    public Sprite BurstSprite;
    public Sprite BigBurstSprite;
    public Sprite NoneSprite;
    //爆弾を落とすためにリジッドボディを触った時だけ追加
    Rigidbody2D rdbody2D;
    //CenterPositionにあるGameObjectと比較してポイントを判定させる
    [SerializeField] GameObject CenterPosition;
    [SerializeField] bool isBurst;
    //BaseGameにIsEndを送るために、BurstMiniGameに送るよう
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
        //落ちたら爆弾を変化させる
        if (transform.position.y < -2.8f)
        {

            //値による
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
