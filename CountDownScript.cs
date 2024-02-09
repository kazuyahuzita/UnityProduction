using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    //�@�J�E���g�_�E��������\������e�L�X�g
    private Image countDownImage;
    [SerializeField] float timer;
    public bool isCountDown;
    void Start()
    {
        countDownImage = GameObject.Find("CountDownImage").GetComponent<Image>();
        StartCoroutine(CountDown());
    }

    //�@�J�E���g�_�E���\��
    IEnumerator CountDown()
    {
        //���I�u�W�F�N�g���~�߂�
        isCountDown = true;
        countDownImage.enabled = true;
        //�摜��\������
        //�R�b�҂�
        yield return new WaitForSeconds(timer);  //1�b�҂�
        

        //�������\���ɂ���
        countDownImage.enabled = false;
        //���I�u�W�F�N�g�𓮂�����悤�ɂ���
        isCountDown = false;
    }
}
