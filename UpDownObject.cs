using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObject : MonoBehaviour
{
    private bool isPushed = false; // �}�E�X��������Ă��邩������Ă��Ȃ���
    private Vector3 nowMousePos; // ���݂̃}�E�X�̃��[���h���W
    [SerializeField] Vector3 nowmousePos;
    [SerializeField] Vector3 diffpos;

    [SerializeField] float min;
    [SerializeField] float max;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // �}�E�X����������Ă��鎞�A�I�u�W�F�N�g�𓮂���
        if (isPushed)
        {
            // ���݂̃}�E�X�̃��[���h���W���擾
            nowmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // ��O�̃}�E�X���W�Ƃ̍������v�Z���ĕω��ʂ��擾
            diffpos = nowmousePos - nowMousePos;
            //�@Y�����̂ݕω�������
            diffpos.x = 0;
            diffpos.z = 0;
            // �J�n���̃I�u�W�F�N�g�̍��W�Ƀ}�E�X�̕ω��ʂ𑫂��ĐV�������W��ݒ�
            var pos = transform.position + diffpos;
            pos.y = Mathf.Clamp(pos.y, min, max);
            transform.position = pos;
            
            // ���݂̃}�E�X�̃��[���h���W���X�V
            nowMousePos = nowmousePos;
        }
    }

    private void OnMouseDown()
    {
        // �����J�n�@�t���O�𗧂Ă�
        isPushed = true;
        // �}�E�X�̃��[���h���W��ۑ�
        nowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        // �����I���@�t���O�𗎂Ƃ�
        isPushed = false;
        nowMousePos = Vector3.zero;
    }
}