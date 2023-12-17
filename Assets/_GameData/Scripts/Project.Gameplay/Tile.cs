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
			}
		}
		private void OnEnable()
		{
			EventManager.OnUnitGenerated += OnUnitGeratedHandler;
		}
		private void OnDisable()
		{
			EventManager.OnUnitGenerated -= OnUnitGeratedHandler;
		}
		private void OnUnitGeratedHandler(ProductionType productionType, GameObject go)
		{
			HideHighLight();
		}
		public void Initialize(string name, float hitPoint)
		{
			ProductName = name;
			gameObject.name = ProductName;
			IsAvailable = true;
			if (TryGetComponent(out spriteRenderer))
			{
				spriteRenderer.color = IsOffset ? offsetColor : baseColor;
			}
		}

		public void GreenHighLight() 
		{
			highlight?.gameObject.SetActive(true);
			highlight.color = new Color32(75, 231, 75, 180);
		}
		public void RedHighLight() 
		{
			highlight?.gameObject.SetActive(true);
			highlight.color = new Color32(231, 75, 75, 180);
		}
		public void HideHighLight()
		{
			highlight?.gameObject.SetActive(false);
			highlight.color = new Color32(231, 231, 231, 128);
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