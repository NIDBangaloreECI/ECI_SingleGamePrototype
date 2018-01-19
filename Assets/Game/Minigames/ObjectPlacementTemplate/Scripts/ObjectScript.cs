using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {


	private Vector3 TargetPos;
	private Vector3 OriginPos;
	int flag;

	public GameObject TarPrefab;
	public GameObject gameManager;
	public string TarName;

	private void Start()
	{
		flag = 0;
		OriginPos = this.transform.position;
        gameManager = GameObject.FindGameObjectWithTag("GameController");

	}
	void OnMouseDown()
	{
		
		gameManager.GetComponent<GameController> ().SetTagArray (0, this.gameObject.tag);
		gameManager.GetComponent<GameController> ().SetObjArray (0, this.gameObject);

	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag==TarName)
		{
			flag = 1;
			TargetPos = collision.gameObject.transform.position;
			//Destroy(collision.gameObject);
		}
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == TarName)
        {
            flag = 0;
           // TargetPos = collision.gameObject.transform.position;
            //Destroy(collision.gameObject);
        }
    }

    private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Debug.Log("IN END PHASE");
			if (flag == 1)
			{
                Instantiate(TarPrefab, TargetPos, Quaternion.identity);
                //TarPrefab.GetComponent<DragScript>().enabled = false;
                Destroy(this.gameObject);
                

            }
			else
			{
				this.transform.position = OriginPos;
			}

		}
//		if (flag == 1 && transform.position != TargetPos)
//		{
//			Instantiate(TarPrefab, TargetPos, Quaternion.identity);
//			flag = 0;
//			Destroy (this.gameObject);
//		}
	}
}
