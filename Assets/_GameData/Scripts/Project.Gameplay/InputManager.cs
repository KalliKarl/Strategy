using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class InputManager : MonoBehaviour
	{
		public Unit selectedUnit;
		public LayerMask layerMask;
		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

				if (hit.collider != null && hit.collider.gameObject != gameObject)
				{
					Debug.Log("Clicked: " + hit.collider.gameObject.name, hit.collider.gameObject);
					selectedUnit = hit.transform.GetComponent<Unit>();
					EventManager.RaiseOnUnitSelect(selectedUnit.gameObject);
				}
			}
		}
	}
}
