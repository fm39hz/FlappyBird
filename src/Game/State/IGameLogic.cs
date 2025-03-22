namespace FlappyBird.Game;

using Chickensoft.LogicBlocks;

public interface IGameLogic : ILogicBlock<GameLogic.State>;

[LogicBlock(typeof(State))]
public partial class GameLogic : LogicBlock<GameLogic.State>, IGameLogic {
	public override Transition GetInitialState() => throw new NotImplementedException();
}
