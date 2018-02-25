Friend Class WarpCalc
    Private Const MINWARP As Double = 1
    Private Const MAXWARP As Double = 9.999999
    Private Const MINLIGHTSPEED As Double = 1
    Private Const MAXLIGHTSPEED As Double = 500000
    Private Const MAXDISTANCE As Double = 1000000000000000000

    Public Shared ReadOnly Property MinimumWarp() As Double
        Get
            Return MINWARP
        End Get
    End Property

    Public Shared ReadOnly Property MaximumWarp() As Double
        Get
            Return MAXWARP
        End Get
    End Property

    Public Shared ReadOnly Property MinimumLightspeed() As Double
        Get
            Return MINLIGHTSPEED
        End Get
    End Property

    Public Shared ReadOnly Property MaximumLightspeed() As Double
        Get
            Return MAXLIGHTSPEED
        End Get
    End Property

    Public Shared ReadOnly Property MaximumDistance() As Double
        Get
            Return MAXDISTANCE
        End Get
    End Property

    Friend Shared Function WarpToLightspeed(ByVal pWarp As Double) As Double
        Return WarpToLightspeed(pWarp, False)
    End Function

    Private Shared Function WarpToLightspeed(ByVal pWarp As Double, ByVal bInternal As Boolean) As Double
        If (bInternal) OrElse ((pWarp >= MINWARP) AndAlso (pWarp <= MAXWARP)) Then
            Dim ln10 As Double = Math.Log(10)

            Dim inverseWarp As Double = 10 - pWarp

            Dim a As Double = 0.20467 * Math.Exp(-0.0058 * ((Math.Log(10000 * inverseWarp) / ln10) ^ 5))

            Dim b As Double = 1 + (2 * Math.Cos(10 * Math.PI * Math.Log(8 / (10 * inverseWarp)) / ln10) - 1) / 3 * Math.Exp(-49.369 * ((Math.Log(8 / (10 * inverseWarp)) / ln10) ^ 4))

            Dim c As Double = 1 + 1.88269 / Math.PI * (Math.PI / 2 - Math.Atan((10 ^ pWarp) * Math.Log(2000 * inverseWarp) / ln10))

            Dim d As Double = pWarp ^ (10 / 3 * (1 + (a * b * c)))

            Return Math.Round(d, 6)
        Else
            Throw New CalculationException("Warpfactor smaller than " & MINWARP & " or bigger than" & MAXWARP)
        End If
    End Function

    Friend Shared Function LightspeedToWarp(ByVal pLightspeed As Double) As Double
        If (pLightspeed >= MINLIGHTSPEED) AndAlso (pLightspeed <= MAXLIGHTSPEED) Then

            Dim minWarp As Double = 1

            Dim maxWarp As Double = 10

            If pLightspeed >= 502440 Then
                minWarp = 9.999999
            ElseIf pLightspeed >= 204851 Then
                minWarp = 9.99999
            ElseIf pLightspeed >= 199516 Then
                minWarp = 9.9999
                maxWarp = 9.999999
            ElseIf pLightspeed >= 10268 Then
                minWarp = 9.999
                maxWarp = 9.99999
            ElseIf pLightspeed >= 7913 Then
                minWarp = 9.99
                maxWarp = 9.9999
            ElseIf pLightspeed >= 3053 Then
                minWarp = 9.9
                maxWarp = 9.999
            ElseIf pLightspeed >= 1517 Then
                minWarp = 9
                maxWarp = 9.99
            ElseIf pLightspeed >= 1025 Then
                minWarp = 8
                maxWarp = 9.9
            ElseIf pLightspeed >= 1025 Then
                minWarp = 7
                maxWarp = 9
            ElseIf pLightspeed >= 657 Then
                minWarp = 6
                maxWarp = 8
            ElseIf pLightspeed >= 393 Then
                minWarp = 5
                maxWarp = 7
            ElseIf pLightspeed >= 102 Then
                minWarp = 4
                maxWarp = 6
            ElseIf pLightspeed >= 39 Then
                minWarp = 3
                maxWarp = 5
            ElseIf pLightspeed >= 11 Then
                minWarp = 2
                maxWarp = 4
            ElseIf pLightspeed > 1 Then
                maxWarp = 3
            Else
                maxWarp = 1
            End If

            Dim warp As Double = 1

            Debug.WriteLine("Starting Newton")

            For counter As Integer = 1 To 100
                Debug.WriteLine("Iteration: " & counter)
                Debug.WriteLine("Min / Max Warp: " & minWarp & " / " & maxWarp)

                warp = (minWarp + maxWarp) / 2

                Debug.WriteLine("Warp: " & warp)

                Dim calculatedLightspeed As Double = WarpToLightspeed(warp, True)

                Debug.WriteLine("Light speed: " & calculatedLightspeed)

                If Math.Round(pLightspeed, 6) = calculatedLightspeed Then
                    Exit For
                ElseIf (calculatedLightspeed < pLightspeed) Then
                    minWarp = warp
                ElseIf (calculatedLightspeed > pLightspeed) Then
                    maxWarp = warp
                End If
            Next counter

            Return Math.Round(warp, 6)
        Else
            Throw New CalculationException("Lightspeed is smaller than " & MINLIGHTSPEED & " or bigger than " & MAXLIGHTSPEED)
        End If
    End Function

    Friend Shared Function LightspeedToTime(ByVal pLightspeed As Double, ByVal pDistance As Double) As TravelTime
        Dim myTemp As Double
        Dim myTravelTime As New TravelTime

        If (pLightspeed >= MINLIGHTSPEED) Then
            If (pDistance > 0) Then
                myTravelTime.Years = Convert.ToUInt64(Fix(pDistance / pLightspeed))
                myTemp = (pDistance / pLightspeed) - myTravelTime.Years
                myTravelTime.Days = Convert.ToUInt16(Int(myTemp * 365.2425))
                myTemp = (myTemp * 365.2425) - myTravelTime.Days
                myTravelTime.Hours = Convert.ToUInt16(Int(myTemp * 24))
                myTemp = (myTemp * 24) - myTravelTime.Hours
                myTravelTime.Minutes = Convert.ToUInt16(Int(myTemp * 60))
                myTemp = (myTemp * 60) - myTravelTime.Minutes
                myTravelTime.Seconds = Convert.ToUInt16(Int(myTemp * 60))
                Return myTravelTime
            Else
                Throw New CalculationException("Distance is lower than " & MINLIGHTSPEED)
            End If
        Else
            Throw New CalculationException("Lightspeed is lower than 0.")
        End If
    End Function

End Class