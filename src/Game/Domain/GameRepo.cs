namespace FlappyBird.Game;

public class GameRepo : IGameRepo {
	#region Properties
	public IAutoProp<bool> IsStarted => _isStarted;
	private readonly AutoProp<bool> _isStarted = new(false);

	public IAutoProp<bool> IsPaused => _isPaused;
	private readonly AutoProp<bool> _isPaused = new(false);

	public IAutoProp<bool> IsMouseCaptured => _isMouseCaptured;
	private readonly AutoProp<bool> _isMouseCaptured = new(false);

	public IAutoProp<int> Score => _score;
	private readonly AutoProp<int> _score = new(0);

	public IAutoProp<bool> IsGameOver => _isGameOver;
	private readonly AutoProp<bool> _isGameOver = new(false);

	public event Action? GameStarted;
	public event Action? GameOver;
	public event Action? ScoreIncreased;

	public GameRepo() {
		_isStarted = new AutoProp<bool>(false);
		_isPaused = new AutoProp<bool>(false);
		_isMouseCaptured = new AutoProp<bool>(false);
		_score = new AutoProp<int>(0);
		_isGameOver = new AutoProp<bool>(false);
	}

	internal GameRepo(AutoProp<bool> isStarted, AutoProp<bool> isPaused, AutoProp<bool> isMouseCaptured, AutoProp<int> score, AutoProp<bool> isGameOver) {
		_isStarted = isStarted;
		_isPaused = isPaused;
		_isMouseCaptured = isMouseCaptured;
		_score = score;
		_isGameOver = isGameOver;
	}
	#endregion Properties

	#region Actions
	public void StartGame() {
		_isStarted.OnNext(true);
		_isGameOver.OnNext(false);
		_score.OnNext(0);
		GameStarted?.Invoke();
	}

	public void PauseGame() {
		_isPaused.OnNext(true);
		_isMouseCaptured.OnNext(false);
	}

	public void ResumeGame() {
		_isPaused.OnNext(false);
		_isMouseCaptured.OnNext(true);
	}

	public void EndGame() {
		_isGameOver.OnNext(true);
		_isMouseCaptured.OnNext(false);
		GameOver?.Invoke();
	}

	public void SetIsMouseCaptured(bool value) => _isMouseCaptured.OnNext(value);

	public void IncrementScore() {
		_score.OnNext(_score.Value + 1);
		ScoreIncreased?.Invoke();
	}
	#endregion Actions

	#region GC
	private bool _disposed;

	public void Dispose() {
		if (!_disposed) {
			_isStarted.OnCompleted();
			_isStarted.Dispose();
			_isPaused.OnCompleted();
			_isPaused.Dispose();
			_isMouseCaptured.OnCompleted();
			_isMouseCaptured.Dispose();
			_score.OnCompleted();
			_score.Dispose();
			_isGameOver.OnCompleted();
			_isGameOver.Dispose();

			_disposed = true;
		}
		GC.SuppressFinalize(this);
	}
	#endregion GC
}
