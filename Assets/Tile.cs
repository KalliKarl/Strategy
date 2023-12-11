using UnityEngine;

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

	public void Initialize()
	{
		gameObject.name = productName;
		isAvailable = true;
		if (TryGetComponent<SpriteRenderer>(out spriteRenderer))
		{
			spriteRenderer.color = IsOffset ? offsetColor : baseColor;
		}
	}

	private void OnMouseEnter()
	{
		highlight?.gameObject.SetActive(true);

	}
	private void OnMouseOver()
	{
		highlight?.gameObject.SetActive(true);
	}
	private void OnMouseExit()
	{
		highlight?.gameObject.SetActive(false);
	}

}
