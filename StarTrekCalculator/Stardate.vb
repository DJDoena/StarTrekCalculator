''' <summary>
''' Gives access to the Stardate Form and calculation methods.
''' </summary>
Public Class Stardate
    Implements IDisposable

    Private StarDateForm As StardateForm

    Public Property Left() As Integer
        Get
            Return StarDateForm.Left
        End Get
        Set(ByVal Value As Integer)
            StarDateForm.Left = Value
        End Set
    End Property

    Public Property Top() As Integer
        Get
            Return StarDateForm.Top
        End Get
        Set(ByVal Value As Integer)
            StarDateForm.Top = Value
        End Set
    End Property

    Public Sub New()
        StarDateForm = New StardateForm
    End Sub

    Public Sub Show()
        StarDateForm.Show()
    End Sub

    Public Sub ShowDialog()
        StarDateForm.ShowDialog()
    End Sub

    Public Sub Close()
        StarDateForm.Close()
    End Sub

    Public Shared Function StarDateToNormalDate(ByVal pInStarDate As Double) As Date
        Return StardateCalc.StardateToNormaldate(pInStarDate)
    End Function

    Public Shared Function NormalDateToStarDate(ByVal pInDate As Date) As Double
        Return StardateCalc.NormaldateToStardate(pInDate)
    End Function

    Public Shared ReadOnly Property MinimumStarDate() As Double
        Get
            Return StardateCalc.MinimumStarDate
        End Get
    End Property

    Public Shared ReadOnly Property MaximumStarDate() As Double
        Get
            Return StardateCalc.MaximumStarDate
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        StarDateForm.Dispose()
    End Sub
End Class