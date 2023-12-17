using Project.Gameplay;
using Project.Shared;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileGhost : MonoBehaviour
{
	public List<Tile> tiles;
	public Barracks selectedBarrack;
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
		unit.TryGetComponent( out selectedBarrack);
		unit.TryGetComponent(out Soldier selectedSoldiler);
		unit.TryGetComponent(out PowerPlant selectedPowerPlant);

		transform.position = unit.transform.position;
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
