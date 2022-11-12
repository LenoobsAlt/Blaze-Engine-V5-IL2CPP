namespace IL2Photon.Realtime
{
	public enum EventCaching : byte
	{
		DoNotCache,
		MergeCache,
		ReplaceCache,
		RemoveCache,
		AddToRoomCache,
		AddToRoomCacheGlobal,
		RemoveFromRoomCache,
		RemoveFromRoomCacheForActorsLeft,
		SliceIncreaseIndex = 10,
		SliceSetIndex,
		SlicePurgeIndex,
		SlicePurgeUpToIndex
	}
}