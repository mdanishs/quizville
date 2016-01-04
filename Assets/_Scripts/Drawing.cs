using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class Drawing : MonoBehaviour, IDragHandler
{
    public GameObject point;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    GameObject newPoint = Instantiate(point);
        //    newPoint.transform.SetParent(this.gameObject.transform);
        //    Vector3 mousePosition = Input.mousePosition;
        //    newPoint.GetComponent<RectTransform>().anchoredPosition = RectTransformUtility.ScreenPointToLocalPointInRectangle(this.transform, Camera.main, mousePosition);
        //    newPoint.GetComponent<RectTransform>().localScale = Vector3.one * 5;
        //    newPoint.GetComponent<Image>().SetNativeSize();
        //    print("dragging");
        //}
    }
    void Update()
    {
       
    }
    void OnMouseDrag()
    {
        
    }

    void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
    {
        int dy = (int)(y1 - y0);
        int dx = (int)(x1 - x0);
        int stepx, stepy;

        if (dy < 0) { dy = -dy; stepy = -1; }
        else { stepy = 1; }
        if (dx < 0) { dx = -dx; stepx = -1; }
        else { stepx = 1; }
        dy <<= 1;
        dx <<= 1;

        float fraction = 0;

        tex.SetPixel(x0, y0, col);
        if (dx > dy)
        {
            fraction = dy - (dx >> 1);
            while (Mathf.Abs(x0 - x1) > 1)
            {
                if (fraction >= 0)
                {
                    y0 += stepy;
                    fraction -= dx;
                }
                x0 += stepx;
                fraction += dy;
                tex.SetPixel(x0, y0, col);
            }
        }
        else {
            fraction = dx - (dy >> 1);
            while (Mathf.Abs(y0 - y1) > 1)
            {
                if (fraction >= 0)
                {
                    x0 += stepx;
                    fraction -= dy;
                }
                y0 += stepy;
                fraction += dx;
                tex.SetPixel(x0, y0, col);
            }
        }
    }

    public void OnDrag(PointerEventData dat)
    {
        Vector2 localCursor;
        var rect1 = GetComponent<RectTransform>();
        var pos1 = dat.position;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rect1, pos1,
            null, out localCursor))
            return;

        int xpos = (int)(localCursor.x);
        int ypos = (int)(localCursor.y);

        //if (xpos < 0) xpos = xpos + (int)rect1.rect.width / 2;
        //else xpos += (int)rect1.rect.width / 2;

        //if (ypos > 0) ypos = ypos + (int)rect1.rect.height / 2;
        //else ypos -= (int)rect1.rect.height / 2;

        GameObject newPoint = Instantiate(point);
        newPoint.transform.SetParent(this.gameObject.transform);
        newPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(xpos, ypos);

        newPoint.GetComponent<Image>().SetNativeSize();
    }
}