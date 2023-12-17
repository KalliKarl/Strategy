using System;
using UnityEngine;

namespace Project.Shared
{
	public static class EventManager
	{

		public static Action<GameObject> OnUnitSelect;
		public static void RaiseOnUnitSelect(GameObject unit) => OnUnitSelect?.Invoke(unit);

	}
}