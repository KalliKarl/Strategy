using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public abstract class Unit : MonoBehaviour, IProduct
	{
		private string productName;
		public string ProductName { get => productName; set => productName = value; }
		protected float hitPoint;

		public virtual void Initialize(string name, float hitPoint)
		{
			ProductName = name;
			this.hitPoint = hitPoint;
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

	}
}