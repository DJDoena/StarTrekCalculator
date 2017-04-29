Imports System.Text.RegularExpressions

Friend Class StardateForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    Friend WithEvents LBLSeconds As System.Windows.Forms.Label
    Friend WithEvents TBSeconds As System.Windows.Forms.TextBox
    Friend WithEvents KBLMinutes As System.Windows.Forms.Label
    Friend WithEvents TBMinutes As System.Windows.Forms.TextBox
    Friend WithEvents LBLHours As System.Windows.Forms.Label
    Friend WithEvents TBHours As System.Windows.Forms.TextBox
    Friend WithEvents LBLDays As System.Windows.Forms.Label
    Friend WithEvents TBDays As System.Windows.Forms.TextBox
    Friend WithEvents LBLYears As System.Windows.Forms.Label
    Friend WithEvents TBYears As System.Windows.Forms.TextBox
    Friend WithEvents LBLMonths As System.Windows.Forms.Label
    Friend WithEvents TBMonths As System.Windows.Forms.TextBox
    Friend WithEvents LBLStardate As System.Windows.Forms.Label
    Friend WithEvents TBStardate As System.Windows.Forms.TextBox
    Friend WithEvents TTClose As System.Windows.Forms.ToolTip
    Friend WithEvents BTClose As System.Windows.Forms.Button
    Friend WithEvents BTSystemTime As System.Windows.Forms.Button
    Friend WithEvents BTStardateToDate As System.Windows.Forms.Button
    Friend WithEvents BTDateToStardate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel_Copyright1 As System.Windows.Forms.LinkLabel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StardateForm))
        Me.LBLSeconds = New System.Windows.Forms.Label()
        Me.TBSeconds = New System.Windows.Forms.TextBox()
        Me.KBLMinutes = New System.Windows.Forms.Label()
        Me.TBMinutes = New System.Windows.Forms.TextBox()
        Me.LBLHours = New System.Windows.Forms.Label()
        Me.TBHours = New System.Windows.Forms.TextBox()
        Me.LBLDays = New System.Windows.Forms.Label()
        Me.TBDays = New System.Windows.Forms.TextBox()
        Me.LBLYears = New System.Windows.Forms.Label()
        Me.TBYears = New System.Windows.Forms.TextBox()
        Me.LBLMonths = New System.Windows.Forms.Label()
        Me.TBMonths = New System.Windows.Forms.TextBox()
        Me.LBLStardate = New System.Windows.Forms.Label()
        Me.TBStardate = New System.Windows.Forms.TextBox()
        Me.TTClose = New System.Windows.Forms.ToolTip(Me.components)
        Me.BTClose = New System.Windows.Forms.Button()
        Me.BTStardateToDate = New System.Windows.Forms.Button()
        Me.BTSystemTime = New System.Windows.Forms.Button()
        Me.BTDateToStardate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel_Copyright1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LBLSeconds
        '
        Me.LBLSeconds.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLSeconds, "LBLSeconds")
        Me.LBLSeconds.Name = "LBLSeconds"
        '
        'TBSeconds
        '
        resources.ApplyResources(Me.TBSeconds, "TBSeconds")
        Me.TBSeconds.Name = "TBSeconds"
        '
        'KBLMinutes
        '
        Me.KBLMinutes.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.KBLMinutes, "KBLMinutes")
        Me.KBLMinutes.Name = "KBLMinutes"
        '
        'TBMinutes
        '
        resources.ApplyResources(Me.TBMinutes, "TBMinutes")
        Me.TBMinutes.Name = "TBMinutes"
        '
        'LBLHours
        '
        Me.LBLHours.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLHours, "LBLHours")
        Me.LBLHours.Name = "LBLHours"
        '
        'TBHours
        '
        resources.ApplyResources(Me.TBHours, "TBHours")
        Me.TBHours.Name = "TBHours"
        '
        'LBLDays
        '
        Me.LBLDays.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLDays, "LBLDays")
        Me.LBLDays.Name = "LBLDays"
        '
        'TBDays
        '
        resources.ApplyResources(Me.TBDays, "TBDays")
        Me.TBDays.Name = "TBDays"
        '
        'LBLYears
        '
        Me.LBLYears.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLYears, "LBLYears")
        Me.LBLYears.Name = "LBLYears"
        '
        'TBYears
        '
        resources.ApplyResources(Me.TBYears, "TBYears")
        Me.TBYears.Name = "TBYears"
        '
        'LBLMonths
        '
        Me.LBLMonths.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLMonths, "LBLMonths")
        Me.LBLMonths.Name = "LBLMonths"
        '
        'TBMonths
        '
        resources.ApplyResources(Me.TBMonths, "TBMonths")
        Me.TBMonths.Name = "TBMonths"
        '
        'LBLStardate
        '
        Me.LBLStardate.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.LBLStardate, "LBLStardate")
        Me.LBLStardate.Name = "LBLStardate"
        '
        'TBStardate
        '
        resources.ApplyResources(Me.TBStardate, "TBStardate")
        Me.TBStardate.Name = "TBStardate"
        '
        'BTClose
        '
        resources.ApplyResources(Me.BTClose, "BTClose")
        Me.BTClose.Name = "BTClose"
        Me.TTClose.SetToolTip(Me.BTClose, resources.GetString("BTClose.ToolTip"))
        '
        'BTStardateToDate
        '
        resources.ApplyResources(Me.BTStardateToDate, "BTStardateToDate")
        Me.BTStardateToDate.Name = "BTStardateToDate"
        '
        'BTSystemTime
        '
        resources.ApplyResources(Me.BTSystemTime, "BTSystemTime")
        Me.BTSystemTime.Name = "BTSystemTime"
        '
        'BTDateToStardate
        '
        resources.ApplyResources(Me.BTDateToStardate, "BTDateToStardate")
        Me.BTDateToStardate.Name = "BTDateToStardate"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LBLDays)
        Me.GroupBox1.Controls.Add(Me.TBDays)
        Me.GroupBox1.Controls.Add(Me.LBLYears)
        Me.GroupBox1.Controls.Add(Me.TBYears)
        Me.GroupBox1.Controls.Add(Me.LBLMonths)
        Me.GroupBox1.Controls.Add(Me.TBMonths)
        Me.GroupBox1.Controls.Add(Me.LBLStardate)
        Me.GroupBox1.Controls.Add(Me.TBStardate)
        Me.GroupBox1.Controls.Add(Me.LBLSeconds)
        Me.GroupBox1.Controls.Add(Me.TBSeconds)
        Me.GroupBox1.Controls.Add(Me.KBLMinutes)
        Me.GroupBox1.Controls.Add(Me.TBMinutes)
        Me.GroupBox1.Controls.Add(Me.LBLHours)
        Me.GroupBox1.Controls.Add(Me.TBHours)
        Me.GroupBox1.Controls.Add(Me.BTStardateToDate)
        Me.GroupBox1.Controls.Add(Me.BTSystemTime)
        Me.GroupBox1.Controls.Add(Me.BTDateToStardate)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'LinkLabel_Copyright1
        '
        Me.LinkLabel_Copyright1.ActiveLinkColor = System.Drawing.Color.Red
        Me.LinkLabel_Copyright1.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.LinkLabel_Copyright1, "LinkLabel_Copyright1")
        Me.LinkLabel_Copyright1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel_Copyright1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel_Copyright1.Name = "LinkLabel_Copyright1"
        Me.LinkLabel_Copyright1.TabStop = True
        Me.LinkLabel_Copyright1.UseCompatibleTextRendering = True
        '
        'StardateForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.LinkLabel_Copyright1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StardateForm"
        Me.ShowInTaskbar = False
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Buttons / Calculator "

    Private Sub BTSystemTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTSystemTime.Click
        Dim myDate As Date = Date.Now

        Try
            TBYears.Text = CStr(myDate.Year)
            TBMonths.Text = CStr(myDate.Month)
            TBDays.Text = CStr(myDate.Day)
            TBHours.Text = CStr(myDate.Hour)
            TBMinutes.Text = CStr(myDate.Minute)
            TBSeconds.Text = CStr(myDate.Second)
            TBStardate.Text = CStr(StardateCalc.NormaldateToStardate(myDate))
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BTStardateToDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTStardateToDate.Click
        Dim myDate As Date
        Dim myStarDate As Double

        Try
            If (Regex.IsMatch(TBStardate.Text, "^\-{0,1}[0-9]{1,6}(\,{1,1}[0-9]{1,6}){0,1}$")) Then
                myStarDate = CDbl(TBStardate.Text)
                If ((myStarDate >= StardateCalc.MinimumStarDate) AndAlso (myStarDate <= StardateCalc.MaximumStarDate)) Then
                    myDate = StardateCalc.StardateToNormaldate(myStarDate)
                    TBYears.Text = CStr(myDate.Year)
                    TBMonths.Text = CStr(myDate.Month)
                    TBDays.Text = CStr(myDate.Day)
                    TBHours.Text = CStr(myDate.Hour)
                    TBMinutes.Text = CStr(myDate.Minute)
                    TBSeconds.Text = CStr(myDate.Second)
                Else
                    MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.Stardate, StardateCalc.MinimumStarDate, StardateCalc.MaximumStarDate), MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.Stardate, StardateCalc.MinimumStarDate, StardateCalc.MaximumStarDate), MsgBoxStyle.Exclamation)
            End If
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BTDateToStardate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTDateToStardate.Click
        Dim myDate As Date
        Dim myDateString As String

        Try
            If (Not Regex.IsMatch(TBYears.Text, "^[0-9]{4}$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Year, 1, 9999), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If (Not Regex.IsMatch(TBMonths.Text, "^(([0]{0,1}[0-9])|([1][0-2]))$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Month, 1, 12), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If (Not Regex.IsMatch(TBDays.Text, "^(([0-2]{0,1}[0-9])|([3][0-1]))$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Day, 1, 31), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If (Not Regex.IsMatch(TBHours.Text, "^(([0-1]{0,1}[0-9])|([2][0-3]))$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Hour, 0, 24), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If (Not Regex.IsMatch(TBMinutes.Text, "^([0-5]{0,1}[0-9])$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Minute, 0, 59), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If (Not Regex.IsMatch(TBSeconds.Text, "^([0-5]{0,1}[0-9])$")) Then
                MsgBox(String.Format(My.Resources.Texts.DatePartIsInvalid, My.Resources.Texts.Second, 0, 59), MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            myDateString = TBDays.Text.PadLeft(2, "0"c) & "." & TBMonths.Text.PadLeft(2, "0"c) & "." & TBYears.Text & " " & TBHours.Text.PadLeft(2, "0"c) & ":" & TBMinutes.Text.PadLeft(2, "0"c) & ":" & TBSeconds.Text.PadLeft(2, "0"c)
            Try
                myDate = Date.Parse(myDateString, System.Globalization.CultureInfo.GetCultureInfo("de-DE"))
            Catch myDateEx As Exception
                MsgBox(My.Resources.Texts.DateIsInvalid, MsgBoxStyle.Exclamation)
                Exit Sub
            End Try
            If (myDate.ToString("dd.MM.yyyy HH:mm:ss") <> myDateString) Then
                MsgBox(My.Resources.Texts.DateIsInvalid, MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            TBStardate.Text = CStr(StardateCalc.NormaldateToStardate(myDate))
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region " Buttons "

    Private Sub LinkLabel_Copyright1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_Copyright1.LinkClicked
        System.Diagnostics.Process.Start("mailto:TheGuy@djdoena.net?subject=StarTrek Calculator" & Me.ProductVersion)
    End Sub
    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTClose.Click
        Me.Close()
    End Sub

#End Region

End Class