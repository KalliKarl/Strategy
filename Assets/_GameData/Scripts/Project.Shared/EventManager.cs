using System;
using UnityEngine;

namespace Project.Shared
{
	public static class EventManager
	{

		public static Action<GameObject> OnUnitSelect;
		public static void RaiseOnUnitSelect(GameObject unit) => OnUnitSelect?.Invoke(unit);

		public static Action<ProductionType> OnUnitProductionClicked;
		public static void RaiseOnUnitProductionClicked(ProductionType productionType) => OnUnitProductionClicked?.Invoke(productionType);

		public static Action<ProductionType,GameObject> OnUnitGenerated;
		public static void RaiseOnUnitGenerated(ProductionType unit, GameObject go) => OnUnitGenerated?.Invoke(unit, go);

	}
}