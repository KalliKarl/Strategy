using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class InputManager : MonoBehaviour
	{
		public Unit selectedUnit;
		public LayerMask layerMask;
		private Vector3 previousPosition;


		private void OnEnable()
		{
			EventManager.OnUnitGenerated += OnUnitGeratedHandler;
		}
		private void OnDisable()
		{
			EventManager.OnUnitGenerated -= OnUnitGeratedHandler;
		}
		private void OnUnitGeratedHandler(ProductionType productionType, GameObject go)
		{
			selectedUnit = go.GetComponent<Unit>();
			SelectUnit();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (selectedUnit != null) return;

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

				if (hit.collider != null && hit.collider.gameObject != gameObject)
				{
					Debug.Log("Clicked: " + hit.collider.gameObject.name, hit.collider.gameObject);
					if (hit.transform.TryGetComponent(out selectedUnit))
					{
						SelectUnit();

					}
				}
			}
			if (Input.GetMouseButtonUp(0))
			{
				if (selectedUnit != null)
				{
					var size = (selectedUnit.size.x * selectedUnit.size.y);
					Debug.Log("allOK=?" + selectedUnit.AreAllTilesAvailable());

					if (!selectedUnit.isSpawned && selectedUnit.tiles.Count < size)
					{
						foreach (Tile tile in selectedUnit.tiles)
						{
							tile.ChangeTileState(TileStates.Hidden);
						}
						Destroy(selectedUnit.gameObject);
					}
					else
					{
						if (selectedUnit.tiles.Count > size)
						{
							if (selectedUnit.AreAllTilesAvailable())
							{
								selectedUnit.MakeTilesNotAvailable();
							}
							else
							{
								selectedUnit.transform.position = previousPosition;
								if (!selectedUnit.isSpawned)
								{
									Destroy(selectedUnit.gameObject);
								}
							}
						}
						else
						{
							Destroy(selectedUnit.gameObject);
						}

					}
					
					selectedUnit = null;
				}
			}
		}

		private void SelectUnit()
		{
			previousPosition = selectedUnit.transform.position;
			EventManager.RaiseOnUnitSelect(selectedUnit.gameObject);
		}
	}
}
