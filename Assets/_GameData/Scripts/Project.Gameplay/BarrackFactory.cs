using Project.Shared;
using UnityEngine;

namespace Project.Gameplay
{
	public class BarrackFactory : Factory
	{
		[SerializeField] private int width, height;
		[SerializeField] private Barracks barracksPrefab;

		public static BarrackFactory Instance;
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
				case ProductionType.Barracks:
					var position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
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
			Barracks instance = Instantiate(barracksPrefab, position, Quaternion.identity);
			instance.Initialize(instance.data.unitName, instance.data.hitPoint);
			EventManager.RaiseOnUnitGenerated(instance.data.type, instance.gameObject);


			return instance;
		}
	}
}