using UnityEngine;

namespace Project.Shared
{
	[CreateAssetMenu(fileName ="UnitData",menuName ="CreateUnitData")]
	public class Unit : ScriptableObject
	{
		public string unitName;
		public ProductionType type;
		public string hitPoint;
		public string damage;
		public Vector2 size;
		public Sprite icon;
	}
}