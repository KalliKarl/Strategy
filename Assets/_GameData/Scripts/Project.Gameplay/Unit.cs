using Project.Shared;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Gameplay
{
	public abstract class Unit : MonoBehaviour, IProduct
	{
		private string productName;
		public string ProductName { get => productName; set => productName = value; }
		protected float hitPoint;
		public Vector2 size;
		public List<Tile> tiles;
		public List<Tile> myTiles;
		public bool isSpawned;
		public virtual void Initialize(string name, float hitPoint, Vector2 size)
		{
			ProductName = name;
			this.hitPoint = hitPoint;
			this.size = size;
			Debug.Log(gameObject.name + " Initialized", gameObject);
		}

		public virtual void GetDamage(float damage)
		{
			hitPoint = Mathf.Max(damage, 0);
			if (hitPoint <= 0)
			{
				Debug.Log(gameObject.name + " Destroyed", gameObject);
				gameObject.SetActive(false);
				Destroy(gameObject);
			}
		}
		public bool IsAlive()
		{
			return hitPoint > 0;
		}
		public bool AreAllTilesAvailable()
		{
			foreach (Tile tile in tiles)
			{
				if (!tile.IsAvailable && !myTiles.Contains(tile))
				{
					return false;
				}
			}
			return true;
		}

		public void MakeTilesAvailable()
		{
			foreach (var item in myTiles)
			{
				item.IsAvailable = true;
				item.ChangeTileState(TileStates.Hidden);
			}
		}
		public void MakeTilesNotAvailable()
		{
			MakeTilesAvailable();
			foreach (var item in tiles)
			{
				item.IsAvailable = false;
				item.ChangeTileState(TileStates.Hidden);
				myTiles = tiles.ToList();
			}
			tiles.Clear();
			isSpawned = true;

		}

	}
}