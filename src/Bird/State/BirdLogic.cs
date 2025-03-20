namespace FlappyBird.Bird;

using Chickensoft.LogicBlocks;

public interface IBirdLogic : ILogicBlock<BirdState>;

public record BirdState : StateLogic<BirdState>;
