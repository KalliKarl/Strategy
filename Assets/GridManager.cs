using UnityEngine;

public class GridManager : MonoBehaviour
{
	[SerializeField] private int width, height;
	[SerializeField] private Tile tilePrefab;
	public Transform cam;
	void Start()
	{
		GenerateGrid();
	}
	private void GenerateGrid()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
				spawnedTile.name = $"Tile {x} {y}";

				var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
				spawnedTile.Init(isOffset);
			}
		}
		cam.transform.position = new Vector3(width / 2f - 0.5f, height / 2f - 0.5f, -10);
	}
}

