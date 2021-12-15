using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonToJump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GamePlayerBehavior GamePlayerBehavior;
    public void OnPointerDown(PointerEventData eventData)
    {
        
        GamePlayerBehavior.JumpHold();
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        GamePlayerBehavior.JumpRelease();
     
    }
}
