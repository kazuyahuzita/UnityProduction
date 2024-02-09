using System.Collections;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    Vector3 screenPoint;
    Vector3 offset;

    public BaseMiniGame game;
    public MiniGameScore score;
    public MiniGameScore score1;
    public MiniGameScore score2;

    [SerializeField] float minY;
    [SerializeField] float maxY;

    [SerializeField] int Count;
    public bool upFlag = false; //上へ上げるフラグ

    [SerializeField] GameObject BalloonSpriteRenderer;

    // publicで宣言し、inspectorで設定可能にする
    //swell:膨らむ
    public Sprite SwellSprite;
    public Sprite BigSwellSprite;
    public Sprite BurstSprite;

    public bool isOut;//ゲームの終了を親に渡す

    //音声用
    public AudioSource audio;
    public AudioClip SE_Down;
    public AudioClip SE_Burst;
    public AudioClip SE_InAir;
    public  bool isAudio;
    public  bool isAudio1;
    public  bool isAudio2;

    //空気用のSE
    float audioTimer;
    public  bool isAirSE;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        audioTimer = 0;
        isAudio = false;
        isAudio1 = false;
        isAudio2 = false;
        isAirSE = true;

        isOut = false;
    }
    // Start is called before the first frame update
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(0, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(0, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

        var pos = transform.position;
        // x軸方向の移動範囲制限
        currentPosition = new Vector3(pos.x, Mathf.Clamp(currentPosition.y, minY, maxY), 0);

        transform.position = currentPosition;
    }
    private void Update()
    {
        if (isOut) return;  //ゲーム終了

        //音声処理で時間の管理を任せている
        if(audioTimer>=0.0f)
        {
            audioTimer -= Time.deltaTime;
            isAirSE = true;
        }

        //条件によってバルーンのサイズが変更
        //if (Count > 800 && Count < 1500)
        //{
        //    BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = SwellSprite;
        //    game.GameScore = score;
        //    if (!isAudio)
        //    {
        //        isAirSE = false;
        //        StartCoroutine(DelayCoroutine());
        //        audio.PlayOneShot(SE_InAir);
        //        isAudio = true;

        //    }

        //}
        //else if (Count >= 1500 && Count < 1800)
        //{
        //    BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BigSwellSprite;
        //    game.GameScore = score1;
        //    if (!isAudio1)
        //    {
        //        isAirSE = false;
        //        StartCoroutine(DelayCoroutine());
        //        audio.PlayOneShot(SE_InAir);
        //        isAudio1 = true;

        //    }

        //}
        //else if (Count >= 1800)
        //{
        //    BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BurstSprite;
        //    game.GameScore = score2;
        //    if (!isAudio2)
        //    {
        //        isAirSE = false;
        //        StartCoroutine(DelayCoroutine());
        //        audio.PlayOneShot(SE_Burst);
        //        isAudio2 = true;
        //        StartCoroutine(LastCoroutine());
        //        isOut = true;
        //    }

        //}

        var prevCount = Count;
        var pos = transform.position;
        if( pos.y >= 0.7f && upFlag )
        {
            Count++;
            upFlag = false;
            if (audioTimer <= 0.0f && isAirSE)
            {
                audio.PlayOneShot(SE_Down);
                audioTimer = 1.0f;
            }
        }
        if ( pos.y <= -1.3f && !upFlag )
        {
            Count++;
            upFlag = true;
            if (audioTimer <= 0.0f && isAirSE)
            {
                audio.PlayOneShot(SE_Down);
                audioTimer = 1.0f;
            }
        }
        if( prevCount != Count )
        {
            if (!isAudio)
            {
                isAirSE = false;
                StartCoroutine(DelayCoroutine());
                audio.PlayOneShot(SE_InAir);
                isAudio = true;
            }


            if ( prevCount == 10 )
            {
                BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = SwellSprite;
                game.GameScore = score;
            }
            else if( prevCount == 20 )
            {
                BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BigSwellSprite;
                game.GameScore = score1;
            }
            else if (prevCount == 30)
            {
                BalloonSpriteRenderer.GetComponent<SpriteRenderer>().sprite = BurstSprite;
                game.GameScore = score2;
            }

        }

        //if (pos.y >= 0.7f)
        //{
        //    Count++;

        //    if (audioTimer <= 0.0f&&isAirSE)
        //    {
        //        audio.PlayOneShot(SE_Down);
        //        audioTimer = 1.0f;
        //    }
        //}
        //else if (pos.y <= -1.3f)
        //{
        //    Count++;
        //    if (audioTimer <= 0.0f && isAirSE)
        //    {
        //        audio.PlayOneShot(SE_Down);
        //        audioTimer = 1.0f;
        //    }

        //}
    }

    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1.0f);

        isAirSE = false;

    }
    private IEnumerator LastCoroutine()
    {
        yield return new WaitForSeconds(2.25f);

        isAirSE = false;
        isAudio = false;
        audio.Stop();

    }
}
