
namespace Saveable;

internal static class SlotManager
{
	// TODO: method to check if save files exist

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