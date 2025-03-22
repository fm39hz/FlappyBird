namespace FlappyBird.Game;

using FlappyBird.Bird;

public class BirdRepo : IBirdRepo {
	#region Properties
	public IAutoProp<bool> IsFalling => _isFalling;
	private readonly AutoProp<bool> _isFalling;

	public IAutoProp<bool> IsAlive => _isAlive;
	private readonly AutoProp<bool> _isAlive;

	public IAutoProp<Vector2> Position => _position;
	private readonly AutoProp<Vector2> _position;

	public IAutoProp<float> Rotation => _rotation;
	private readonly AutoProp<float> _rotation;

	public event Action? BirdJumped;
	public event Action? BirdFalling;
	public event Action? BirdCrashed;

	public BirdRepo() {
		_isFalling = new AutoProp<bool>(true);
		_isAlive = new AutoProp<bool>(true);
		_position = new AutoProp<Vector2>(Vector2.Zero);
		_rotation = new AutoProp<float>(0f);
	}

	internal BirdRepo(AutoProp<bool> isFalling, AutoProp<bool> isAlive, AutoProp<Vector2> position, AutoProp<float> rotation) {
		_isFalling = isFalling;
		_isAlive = isAlive;
		_position = position;
		_rotation = rotation;
	}
	#endregion Properties

	#region Actions
	public void Jump() => BirdJumped?.Invoke();

	public void SetPosition(Vector2 position) => _position.OnNext(position);

	public void SetRotation(float rotation) => _rotation.OnNext(rotation);

	public void Die() => _isAlive.OnNext(false);

	public void Reset() {
		_isAlive.OnNext(true);
		_isFalling.OnNext(false);
		_rotation.OnNext(0f);
	}
	#endregion Actions

	#region GC
	private bool _disposed;

	public void Dispose() {
		if (!_disposed) {
			_isFalling.OnCompleted();
			_isFalling.Dispose();
			_isAlive.OnCompleted();
			_isAlive.Dispose();
			_position.OnCompleted();
			_position.Dispose();
			_rotation.OnCompleted();
			_rotation.Dispose();

			_disposed = true;
		}
		GC.SuppressFinalize(this);
	}
	#endregion GC
}
