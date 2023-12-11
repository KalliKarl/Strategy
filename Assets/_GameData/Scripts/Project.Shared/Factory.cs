using UnityEngine;

namespace Project.Shared
{
	public abstract class Factory : MonoBehaviour
	{
		public abstract IProduct GetProduct(Vector3 position);
	}
}