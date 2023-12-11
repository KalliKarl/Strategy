using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.GameUI
{
	public class ProductionUI : MonoBehaviour, IPointerDownHandler
	{


		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log("Clicked on: " + gameObject.name);
		}

	}
}