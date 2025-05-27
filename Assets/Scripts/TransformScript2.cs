using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript2 : MonoBehaviour
{
    public ObjectScript2 objectScript2;

    void Update()
    {
        if (objectScript2.lastDragged != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                objectScript2.lastDragged.GetComponent<RectTransform>().
                     transform.Rotate(0, 0, Time.deltaTime * 20f);
            }

            if (Input.GetKey(KeyCode.X))
            {
                objectScript2.lastDragged.GetComponent<RectTransform>().
                     transform.Rotate(0, 0, -Time.deltaTime * 20f);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow Pressed");
                if (objectScript2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objectScript2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x,
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y + 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objectScript2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y > 0.5f)
                {
                    objectScript2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x,
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y - 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objectScript2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x > 0.5f)
                {
                    objectScript2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x - 0.001f,
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objectScript2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objectScript2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x + 0.001f,
                         objectScript2.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y);
                }
            }
        }
    }
}
