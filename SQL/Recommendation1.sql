With CTE (Score, StockID, StockName, Symbol, LastClose, CloseScore, VolumeScore, Streak, LastPercentChange, StreakPercentChange, Industry, IndustryScore, IndustryStreak, Sector, SectorScore, SectorStreak) As
(
	Select Round((1 + ((s.CloseScore - 50) * s.Streak) + ((s.IndustryScore - 50) * s.IndustryStreak) + ((s.SectorScore - 50) * s.SectorStreak) + (s.VolumeScore * .1) + s.LastPercentChange + s.StreakPercentChange), 2) As Score, StockId, Name, Symbol, LastClose, CloseScore, VolumeScore, Streak, s.LastPercentChange, s.StreakPercentChange, Industry, IndustryScore, IndustryStreak, Sector, SectorScore, SectorStreak From StockStreakView s
	Where ReverseSplit = 0 And Streak > 0
)

Select Top 100 * From CTE order bY Score Desc












