using System;
using SubHubT;

namespace PerformanceTests
{
public class TestPubMessageStruct_Cached_NoSub : IPerformanceTest
{
	public TestPubMessageStruct_Cached_NoSub(Int32 iterations)
	{
		_iterations = iterations;
	}

	private Int32 _iterations;
	public Int32 Iterations => _iterations;

	public void Before( )
	{
		SubH.I = IoC.I.CreateSubH();
	}

	public void Run( )
	{
		var message = new MessageStruct(5);
		for ( int i = 0; i < _iterations; i++ )
		{
			SubH.I.Pub(message);
		}
	}
}
}