using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUI : MonoBehaviour
{
    public CountDownScript count;   //�J�E���g�_�E���N���X�̒ǉ�

    [SerializeField] GameObject imgChange; //���F���g�摜
    [SerializeField] bool isOut;
    private void Start()
    {
        imgChange.SetActive(false);
        isOut = false;
    }

    private void Update()
    {
        if (isOut || count.isCountDown) return;
    }

    void OnMouseEnter()
    {
        imgChange.SetActive(true);
        this.GetComponent<SpriteRenderer>().color += new Color(-0.1f, -0.1f, -0.1f, 0);
        isOut = true;
    }
    void OnMouseExit()
    {
        imgChange.SetActive(false);
        this.GetComponent<SpriteRenderer>().color -= new Color(-0.1f, -0.1f, -0.1f, 0);
        isOut = true;
    }
}
