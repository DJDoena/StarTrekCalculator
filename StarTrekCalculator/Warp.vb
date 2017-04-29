''' <summary>
''' Gives access to the Warp Form and calculation methods.
''' </summary>
Public Class Warp
    Implements IDisposable

    Private WarpForm As WarpForm

    Public Property Left() As Integer
        Get
            Return WarpForm.Left
        End Get
        Set(ByVal Value As Integer)
            WarpForm.Left = Value
        End Set
    End Property
    Public Property Top() As Integer
        Get
            Return WarpForm.Top
        End Get
        Set(ByVal Value As Integer)
            WarpForm.Top = Value
        End Set
    End Property
    Public Sub New()
        WarpForm = New WarpForm
    End Sub
    Public Sub Show()
        WarpForm.Show()
    End Sub
    Public Sub ShowDialog()
        WarpForm.ShowDialog()
    End Sub
    Public Sub Close()
        WarpForm.Close()
    End Sub
    Public Shared Function WarpToLightspeed(ByVal pWarp As Double) As Double
        Return WarpCalc.WarpToLightspeed(pWarp)
    End Function
    Public Shared Function LightspeedToWarp(ByRef pLightspeed As Double) As Double
        Return WarpCalc.LightspeedToWarp(pLightspeed)
    End Function
    Public Shared Function LightspeedToTime(ByVal pLightspeed As Double, ByVal pDistance As Integer) As TravelTime
        Return WarpCalc.LightspeedToTime(pLightspeed, pDistance)
    End Function
    Public Shared Function WarpToTime(ByVal pWarp As Double, ByVal pDistance As Integer) As TravelTime
        Return WarpCalc.WarpToTime(pWarp, pDistance)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        WarpForm.Dispose()
    End Sub
End Class