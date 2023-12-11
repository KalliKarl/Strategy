using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProductionUI : MonoBehaviour, IPointerDownHandler
{
	

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("Clicked on: " + gameObject.name);
	}

}
