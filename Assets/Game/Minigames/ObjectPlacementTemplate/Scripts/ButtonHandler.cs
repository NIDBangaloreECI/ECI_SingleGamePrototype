using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    // public Transform button;
    public GameObject DragPrefab;
    private int ClickCount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Disable()
    {   if (ClickCount == 0)

        //button.GetComponent<Button>().image.overrideSprite = null;
        {
            Instantiate(DragPrefab, this.transform.position, Quaternion.identity);
            Debug.Log("In the instantiate");
            Debug.Log(ClickCount);
            ClickCount++;
        }
        // OnMouseDrag();



    }
}
