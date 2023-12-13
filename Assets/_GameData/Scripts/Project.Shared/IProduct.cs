namespace Project.Shared
{
	public interface IProduct
	{
		public string ProductName { get; set; }

		public void Initialize(string name, float hitPoint);
	}
}