using Project.Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
	public class Barracks : MonoBehaviour, IProduct
	{
		public List<Tile> tiles;

		public string ProductName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public void Initialize()
		{
			throw new System.NotImplementedException();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Debug.Log(collision.gameObject.name);
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
			Debug.Log(collision.gameObject.name);
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