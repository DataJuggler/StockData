

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum StreakTypeEnum : int
    /// <summary>
    /// This enum is only here so that the Enumerations reference compiles.
    /// You can remove this but if you do you also need to remove the reference
    /// in DataManager for this object.
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
