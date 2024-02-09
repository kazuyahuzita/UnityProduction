using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByTypeObject1 : MonoBehaviour
{
    public BaseBallGame game;
    public MiniGameScore score;
    public CountDownScript count;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        if (game.IsEnd()|| count.isCountDown)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            game.SetScore(score);
        }
    }
}
