namespace FlappyBird.Game;

using FlappyBird.Bird;

public interface IGame : INode2D, IProvide<IGameRepo>, IProvide<IGameLogic> {
	public IGameRepo GameRepo { get; }
	public IGameLogic GameLogic { get; }
	public IBird Bird { get; }
}

[Id(nameof(Game))]
[Meta(typeof(IAutoNode))]
public partial class Game : Node2D, IGame {
	#region DI

	public override void _Notification(int what) => this.Notify(what);

	#endregion DI

	public IGameRepo GameRepo => new GameRepo();
	public IGameLogic GameLogic => new GameLogic();
	IGameRepo IProvide<IGameRepo>.Value() => GameRepo;
	IGameLogic IProvide<IGameLogic>.Value() => GameLogic;

	[Node] public IBird Bird { get; set; } = null!;
}
