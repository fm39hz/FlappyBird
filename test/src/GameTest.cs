namespace FlappyBird.Test;

using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Chickensoft.GodotTestDriver;
using Game;

public class GameTest(Node testScene) : TestClass(testScene) {
	private Fixture _fixture = null!;
	private Game _game = null!;

	[SetupAll]
	public async Task Setup() {
		_fixture = new Fixture(TestScene.GetTree());
		_game = await _fixture.LoadAndAddScene<Game>();
	}

	[CleanupAll]
	public void Cleanup() => _fixture.Cleanup();

	[Test]
	public void TestGameRepo() => _game.GameRepo.TestAvailable();

	[Test]
	public void TestBirdAvailable() => _game.Bird.TestAvailable();
}
