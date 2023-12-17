using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class PowerPlantFactory : Factory
	{
		[SerializeField] private int width, height;
		[SerializeField] private PowerPlant powerPlantPrefab;

		public static PowerPlantFactory Instance;

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
			switch (productionType)
			{
				case ProductionType.PowerPlant:
					var position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
					GetProduct(position);
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
		public override IProduct GetProduct(Vector3 position)
		{
			PowerPlant instance = Instantiate(powerPlantPrefab, position, Quaternion.identity);
			instance.Initialize(instance.data.unitName, instance.data.hitPoint);
			EventManager.RaiseOnUnitGenerated(instance.data.type, instance.gameObject);
			return instance;
		}
	}
}