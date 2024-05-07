using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuzzleDragAndDrop : MonoBehaviour
{
    public bool IsCollide;
    public Vector2 CurrentPostion;
    public GameObject Targetobject;
    private void Awake()
    {
            
    }
    private void Start()
    {
       CurrentPostion = transform.position;
    }
    private void OnMouseDown()
    {
        //transform.DOScale(new Vector3(0.5f, 0.5f, 1f), 0.2f);

        
    }
    private void OnMouseDrag()
    {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePostion.x, mousePostion.y, 0);
    }
    private void OnMouseUp()
    {
        if(!IsCollide)
        {
            transform.DOMove(new Vector2(CurrentPostion.x,-4f),0.5f);
            transform.localScale = new Vector3(0.4f,0.5f,0.5f);
        }
        else
        {
            Targetobject.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            Buzzle_GameManager.Instance.OnCompleteSetSprite();
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject==Targetobject)
        {
            IsCollide = true;
        }
        else
        {
            IsCollide = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsCollide = false;
    }
}
