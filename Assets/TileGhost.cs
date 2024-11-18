using Project.Gameplay;
using Project.Shared;
using System.Collections.Generic;
using UnityEngine;

public class TileGhost : MonoBehaviour
{
	public List<Tile> tiles;
	public Unit selectedUnit;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private BoxCollider2D collider2d;
	private Vector2 size;
	private void OnEnable()
	{
		EventManager.OnUnitSelect += OnUnitSelectHandler;
	}
	private void OnDisable()
	{
		EventManager.OnUnitSelect -= OnUnitSelectHandler;
	}
	public void OnUnitSelectHandler(GameObject unit)
	{
		collider2d.size = unit.GetComponent<BoxCollider2D>().size;
		spriteRenderer.size = unit.GetComponent<SpriteRenderer>().size;
		unit.TryGetComponent(out selectedUnit);
		size = selectedUnit.size;
		transform.position = unit.transform.position;
	}
	private void Update()
	{
		if (Input.GetMouseButton(0) && selectedUnit != null)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			transform.position = mousePos;
			Vector3 snappedPos = GetNearestTileCenter(mousePos);

			if (tiles.Count < collider2d.size.x * collider2d.size.y) return;
			selectedUnit.transform.position = snappedPos;
		}
	}


	private Vector3 GetNearestTileCenter(Vector3 position)
	{
		if (tiles.Count == 0) return position;

		float tileSize = 1;
		float halfTileSize = tileSize / 2f;

		// Calculate the snapped position by finding the nearest tile's center
		float snappedX = Mathf.Round(position.x / tileSize) * tileSize + halfTileSize;
		float snappedY = Mathf.Round(position.y / tileSize) * tileSize + halfTileSize;

		// Return the snapped position as the center of the nearest tile
		return new Vector3(snappedX, snappedY, 0);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Tile tile))
		{
			if (tile.IsAvailable)
			{
				if (!tiles.Contains(tile))
				{
					tiles.Add(tile);
				}
			}
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Tile tile))
		{
			if (tiles.Contains(tile))
			{
				tiles.Remove(tile);
			}
		}
	}
}
