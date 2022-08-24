using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Drag : MonoBehaviour,IDragHandler{
    [SerializeField] private RectTransform dragRectTransform; //움직일대상지정
    [SerializeField] private Canvas canvas;//캔버스지정

    public void OnDrag(PointerEventData eventData)
    {
       dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;//드래그
    }

}