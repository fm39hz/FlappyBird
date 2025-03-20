namespace FlappyBird.Game;

public interface IGameRepo : IDisposable {
	/// <summary> Game status </summary>
	public IAutoProp<bool> IsStarted { get; }
	/// <summary> Game Pause status </summary>
	public IAutoProp<bool> IsPaused { get; }
	/// <summary> Mouse capture status </summary>
	public IAutoProp<bool> IsMouseCaptured { get; }
	/// <summary> Score status </summary>
	public IAutoProp<int> Score { get; }
	/// <summary> Game Over status </summary>
	public IAutoProp<bool> IsGameOver { get; }

	/// <summary> Event invoked when the game starts </summary>
	public event Action? GameStarted;
	/// <summary> Event invoked when the game ends </summary>
	public event Action? GameOver;
	/// <summary> Event invoked when the score increases </summary>
	public event Action? ScoreIncreased;

	/// <summary> Inform the game has started </summary>
	public void StartGame();
	/// <summary> Inform the game has paused </summary>
	public void PauseGame();
	/// <summary> Inform the game has resumed </summary>
	public void ResumeGame();
	/// <summary> Inform the game has ended </summary>
	public void EndGame();
	/// <summary> Changes whether the mouse is captured or not </summary>
	/// <param name="value">Mouse capture status</param>
	public void SetIsMouseCaptured(bool value);
	/// <summary> Increment the score </summary>
	public void IncrementScore();
}
