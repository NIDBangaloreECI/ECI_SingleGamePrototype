using com.nidb.games.hiddenobjectgame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.nidb.games.hiddenobjectgame
{
    public class InvalidObjectScript : MonoBehaviour
    {

        [SerializeField]
        private GameObject mGameCanvasObject;
        // Use this for initialization
        void Start()
        {
            mGameCanvasObject = GameObject.FindGameObjectWithTag("HoGGameCanvas");
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetMouseButtonDown(0))
            {
                //Get the mouse position on the screen and send a raycast into the game world from that position.
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                //If something was hit, the RaycastHit2D.collider will not be null.
                if (hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("Invalid Click");
                }
                else if(hit.collider.gameObject.tag=="valid")
                    {
                    Debug.Log("Valid Click");
                }*/


        }
        private void OnMouseDown()
        {
            mGameCanvasObject.GetComponent<TimerController>().setWrongClickCount(1);
        }

    }
}

