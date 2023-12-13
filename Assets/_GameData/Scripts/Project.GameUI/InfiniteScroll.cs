using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project.GameUI
{
	public class InfiniteScroll : MonoBehaviour
	{
		public List<RectTransform> contentScroll = new List<RectTransform>();
		public RectTransform content;

		private float contentHeight;
		private float currentY;
		private int lastScrollIndex;

		private void Awake()
		{
			contentHeight = contentScroll[0].sizeDelta.y;
			lastScrollIndex = 0;
			for (int i = 0; i < contentScroll.Count; i++)
			{
				var contentUI = contentScroll[i].GetComponent<ProductionUI>();
				contentUI.Init();
				contentUI.nameTxt.text = "<size=18>" + i.ToString() + " - </size>" + contentUI.nameTxt.text;

			}
		}

		public void HandleScrollRectValueChanged(Vector2 value)
		{
			currentY = content.anchoredPosition.y;
			int currentScrollIndex = Mathf.RoundToInt(currentY / contentHeight);

			if (currentScrollIndex != lastScrollIndex)
			{
				int deltaIndex = currentScrollIndex - lastScrollIndex;
				if (deltaIndex > 0) // Scrolling down
				{
					RectTransform first = contentScroll[0];
					RectTransform second = contentScroll[1];
					RectTransform last = contentScroll[contentScroll.Count - 1];

					first.anchoredPosition = new Vector2(first.anchoredPosition.x, last.anchoredPosition.y - contentHeight);
					second.anchoredPosition = new Vector2(second.anchoredPosition.x, last.anchoredPosition.y - contentHeight);

					contentScroll.RemoveAt(0);
					contentScroll.RemoveAt(0);
					contentScroll.Add(first);
					contentScroll.Add(second);

				}
				else if (deltaIndex < 0) // Scrolling up
				{
					RectTransform last = contentScroll[contentScroll.Count - 1];
					RectTransform lastbutone = contentScroll[contentScroll.Count - 2];
					RectTransform first = contentScroll[0];

					last.anchoredPosition = new Vector2(last.anchoredPosition.x, first.anchoredPosition.y + contentHeight);
					lastbutone.anchoredPosition = new Vector2(lastbutone.anchoredPosition.x, first.anchoredPosition.y + contentHeight);

					contentScroll.RemoveAt(contentScroll.Count - 1);
					contentScroll.RemoveAt(contentScroll.Count - 1);
					contentScroll.Insert(0, last);
					contentScroll.Insert(0, lastbutone);

				}

				lastScrollIndex = currentScrollIndex;
			}
		}
	}
}