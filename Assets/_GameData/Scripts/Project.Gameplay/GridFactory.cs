using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class GridFactory : Factory
	{
		[SerializeField] private int width, height;
		[SerializeField] private Tile tilePrefab;
		public Transform cam;

		private void Start()
		{
			GenerateGrid();
		}

		private void GenerateGrid()
		{
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					var spawnedTile = (Tile)GetProduct(new Vector3(x, y));
					var isOffset = x % 2 == 0 && y % 2 != 0 || x % 2 != 0 && y % 2 == 0;
					spawnedTile.IsOffset = isOffset;
					spawnedTile.Initialize($"Tile {x} {y}",0);

				}
			}
			cam.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10);
		}

		public override IProduct GetProduct(Vector3 position)
		{
			Tile instance = Instantiate(tilePrefab, position, Quaternion.identity, transform);
			return instance;
		}
	}
}