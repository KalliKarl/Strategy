using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class PowerPlant : Unit
	{
		public UnitData data;
		public override void GetDamage(float damage)
		{
			base.GetDamage(damage);
		}

		public override void Initialize(string name, float hitPoint, Vector2 size)
		{
			base.Initialize(name, hitPoint, size);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Tile tile))
			{
				if (myTiles.Contains(tile))
				{
					tile.ChangeTileState(TileStates.Green);

					if (!tiles.Contains(tile))
					{
						tiles.Add(tile);
					}
				}
				else if (tile.IsAvailable)
				{
					if (!tiles.Contains(tile))
					{
						tile.ChangeTileState(TileStates.Green);
						tiles.Add(tile);
					}
				}
				else
				{
					if (!tiles.Contains(tile))
					{
						tile.ChangeTileState(TileStates.Red);
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
					tile.ChangeTileState(TileStates.Hidden);
				}
			}
		}
	}
}