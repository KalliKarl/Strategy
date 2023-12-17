using Project.Shared;
using System.Collections;
using UnityEngine;

namespace Project.Gameplay
{
	public class Soldier : Unit
	{
		private Unit target;
		private float damage;
		private float attackSpeed;
		private Coroutine attackCoroutine;
		public UnitData data;

		public override void GetDamage(float damage)
		{
			base.GetDamage(damage);
		}

		private void DoDamage(float damage, Unit target)
		{
			target.GetDamage(damage);
		}

		public void AttackToSelected(Unit selectedTarget)
		{
			target = selectedTarget;
			if (IsArrived())
			{
				attackCoroutine ??= StartCoroutine(Attack());
			}
			else
			{
				MoveToTarget();
			}
		}

		private bool IsArrived()
		{
			return Vector3.Distance(target.transform.position, transform.position) < 3;
		}

		private IEnumerator Attack()
		{
			WaitForSeconds attackCoolDown = new(attackSpeed);
			while (hitPoint > 0 || target.IsAlive())
			{
				DoDamage(damage, target);
				yield return attackCoolDown;
			}
		}
		public void MoveToTarget()
		{

		}
		public override void Initialize(string name, float hitPoint)
		{
			base.Initialize(name, hitPoint);
		}
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Tile tile))
			{
				if (myTiles.Contains(tile))
				{
					tile.GreenHighLight();
					if (!tiles.Contains(tile))
					{
						tiles.Add(tile);
					}
				}
				else if (tile.IsAvailable)
				{
					if (!tiles.Contains(tile))
					{
						tile.GreenHighLight();
						tiles.Add(tile);
					}
				}
				else
				{
					if (!tiles.Contains(tile))
					{
						tile.RedHighLight();
					}
				}
			}
		}
		private void OnTriggerExit2D(Collider2D collision)
		{
			if (collision.gameObject.TryGetComponent(out Tile tile))
			{

				if (tiles.Contains(tile))
				{
					tiles.Remove(tile);
					tile.HideHighLight();
				}
			}
		}

	}
}