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

    Public Shared Function LightspeedToWarp(ByVal pLightspeed As Double) As Double
        Return WarpCalc.LightspeedToWarp(pLightspeed)
    End Function

    <CLSCompliant(False)>
    Public Shared Function LightspeedToTime(ByVal pLightspeed As Double, ByVal pDistance As Double) As TravelTime
        Return WarpCalc.LightspeedToTime(pLightspeed, pDistance)
    End Function

    Public Shared ReadOnly Property MinimumWarp() As Double
        Get
            Return WarpCalc.MinimumWarp
        End Get
    End Property

    Public Shared ReadOnly Property MaximumWarp() As Double
        Get
            Return WarpCalc.MaximumWarp
        End Get
    End Property

    Public Shared ReadOnly Property MinimumLightspeed() As Double
        Get
            Return WarpCalc.MinimumLightspeed
        End Get
    End Property

    Public Shared ReadOnly Property MaximumLightspeed() As Double
        Get
            Return WarpCalc.MaximumLightspeed
        End Get
    End Property

    Public Shared ReadOnly Property MaximumDistance() As Double
        Get
            Return WarpCalc.MaximumDistance
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        WarpForm.Dispose()
    End Sub
End Class