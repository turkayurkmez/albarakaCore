namespace POCDependencyLifeCycle.Services
{
	public interface IGuidGenerator
	{
		public Guid Guid { get; set; }
	}

	public interface ISingletonGuid : IGuidGenerator
	{

	}

	public interface IScopedGuid : IGuidGenerator
	{

	}

	public interface ITransientGuid : IGuidGenerator
	{

	}

	public class SingletonGuid : ISingletonGuid
	{
		public SingletonGuid()
		{
			Guid = Guid.NewGuid();
		}
		public Guid Guid { get; set; }
	}

	public class ScopedGuid : IScopedGuid
	{
		public Guid Guid { get; set; }
		public ScopedGuid()
		{
			Guid = Guid.NewGuid();
		}
	}

	public class TransientGuid : ITransientGuid
	{
		public Guid Guid { get; set; }
		public TransientGuid()
		{
			Guid = Guid.NewGuid();
		}
	}
}
