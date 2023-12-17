using Project.Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
	public class Barracks : Unit
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
						tile.AvailableHighLight();
						tiles.Add(tile);
					}
				}
				else
				{
					if (!tiles.Contains(tile))
					{
						tile.NotAvailableHighLight();
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
					tile.DisableHighLight();
				}
			}
		}
	}
}