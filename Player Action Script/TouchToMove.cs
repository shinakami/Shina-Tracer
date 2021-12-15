using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchToMove : MonoBehaviour, IDragHandler
{
    [SerializeField] 
    private Canvas _canvas;
    private RectTransform _currentPosition;

    void Awake()
    {
        _currentPosition = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _currentPosition.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
   

}
