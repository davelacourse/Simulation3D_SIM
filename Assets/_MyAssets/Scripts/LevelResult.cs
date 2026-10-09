public readonly struct LevelResult
{
    public int LevelIndex { get; }
    public float Duration { get; }
    public int Penalty { get; }

    public LevelResult(int p_levelIndex, float p_duration, int p_penalty)
    {
        LevelIndex = p_levelIndex;
        Duration = p_duration;
        Penalty = p_penalty;
    }
}