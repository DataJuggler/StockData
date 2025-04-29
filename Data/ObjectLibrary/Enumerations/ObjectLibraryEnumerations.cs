
namespace ObjectLibrary.Enumerations
{

    #region enum StreakTypeEnum : int
    /// <summary>
    /// This is the type of Streak a Stock is having (increasing or decreasing)
    /// </summary>
    public enum StreakTypeEnum : int
    {
        PriceDecreasing = -1,
        NotSet = 0,
        PriceIncreasing = 1
    }
    #endregion

    #region enum ContinueTypeEnum : int
    /// <summary>
    /// This enum is used to determine if a Stock is still continueing a streak, if it stayed the same
    /// or if it started a new streak.
    /// </summary>
    public enum ContinueTypeEnum : int
    {
        ContinueStreakDeclining = -2,
        NewStreakDeclining = -1,        
        Even = 0,
        NewStreakAdvancing = 1,
        ContinueStreakAdvancing = 2
    }
    #endregion

}