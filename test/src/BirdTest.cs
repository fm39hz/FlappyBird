namespace FlappyBird.Test;

using System.Threading.Tasks;
using Bird;
using Chickensoft.GoDotTest;
using Chickensoft.GodotTestDriver;

public class BirdTest(Node testScene) : TestClass(testScene) {
	private Fixture _fixture = null!;
	private Bird _bird = null!;

	[SetupAll]
	public async Task Setup() {
		_fixture = new Fixture(TestScene.GetTree());
		_bird = await _fixture.LoadAndAddScene<Bird>();
	}

	[CleanupAll]
	public void Cleanup() => _fixture.Cleanup();

	[Test]
	public void TestBirdRepo() => _bird.BirdRepo.TestAvailable();
}
