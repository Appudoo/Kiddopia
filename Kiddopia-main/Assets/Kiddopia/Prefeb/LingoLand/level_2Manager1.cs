
using DG.Tweening;

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;



public class level_2Manager1:MonoBehaviour
{
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        //randomPos();
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0));
    }

    private void OnMouseDown()
    {
        if (lingo.instance.iswin)
            return;

        string s = this.transform.GetComponent<SpriteRenderer>().sprite.name;
        string[] c = s.Split('@');
        Debug.Log(c[0]);
        if (c[0] == lingo.instance.c)
        {
            Debug.Log("win");
            this.transform.GetChild(0).gameObject.SetActive(true);
            lingo.instance.particleobj.SetActive(true);
            lingo.instance.iswin = true;
            if (lingo.instance.balls.Count < lingo.instance.countrightanswer)
            {
               
                DOTween.Sequence().AppendInterval(2f).OnComplete(() =>
                {
                    
                    lingo.instance.Winpanel.SetActive(true);
                });

                print("gameclose");
            }
            else
            {
                for (int i = 0; i < lingo.instance.btns.Length; i++)
                {
                    lingo.instance.btns[i].transform.DOScale(Vector3.zero, 0.5f);
                }
                DOTween.Sequence().AppendInterval(0.5f).OnComplete(() =>
                {
                    lingo.instance.changetitletext();
                    transform.GetChild(0).gameObject.SetActive(false);
                });
            }
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.5f).OnComplete(() =>
            {
                transform.GetChild(1).gameObject.SetActive(false);
                transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
            });
        }
    }

    // Update is called once per frame

}
