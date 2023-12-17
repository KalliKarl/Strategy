using Project.Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
	public class PowerPlant : Unit
	{
		public List<Tile> tiles;
		public Shared.Unit data;
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
				if (tile.IsAvailable)
				{
					if (!tiles.Contains(tile))
					{
						tiles.Add(tile);
						tile.IsAvailable = false;
					}
				}
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Tile tile))
			{
				if (!tile.IsAvailable)
				{
					if (tiles.Contains(tile))
					{
						tiles.Remove(tile);
						tile.IsAvailable = true;

					}
				}
			}
		}
	}
}