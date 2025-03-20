namespace FlappyBird.Game;

using Chickensoft.LogicBlocks;

public interface IGameLogic : ILogicBlock<GameState>;

public record GameState : StateLogic<GameState>;
