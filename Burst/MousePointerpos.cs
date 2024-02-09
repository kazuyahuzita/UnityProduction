using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousePointerpos : MonoBehaviour
{
    Vector3 mousePos, pos; //�}�E�X�ƃQ�[���I�u�W�F�N�g�̍��W�f�[�^���i�[

    void Update()
    {
        //�}�E�X�̍��W���擾����
        mousePos = Input.mousePosition;
        //�X�N���[�����W�����[���h���W�ɕϊ�����
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //���[���h���W���Q�[���I�u�W�F�N�g�̍��W�ɐݒ肷��
        transform.position = pos;
    }
}
