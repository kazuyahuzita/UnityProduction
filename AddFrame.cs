using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFrame : MonoBehaviour
{

    [SerializeField] GameObject imgChange; //���F���g�摜

    void OnMouseEnter()
    {
        imgChange.SetActive(true);
        this.GetComponent<SpriteRenderer>().color += new Color(-0.1f, -0.1f, -0.1f, 0);
    }
    void OnMouseExit()
    {
        imgChange.SetActive(false);
        this.GetComponent<SpriteRenderer>().color -= new Color(-0.1f, -0.1f, -0.1f, 0);
    }
}
