using Project.Shared;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Project.GameUI
{
	public class ProductionUI : MonoBehaviour, IPointerDownHandler
	{
		public UnitData unitData;
		public Image image;
		public TMP_Text nameTxt;

		public void Init()
		{
			gameObject.name = unitData.unitName;
			nameTxt.text = unitData.unitName;
			image.sprite = unitData.icon;
		}
		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.Log("Clicked on: " + gameObject.name);
		}

	}
}