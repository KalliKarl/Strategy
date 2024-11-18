using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class Tile : MonoBehaviour, IProduct
	{
		[SerializeField] private Color baseColor, offsetColor;
		[SerializeField] private SpriteRenderer spriteRenderer;
		[SerializeField] private SpriteRenderer highlight;
		private TileStates currentState;
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
			ChangeTileState(TileStates.Hidden);
		}
		public void Initialize(string name, float hitPoint, Vector2 size)
		{
			ProductName = name;
			gameObject.name = ProductName;
			IsAvailable = true;
			if (TryGetComponent(out spriteRenderer))
			{
				spriteRenderer.color = IsOffset ? offsetColor : baseColor;
			}
		}
		public void ChangeTileState(TileStates newState)
		{
			switch (newState)
			{
				case TileStates.Green:
					highlight.gameObject.SetActive(true);
					highlight.color = new Color32(75, 231, 75, 180);
					currentState = newState;
					break;
				case TileStates.Red:
					Debug.Log("Red" + gameObject.name, gameObject);
					highlight.gameObject.SetActive(true);
					highlight.color = new Color32(231, 75, 75, 180);
					currentState = newState;
					break;
				case TileStates.Hidden:
					if (currentState == TileStates.Red && newState == TileStates.Hidden)
					Debug.Log("hide" + gameObject.name, gameObject);
					highlight.gameObject.SetActive(false);
					highlight.color = new Color32(231, 231, 231, 128);
					currentState = newState;
					break;
			}
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
	public enum TileStates { Green, Red, Hidden }
}