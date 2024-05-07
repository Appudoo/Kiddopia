using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragHandler : MonoBehaviour
{
    public Vector3 pos;
    public bool iscurrentTrun;
    public bool Target;
    public LineRenderer lineRenderer;
    public bool collied;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (iscurrentTrun)
        {
            lineRenderer.SetPosition(0, pos);
        }
    }
    private void OnMouseDrag()
    {
        if (iscurrentTrun && !collied)
        {
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseUp()
    {
        if(iscurrentTrun)
        {
            transform.position = pos;
            lineRenderer.SetPosition(1, pos);
        }
       
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        //lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<dragHandler>().Target)
    //    {
    //        this.GetComponent<SpriteRenderer>().enabled = false;
    //        collied = true;
    //    }

    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "last" && collision.gameObject.GetComponent<dragHandler>().Target)
        {

            pointjointmanager.instance.win();
            return;

        }
        if (collision.gameObject.GetComponent<dragHandler>().Target)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            collied = true;
            pointjointmanager.instance.pointCount++;
            //if (pointjointmanager.instance.pointCount == pointjointmanager.instance.PointList.Count)
            //{
            //    pointjointmanager.instance.win();
            //    return;
            //}
            pointjointmanager.instance.ChangeTarget();
        }
       

    }



}
