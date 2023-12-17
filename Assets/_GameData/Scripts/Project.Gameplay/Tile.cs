using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class Tile : MonoBehaviour, IProduct
	{
		[SerializeField] private Color baseColor, offsetColor;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private SpriteRenderer highlight;
		private bool isAvailable = true;
		public bool IsOffset { get; set; }
		private string productName;
		public string ProductName { get => productName; set => productName = value; }
		public bool IsAvailable
		{
			get => isAvailable;
			set
			{
				isAvailable = value;
				if (!isAvailable)
				{
					highlight.color = Color.red;
				}
				else
				{
					highlight.color = Color.white;
				}
			}
		}

		public void Initialize(string name, float hitPoint)
		{
			ProductName = name;
			gameObject.name = ProductName;
			isAvailable = true;
			if (TryGetComponent(out spriteRenderer))
			{
				spriteRenderer.color = IsOffset ? offsetColor : baseColor;
			}
		}

		public void AvailableHighLight() 
		{
			highlight?.gameObject.SetActive(true);
			highlight.color = new Color(75, 231, 75, 180);
		}
		public void NotAvailableHighLight() 
		{
			highlight?.gameObject.SetActive(true);
			highlight.color = new Color(231, 75, 75, 180);
		}
		public void DisableHighLight()
		{
			highlight?.gameObject.SetActive(false);
			highlight.color = Color.white;
		}


		//private void OnMouseEnter()
		//{
		//	highlight?.gameObject.SetActive(true);

		//}
		//private void OnMouseOver()
		//{
		//	highlight?.gameObject.SetActive(true);
		//}
		//private void OnMouseExit()
		//{
		//	highlight?.gameObject.SetActive(false);
		//}

	}
}