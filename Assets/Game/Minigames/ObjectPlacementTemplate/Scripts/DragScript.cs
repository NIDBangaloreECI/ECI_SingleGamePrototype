using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;
   // public GameObject TagPrefab;
    //float scaleX;
   // float scaleY;
    private void Start()
    {
         //scaleX = this.transform.localScale.x;
        // scaleY = this.transform.localScale.y;
    }

    void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //	gameManager.GetComponent<GameController> ().SetTagArray (0, this.gameObject.tag);
        //	gameManager.GetComponent<GameController> ().SetObjArray (0, this.gameObject);
       // transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, 0);
    }

	void OnMouseDrag()
	{
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}

	void OnMouseEnter()
	{

        //transform.localScale = new Vector3 (scaleX+ 0.2f,  scaleY + 0.2f, 0);
       GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
       // Instantiate(TagPrefab, this.transform.position, Quaternion.identity);


    }

	void OnMouseExit()
	{

       // transform.localScale = new Vector3 (scaleX, scaleY, 0);
       GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        //Destroy(TagPrefab);
    }

    


}
