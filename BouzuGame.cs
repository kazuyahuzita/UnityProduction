using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouzuGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //カード画像
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //枠画像

    AudioSource myAudio; //自身の音源

    int idx; //添え字用の変数
    [SerializeField] bool[] isClick = new bool[5];
    public CountDownScript count;

    public AudioSource audio;

    public AudioClip SE_Mokugyo;
    public AudioClip SE_Butudan;
    public AudioClip SE_Bouzu;

    public bool isAudio;
    public bool isAudio1;
    public bool isAudio2;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true); //カードの非表示
            imgChange[idx].SetActive(false); //変更枠の非表示
            isClick[idx] = false;
        }

        myAudio = GetComponent<AudioSource>(); //自身の音源を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd|| count.isCountDown)
        {
            return;
        }

        //クリックしたらの判定の部分
        if (Input.GetMouseButtonDown(0))
        {
            //クリック座標をUnityのワールド座標系に変換
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //クリック位置から光を飛ばし、接触物体をhitInfoとして取得する。
            RaycastHit2D hitInfo = Physics2D.Raycast(clickPos, -Vector2.up);
            //hitInfoがコライダー形状を持つトランプか？
            if (hitInfo.collider)
            {
                Vector2 Pos = hitInfo.transform.position; //現在位置を退避する。
                                                          //名前の末尾１文字を整数に変換し、黄色枠の配列imgChangeの[添え字]に用いる。
                idx = int.Parse(hitInfo.collider.gameObject.name.Substring(8, 1));

                if (imgCard[idx] == imgCard[0])
                {
                    if (!isAudio)
                    {
                        audio.PlayOneShot(SE_Butudan);
                        isAudio = true;
                    }
                    imgChange[0].SetActive(true); //枠を表示
                    isClick[0] = true;
                    isEnd = true;
                    return;
                }

                if (imgCard[idx] == imgCard[1])
                {
                    if (!isAudio1)
                    {
                        audio.PlayOneShot(SE_Mokugyo);
                        isAudio1 = true;
                    }

                    imgChange[1].SetActive(true); //枠を表示
                    isClick[1] = true;
                    isEnd = true;
                    return;

                }

                if (imgCard[idx] == imgCard[2])
                {
                    if (!isAudio2)
                    {
                        audio.PlayOneShot(SE_Bouzu);
                        isAudio2 = true;
                    }

                    imgChange[2].SetActive(true); //枠を表示
                    isClick[2] = true;
                    isEnd = true;
                    return;

                }


            }
        }


    }
    public void SetScore(MiniGameScore score)
    {
        this.GameScore = score;
    }

}
