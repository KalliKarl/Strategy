using UnityEngine;

namespace Project.Shared
{
	[CreateAssetMenu(fileName ="UnitData",menuName ="CreateUnitData")]
	public class UnitData : ScriptableObject
	{
		public string unitName;
		public ProductionType type;
		public int hitPoint;
		public int damage;
		public Vector2 size;
		public Sprite icon;
	}
}