using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchEffect : MonoBehaviour
{

    [SerializeField] GameObject[] imgChange = new GameObject[5]; //���F���g�摜
    [SerializeField] GameObject[] imgCard = new GameObject[5]; //�J�[�h�摜

    [SerializeField] AudioClip SE_Click; //�J�n�T�E���h
    AudioSource myAudio; //���g�̉���

    int idx; //�Y�����p�̕ϐ�
    [SerializeField] bool[] isClick =new bool[5];
    // Start is called before the first frame update
    void Start()
    {
        for (idx = 0; idx < imgCard.Length; idx++)
        {
            imgChange[idx].SetActive(false); //�ύX���g�̔�\��
            imgCard[idx].SetActive(true); //�J�[�h�̔�\��
            isClick[idx] = false;
        }

        myAudio = GetComponent<AudioSource>(); //���g�̉������擾
    }

    // Update is called once per frame
    void Update()
    {

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
                myAudio.PlayOneShot(SE_Click);
                Vector2 Pos = hitInfo.transform.position; //���݈ʒu��ޔ�����B
                 //���O�̖����P�����𐮐��ɕϊ����A���F�g�̔z��imgChange��[�Y����]�ɗp����B
                idx = int.Parse(hitInfo.collider.gameObject.name.Substring(8, 1));

                if (!isClick[idx])
                {
                    hitInfo.transform.position = new Vector2(Pos.x, Pos.y + 0.2f); //��Ɉړ�
                    imgChange[idx].SetActive(true); //���F�g��\��
                    isClick[idx] = true;
                }
                else
                {
                    hitInfo.transform.position = new Vector2(Pos.x, Pos.y - 0.2f); //���Ɉړ�
                    imgChange[idx].SetActive(false); //���F�g���\��
                    isClick[idx] = false;
                }
            }
        }
    }
}
