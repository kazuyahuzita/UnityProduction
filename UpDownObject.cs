using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownObject : MonoBehaviour
{
    private bool isPushed = false; // マウスが押されているか押されていないか
    private Vector3 nowMousePos; // 現在のマウスのワールド座標
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
        // マウスが押下されている時、オブジェクトを動かす
        if (isPushed)
        {
            // 現在のマウスのワールド座標を取得
            nowmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 一つ前のマウス座標との差分を計算して変化量を取得
            diffpos = nowmousePos - nowMousePos;
            //　Y成分のみ変化させる
            diffpos.x = 0;
            diffpos.z = 0;
            // 開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
            var pos = transform.position + diffpos;
            pos.y = Mathf.Clamp(pos.y, min, max);
            transform.position = pos;
            
            // 現在のマウスのワールド座標を更新
            nowMousePos = nowmousePos;
        }
    }

    private void OnMouseDown()
    {
        // 押下開始　フラグを立てる
        isPushed = true;
        // マウスのワールド座標を保存
        nowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        // 押下終了　フラグを落とす
        isPushed = false;
        nowMousePos = Vector3.zero;
    }
}