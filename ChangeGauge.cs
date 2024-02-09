using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGauge : MonoBehaviour
{
    [SerializeField] GameObject imageBack; //”wŒi‰æ‘œ
    [SerializeField] Sprite[] BackImage = new Sprite[2]; //”wŒi‰æ‘œ‚Ì”z—ñ


    [SerializeField] Image GaugeImage;
    public float DecreaseSpeed;
    [Range(1,10)] public float TimeCount;
    float Elapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        GaugeImage.fillAmount = (TimeCount- Elapsed) / 10;

        if (GaugeImage.fillAmount <= 0.2f)
        {
            GaugeImage.color = Color.red;
        }
        else if (GaugeImage.fillAmount <= 0.5f)
        {
            GaugeImage.color = Color.yellow;
        }
        else
        {
            GaugeImage.color = Color.green;
        }

        if(Elapsed > TimeCount)
            imageBack.GetComponent<SpriteRenderer>().sprite = BackImage[1];

    }
    private void FixedUpdate()
    {
        Elapsed += DecreaseSpeed * Time.deltaTime;
    }
}
