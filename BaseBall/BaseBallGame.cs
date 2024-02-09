using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBallGame : BaseMiniGame
{
    [SerializeField] GameObject MainSpriteRenderer;
    [SerializeField] GameObject MainSpriteRenderer1;
    [SerializeField] GameObject MainSpriteRenderer2;
    // public�Ő錾���Ainspector�Őݒ�\�ɂ���
    public Sprite HitSprite;
    public Sprite MoveSprite;
    public Sprite AttackSprite;
    //
    //�}�E�X�J�[�\������̃��C�L���X�g�F�������邽�߂�
    private BoxCollider2D mainCollider0;
    private BoxCollider2D mainCollider1;
    private BoxCollider2D mainCollider2;
    private Sprite mainSprite0;
    private Sprite mainSprite1;
    private Sprite mainSprite2;


    [SerializeField] AudioClip SE_Click; //�J�n�T�E���h
    AudioSource myAudio; //���g�̉���

    public bool isBallMove;
    int idx; //�Y�����p�̕ϐ�
    public CountDownScript count;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>(); //���g�̉������擾

        mainCollider0 = MainSpriteRenderer.GetComponent<BoxCollider2D>();
        mainCollider1 = MainSpriteRenderer1.GetComponent<BoxCollider2D>();
        mainCollider2 = MainSpriteRenderer2.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd || count.isCountDown)
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
                myAudio.PlayOneShot(SE_Click);
                Vector2 Pos = hitInfo.transform.position; //���݈ʒu��ޔ�����B
                                                          //���O�̖����P�����𐮐��ɕϊ����A���F�g�̔z��imgChange��[�Y����]�ɗp����B
                idx = int.Parse(hitInfo.collider.gameObject.name.Substring(8, 1));

                
                if (hitInfo.collider == mainCollider0)
                {
                    // SpriteRender��sprite��ݒ�ς݂̑���sprite�ɕύX
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = HitSprite;
                    isBallMove = true;
                    isEnd = true;                   //�~�j�Q�[���̏I��
                }
                else if (hitInfo.collider == mainCollider1)
                {
                    // SpriteRender��sprite��ݒ�ς݂̑���sprite�ɕύX
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = MoveSprite;
                    isEnd = true;                   //�~�j�Q�[���̏I��

                }
                else if (hitInfo.collider == mainCollider2)
                {
                    // SpriteRender��sprite��ݒ�ς݂̑���sprite�ɕύX
                    MainSpriteRenderer1.GetComponent<SpriteRenderer>().sprite = AttackSprite;
                    isEnd = true;                   //�~�j�Q�[���̏I��

                }



            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
    public void SetScore(MiniGameScore score)
    {
        this.GameScore = score;
    }

}