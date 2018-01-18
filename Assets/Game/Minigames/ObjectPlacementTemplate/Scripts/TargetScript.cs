using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 TargetPos;
    private Vector3 OriginPos;
    int flag;

    public GameObject TarPrefab;
    public string TarName;

    private void Start()
    {
        flag = 0;
        OriginPos = this.transform.position;
       
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag==TarName)
        {
            flag = 1;
            TargetPos = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
           {
                Debug.Log("IN END PHASE");
                if (flag == 1)
                {
                    this.transform.position = TargetPos;

                }
                else
                {
                    this.transform.position = OriginPos;
                }

            }
            if (flag == 1 && transform.position != TargetPos)
            {
                Instantiate(TarPrefab, TargetPos, Quaternion.identity);
                flag = 0;
            }
    }
}
