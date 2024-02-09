using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //�J�[�h�摜
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //�g�摜

    [SerializeField] AudioClip SE_Click; //�J�n�T�E���h
    AudioSource myAudio; //���g�̉���

    int idx; //�Y�����p�̕ϐ�
    public CountDownScript count;

    public UpDownMove upDownMove;
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgCard[idx].SetActive(true); //�J�[�h�̔�\��
            imgChange[idx].SetActive(false); //�ύX�g�̔�\��
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

        if(upDownMove.isOut)
        {
            isEnd = true;
        }


    }
}
