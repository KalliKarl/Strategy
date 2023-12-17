using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class Barracks : Unit
	{
		public UnitData data;
		public override void GetDamage(float damage)
		{
			base.GetDamage(damage);
		}

		public override void Initialize(string name, float hitPoint)
		{
			base.Initialize(name, hitPoint);
		}


		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Tile tile))
			{
				if (myTiles.Contains(tile))
				{
					tile.GreenHighLight();
					if (!tiles.Contains(tile))
					{
						tiles.Add(tile);
					}
				}
				else if (tile.IsAvailable)
				{
					if (!tiles.Contains(tile))
					{
						tile.GreenHighLight();
						tiles.Add(tile);
					}
				}
				else
				{
					if (!tiles.Contains(tile))
					{
						tile.RedHighLight();
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
					tile.HideHighLight();
				}
			}
		}
	}
}