using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningGame : BaseMiniGame
{
    [SerializeField] GameObject[] imgChange = new GameObject[5]; //����摜

    [SerializeField] AudioClip SE_Click; //�J�n�T�E���h
    AudioSource myAudio; //���g�̉���

    int idx; //�Y�����p�̕ϐ�
    public CountDownScript count;

    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgChange.Length; idx++)
        {
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



    }
}
