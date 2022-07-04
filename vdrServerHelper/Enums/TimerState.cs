namespace vdrServerHelper.Enums
{
    public enum TimerState
    {
        Inactive,
        ActiveWaitForStart,
        RecordImmediately,
        UsingVPS = 4,
        Active = 8
    }
}
