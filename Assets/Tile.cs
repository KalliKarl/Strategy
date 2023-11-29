using UnityEngine;

public class Tile : MonoBehaviour
{
	[SerializeField] private Color baseColor, offsetColor;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject highlight;

	public void Init(bool isOffset)
	{
		spriteRenderer.color = isOffset ? offsetColor : baseColor;
	}

	private void OnMouseEnter()
	{

	}
	private void OnMouseExit()
	{

	}

}
