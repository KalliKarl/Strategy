using Project.Shared;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Gameplay
{
	public class SoldierFactory : Factory
	{
		[SerializeField] private int width, height;
		[SerializeField] private List<Soldier> soldiersPrefabs;

		public static SoldierFactory Instance;
		private int soldierIndex;

		private void OnEnable()
		{
			EventManager.OnUnitProductionClicked += OnUnitProductionClickedHandler;
		}
		private void OnDisable()
		{
			EventManager.OnUnitProductionClicked -= OnUnitProductionClickedHandler;


		}

		private void OnUnitProductionClickedHandler(ProductionType productionType)
		{
			var position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
			switch (productionType)
			{
				case ProductionType.Soldier1:
					GenerateSoldier(position,0);
					break;
				case ProductionType.Soldier2:
					GenerateSoldier(position, 1);
					break;
				case ProductionType.Soldier3:
					GenerateSoldier(position, 2);
					break;
			}
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(Instance.gameObject);
			}
		}
		public void GenerateSoldier(Vector3 spawnPosition, int soldierIndex = 0)
		{
			this.soldierIndex = soldierIndex;
			Soldier spawnedSoldier = (Soldier)GetProduct(spawnPosition);
			spawnedSoldier.Initialize(soldiersPrefabs[soldierIndex].data.unitName, soldiersPrefabs[soldierIndex].data.hitPoint);
			EventManager.RaiseOnUnitGenerated(spawnedSoldier.data.type, gameObject);
		}

		public override IProduct GetProduct(Vector3 position)
		{
			Soldier instance = Instantiate(soldiersPrefabs[soldierIndex], position, Quaternion.identity, transform);
			return instance;
		}
	}
}