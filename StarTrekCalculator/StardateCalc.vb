Friend Class StardateCalc
    Private Const MINSTARDATE As Double = -2322000
    Private Const MAXSTARDATE As Double = 7676999.999999

    Public Shared ReadOnly Property MinimumStarDate() As Double
        Get
            Return MINSTARDATE
        End Get
    End Property

    Public Shared ReadOnly Property MaximumStarDate() As Double
        Get
            Return MAXSTARDATE
        End Get
    End Property

    Friend Shared Function StardateToNormaldate(ByVal pStardate As Double) As Date
        Dim myTemp As Double
        Dim myYear As Short
        Dim myDate As New Date(1, 1, 1, 0, 0, 0, 0)
        Dim myDays As Short

        If ((pStardate < MINSTARDATE) OrElse (pStardate > MAXSTARDATE)) Then
            Throw New CalculationException("Stardate is smaller than " & MINSTARDATE & " or bigger than " & MAXSTARDATE)
        End If
        pStardate = CDbl(Math.Round(pStardate, 6))
        myTemp = pStardate / 1000
        myYear = CShort(Int(myTemp) + 2323)
        myTemp = myTemp - Int(myTemp)
        myDays = DaysOfYear(myYear)
        myTemp = myTemp * myDays
        myDate = myDate.AddYears(myYear - 1)
        myDate = myDate.AddDays(myTemp)
        Return myDate
    End Function

    Private Shared Function DaysOfYear(ByVal Year As Short) As Short
        If Date.IsLeapYear(Year) Then
            Return 366
        Else
            Return 365
        End If
    End Function

    Friend Shared Function NormaldateToStardate(ByVal pDate As Date) As Double
        Dim myDayPart As Double
        Dim mySDLowerPart As Double
        Dim mySDUpperPart As Double

        myDayPart = (pDate.Second + pDate.Minute * 60 + pDate.Hour * 3600) / 86400
        mySDLowerPart = (pDate.DayOfYear - 1 + myDayPart) / DaysOfYear(CShort(pDate.Year)) * 1000
        mySDUpperPart = (pDate.Year - 2323) * 1000
        Return Math.Round((mySDUpperPart + mySDLowerPart), 6)
    End Function

End Class