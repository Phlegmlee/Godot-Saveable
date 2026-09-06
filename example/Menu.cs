using Godot;
using Saveable;

namespace Example;

public partial class Menu : Control, ISaveable
{
	StringName ISaveable.UniqueID => "Menu";

	[Export] private Button SaveButton = null!;
	[Export] private Button LoadButton = null!;

	[Export] private SpinBox fValueSpin = null!;
	[Export] private SpinBox iValueSpin = null!;

	private float fValue = 0.0f;
	private int iValue = 0;

	const string FILE_PATH = "user://saves/example.save";

	#region Lifecycle

	public override void _EnterTree()
	{
		SaveButton.Pressed += OnSavePressed;
		LoadButton.Pressed += OnLoadPressed;

		fValueSpin.ValueChanged += OnFValueChanged;
		iValueSpin.ValueChanged += OnIValueChanged;
	}

	#endregion

	#region Save/Load

	void ISaveable.Load(NodeSave save)
	{
		fValue = save.GetProperty<float>(nameof(fValue));
		iValue = save.GetProperty<int>(nameof(iValue));

		fValueSpin.Value = fValue;
		iValueSpin.Value = iValue;
	}

	void ISaveable.Save(NodeSave save)
	{
		save.AddProperty(nameof(fValue), fValue);
		save.AddProperty(nameof(iValue), iValue);
	}

	#endregion

	#region Event Callbacks

	private void OnFValueChanged(double value)
	{
		fValue = (float)value;
	}

	private void OnIValueChanged(double value)
	{
		iValue = (int)value;
	}

	private void OnSavePressed()
	{
		TreeSave? save = SaveSystem.LoadFile(
			FILE_PATH,
			GetTree().Root,
			loadTree: false
		);

		SaveSystem.SaveFile(
			FILE_PATH,
			GetTree().Root,
			save
		);
	}

	private void OnLoadPressed()
	{
		SaveSystem.LoadFile(
			FILE_PATH,
			GetTree().Root
		);
	}

	#endregion
}
