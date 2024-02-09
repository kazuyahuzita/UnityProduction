using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouzuGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //�J�[�h�摜
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //�g�摜

    AudioSource myAudio; //���g�̉���

    int idx; //�Y�����p�̕ϐ�
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
            imgCard[idx].SetActive(true); //�J�[�h�̔�\��
            imgChange[idx].SetActive(false); //�ύX�g�̔�\��
            isClick[idx] = false;
        }

        myAudio = GetComponent<AudioSource>(); //���g�̉������擾
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd|| count.isCountDown)
        {
            return;
        }

        //�N���b�N������̔���̕���
        if (Input.GetMouseButtonDown(0))
        {
            //�N���b�N���W��Unity�̃��[���h���W�n�ɕϊ�
            Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�N���b�N�ʒu��������΂��A�ڐG���̂�hitInfo�Ƃ��Ď擾����B
            RaycastHit2D hitInfo = Physics2D.Raycast(clickPos, -Vector2.up);
            //hitInfo���R���C�_�[�`������g�����v���H
            if (hitInfo.collider)
            {
                Vector2 Pos = hitInfo.transform.position; //���݈ʒu��ޔ�����B
                                                          //���O�̖����P�����𐮐��ɕϊ����A���F�g�̔z��imgChange��[�Y����]�ɗp����B
                idx = int.Parse(hitInfo.collider.gameObject.name.Substring(8, 1));

                if (imgCard[idx] == imgCard[0])
                {
                    if (!isAudio)
                    {
                        audio.PlayOneShot(SE_Butudan);
                        isAudio = true;
                    }
                    imgChange[0].SetActive(true); //�g��\��
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

                    imgChange[1].SetActive(true); //�g��\��
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

                    imgChange[2].SetActive(true); //�g��\��
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
