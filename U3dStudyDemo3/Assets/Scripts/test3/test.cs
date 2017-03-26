using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class test : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerUpHandler,IPointerDownHandler,IPointerClickHandler
,IBeginDragHandler,IInitializePotentialDragHandler,IDragHandler,IDropHandler,IEndDragHandler
,ISelectHandler,IDeselectHandler,IUpdateSelectedHandler{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("OnDeselect");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop" + eventData.pointerDrag.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("OnInitializePotentialDrag");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");

        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("OnSelect");
        
    }

    public void OnUpdateSelected(BaseEventData eventData)
    {
        Debug.Log("OnUpdateSelected");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
