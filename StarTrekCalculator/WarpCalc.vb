Friend Class WarpCalc
    Private Const MINWARP As Double = 1
    Private Const MAXWARP As Double = 9.999999
    Private Const MINLIGHTSPEED As Double = 1
    Private Const MAXLIGHTSPEED As Double = 500000

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


    Friend Shared Function WarpToLightspeed(ByVal pWarp As Double) As Double
        Return WarpToLightspeed(pWarp, False)
    End Function

    Private Shared Function WarpToLightspeed(ByVal pWarp As Double, ByVal bInternal As Boolean) As Double
        Dim myLn10 As Double = Math.Log(10)

        Dim a As Double
        Dim b As Double
        Dim c As Double

        If ((bInternal) OrElse (pWarp >= MINWARP) AndAlso (pWarp <= MAXWARP)) Then
            a = 0.20467 * System.Math.Exp(-0.0058 * ((System.Math.Log(10000 * (10 - pWarp)) / myLn10) ^ 5))
            b = 1 + (2 * System.Math.Cos(10 * System.Math.PI * System.Math.Log(8 / (10 * (10 - pWarp))) / myLn10) - 1) / 3 * System.Math.Exp(-49.369 * ((System.Math.Log(8 / (10 * (10 - pWarp))) / myLn10) ^ 4))
            c = 1 + 1.88269 / System.Math.PI * (System.Math.PI / 2 - System.Math.Atan((10 ^ pWarp) * System.Math.Log(2000 * (10 - pWarp)) / myLn10))
            Return Math.Round((pWarp ^ (10 / 3 * (1 + (a * b * c)))), 6)
        Else
            Throw New CalculationException("Warpfactor smaller than " & MINWARP & " or bigger than" & MAXWARP)
        End If
    End Function

    Friend Shared Function LightspeedToWarp(ByRef pLightspeed As Double) As Double
        Dim h As Double
        Dim wmin As Double
        Dim wmax As Double
        Dim dLightspeed As Double
        Dim w As Double
        Dim w0 As Double
        Dim ws As Double
        Dim cnt As Double

        If (pLightspeed >= MINLIGHTSPEED) AndAlso (pLightspeed <= MAXLIGHTSPEED) Then
            h = 0.0001
            wmin = 0
            wmax = 10
            If (pLightspeed > 1516) Then
                w = 10 - ((304.329 / (pLightspeed - 1516)) ^ 1.4218)
                If (w + h > 10) Then
                    h = (10 - w) / 2
                End If
                wmin = 9
            Else
                w = pLightspeed ^ 0.3
            End If
            dLightspeed = 1
            While Not (cnt < 20 And dLightspeed > 0.00001)
                w0 = w
                dLightspeed = (WarpToLightspeed(w + h, True) - WarpToLightspeed(w - h, True)) / 2 / h
                w = w - (WarpToLightspeed(w, True) - pLightspeed) / dLightspeed
                If (w >= 10) Then
                    w = (wmin + wmax) / 2
                End If
                If (w + h >= 10) Then
                    h = (10 - w) / 2
                End If
                If (w - h < 0) Then
                    h = w / 2
                End If
                ws = WarpToLightspeed(w, True)
                If (ws < pLightspeed) Then
                    If (w > wmin) Then
                        wmin = w
                    End If
                End If
                If (ws > pLightspeed) Then
                    If (w < wmax) Then
                        wmax = w
                    End If
                End If
                dLightspeed = System.Math.Abs(ws - pLightspeed)
                cnt = cnt + 1
            End While
            If (dLightspeed > 0.0001) Then
                For cnt = 1 To 100
                    w = (wmin + wmax) / 2
                    ws = WarpToLightspeed(w, True)
                    If (ws < pLightspeed And w > wmin) Then
                        wmin = w
                    End If
                    If (ws > pLightspeed And w < wmax) Then
                        wmax = w
                    End If
                Next cnt
            End If
            Return Math.Round(w, 6)
        Else
            Throw New CalculationException("Lightspeed is smaller than " & MINLIGHTSPEED & " or bigger than " & MAXLIGHTSPEED)
        End If
    End Function

    Friend Shared Function LightspeedToTime(ByVal pLightspeed As Double, ByVal pDistance As Integer) As TravelTime
        Dim myTemp As Double
        Dim myTravelTime As New TravelTime

        If (pLightspeed >= MINLIGHTSPEED) Then
            If (pDistance > 0) Then
                myTravelTime.Years = CInt(Fix(CDbl(pDistance) / pLightspeed))
                myTemp = (pDistance / pLightspeed) - myTravelTime.Years
                myTravelTime.Days = CShort(Int(myTemp * 365.2425))
                myTemp = (myTemp * 365.2425) - myTravelTime.Days
                myTravelTime.Hours = CShort(Int(myTemp * 24))
                myTemp = (myTemp * 24) - myTravelTime.Hours
                myTravelTime.Minutes = CShort(Int(myTemp * 60))
                myTemp = (myTemp * 60) - myTravelTime.Minutes
                myTravelTime.Seconds = CShort(Int(myTemp * 60))
                Return myTravelTime
            Else
                Throw New CalculationException("Distance is lower than " & MINLIGHTSPEED)
            End If
        Else
            Throw New CalculationException("Lightspeed is lower than 0.")
        End If
    End Function

    Friend Shared Function WarpToTime(ByVal pWarp As Double, ByVal pDistance As Integer) As TravelTime
        Return LightspeedToTime(WarpToLightspeed(pWarp), pDistance)
    End Function

End Class