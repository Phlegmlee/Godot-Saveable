using Godot;

namespace Saveable;

internal static class SlotManager
{
	/// <summary>
	/// Check if a save file exists.
	/// </summary>
	/// <param name="saveSlot">The save slot to check.</param>
	/// <returns>True if file exists, false otherwise.</returns>
	public static bool IsSavePresent(SaveSlotEnum saveSlot)
	{
		return FileAccess.FileExists(GetSaveFile(saveSlot));
	}

	/// <summary>
	/// Check if a save file exists.
	/// </summary>
	/// <param name="filePath">The file path to check.</param>
	/// <returns>True if file exists, false otherwise.</returns>
	public static bool IsSavePresent(string filePath)
	{
		return FileAccess.FileExists(filePath);
	}

	// TODO: method to get file info

	/// <summary>
	/// Returns the file path string for a given slot.
	/// </summary>
	internal static string GetSaveFile(SaveSlotEnum saveSlot)
	{
		return saveSlot switch
		{
			SaveSlotEnum.Autosave => SaveFiles.AutosaveFile,
			SaveSlotEnum.SlotOne => SaveFiles.SlotOneFile,
			SaveSlotEnum.SlotTwo => SaveFiles.SlotTwoFile,
			SaveSlotEnum.SlotThree => SaveFiles.SlotThreeFile,
			_ => ""
		};
	}
}