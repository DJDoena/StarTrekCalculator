Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Friend Class WarpForm
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

    Friend WithEvents lblTage As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbWarp As System.Windows.Forms.TextBox
    Friend WithEvents lblWarp As System.Windows.Forms.Label
    Friend WithEvents lblC As System.Windows.Forms.Label
    Friend WithEvents tbC As System.Windows.Forms.TextBox
    Friend WithEvents lblStrecke As System.Windows.Forms.Label
    Friend WithEvents tbStrecke As System.Windows.Forms.TextBox
    Friend WithEvents lblJahre As System.Windows.Forms.Label
    Friend WithEvents tbJahre As System.Windows.Forms.TextBox
    Friend WithEvents tbTage As System.Windows.Forms.TextBox
    Friend WithEvents lblStunden As System.Windows.Forms.Label
    Friend WithEvents tbStunden As System.Windows.Forms.TextBox
    Friend WithEvents lblMinuten As System.Windows.Forms.Label
    Friend WithEvents tbMinuten As System.Windows.Forms.TextBox
    Friend WithEvents lblSekunden As System.Windows.Forms.Label
    Friend WithEvents tbSekunden As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Close As System.Windows.Forms.Button
    Friend WithEvents Button_WarpNachC As System.Windows.Forms.Button
    Friend WithEvents Button_CNachWarp As System.Windows.Forms.Button
    Friend WithEvents LinkLabel_Copyright1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WarpForm))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbWarp = New System.Windows.Forms.TextBox()
        Me.lblWarp = New System.Windows.Forms.Label()
        Me.lblC = New System.Windows.Forms.Label()
        Me.tbC = New System.Windows.Forms.TextBox()
        Me.lblStrecke = New System.Windows.Forms.Label()
        Me.tbStrecke = New System.Windows.Forms.TextBox()
        Me.lblJahre = New System.Windows.Forms.Label()
        Me.tbJahre = New System.Windows.Forms.TextBox()
        Me.lblTage = New System.Windows.Forms.Label()
        Me.tbTage = New System.Windows.Forms.TextBox()
        Me.lblStunden = New System.Windows.Forms.Label()
        Me.tbStunden = New System.Windows.Forms.TextBox()
        Me.lblMinuten = New System.Windows.Forms.Label()
        Me.tbMinuten = New System.Windows.Forms.TextBox()
        Me.lblSekunden = New System.Windows.Forms.Label()
        Me.tbSekunden = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button_Close = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_WarpNachC = New System.Windows.Forms.Button()
        Me.Button_CNachWarp = New System.Windows.Forms.Button()
        Me.LinkLabel_Copyright1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.ToolTip.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        '
        'tbWarp
        '
        resources.ApplyResources(Me.tbWarp, "tbWarp")
        Me.tbWarp.Name = "tbWarp"
        Me.ToolTip.SetToolTip(Me.tbWarp, resources.GetString("tbWarp.ToolTip"))
        '
        'lblWarp
        '
        resources.ApplyResources(Me.lblWarp, "lblWarp")
        Me.lblWarp.BackColor = System.Drawing.Color.Transparent
        Me.lblWarp.Name = "lblWarp"
        Me.ToolTip.SetToolTip(Me.lblWarp, resources.GetString("lblWarp.ToolTip"))
        '
        'lblC
        '
        resources.ApplyResources(Me.lblC, "lblC")
        Me.lblC.BackColor = System.Drawing.Color.Transparent
        Me.lblC.Name = "lblC"
        Me.ToolTip.SetToolTip(Me.lblC, resources.GetString("lblC.ToolTip"))
        '
        'tbC
        '
        resources.ApplyResources(Me.tbC, "tbC")
        Me.tbC.Name = "tbC"
        Me.ToolTip.SetToolTip(Me.tbC, resources.GetString("tbC.ToolTip"))
        '
        'lblStrecke
        '
        resources.ApplyResources(Me.lblStrecke, "lblStrecke")
        Me.lblStrecke.BackColor = System.Drawing.Color.Transparent
        Me.lblStrecke.Name = "lblStrecke"
        Me.ToolTip.SetToolTip(Me.lblStrecke, resources.GetString("lblStrecke.ToolTip"))
        '
        'tbStrecke
        '
        resources.ApplyResources(Me.tbStrecke, "tbStrecke")
        Me.tbStrecke.Name = "tbStrecke"
        Me.ToolTip.SetToolTip(Me.tbStrecke, resources.GetString("tbStrecke.ToolTip"))
        '
        'lblJahre
        '
        resources.ApplyResources(Me.lblJahre, "lblJahre")
        Me.lblJahre.BackColor = System.Drawing.Color.Transparent
        Me.lblJahre.Name = "lblJahre"
        Me.ToolTip.SetToolTip(Me.lblJahre, resources.GetString("lblJahre.ToolTip"))
        '
        'tbJahre
        '
        resources.ApplyResources(Me.tbJahre, "tbJahre")
        Me.tbJahre.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbJahre.Name = "tbJahre"
        Me.tbJahre.ReadOnly = True
        Me.ToolTip.SetToolTip(Me.tbJahre, resources.GetString("tbJahre.ToolTip"))
        '
        'lblTage
        '
        resources.ApplyResources(Me.lblTage, "lblTage")
        Me.lblTage.BackColor = System.Drawing.Color.Transparent
        Me.lblTage.Name = "lblTage"
        Me.ToolTip.SetToolTip(Me.lblTage, resources.GetString("lblTage.ToolTip"))
        '
        'tbTage
        '
        resources.ApplyResources(Me.tbTage, "tbTage")
        Me.tbTage.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbTage.Name = "tbTage"
        Me.tbTage.ReadOnly = True
        Me.ToolTip.SetToolTip(Me.tbTage, resources.GetString("tbTage.ToolTip"))
        '
        'lblStunden
        '
        resources.ApplyResources(Me.lblStunden, "lblStunden")
        Me.lblStunden.BackColor = System.Drawing.Color.Transparent
        Me.lblStunden.Name = "lblStunden"
        Me.ToolTip.SetToolTip(Me.lblStunden, resources.GetString("lblStunden.ToolTip"))
        '
        'tbStunden
        '
        resources.ApplyResources(Me.tbStunden, "tbStunden")
        Me.tbStunden.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbStunden.Name = "tbStunden"
        Me.tbStunden.ReadOnly = True
        Me.ToolTip.SetToolTip(Me.tbStunden, resources.GetString("tbStunden.ToolTip"))
        '
        'lblMinuten
        '
        resources.ApplyResources(Me.lblMinuten, "lblMinuten")
        Me.lblMinuten.BackColor = System.Drawing.Color.Transparent
        Me.lblMinuten.Name = "lblMinuten"
        Me.ToolTip.SetToolTip(Me.lblMinuten, resources.GetString("lblMinuten.ToolTip"))
        '
        'tbMinuten
        '
        resources.ApplyResources(Me.tbMinuten, "tbMinuten")
        Me.tbMinuten.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbMinuten.Name = "tbMinuten"
        Me.tbMinuten.ReadOnly = True
        Me.ToolTip.SetToolTip(Me.tbMinuten, resources.GetString("tbMinuten.ToolTip"))
        '
        'lblSekunden
        '
        resources.ApplyResources(Me.lblSekunden, "lblSekunden")
        Me.lblSekunden.BackColor = System.Drawing.Color.Transparent
        Me.lblSekunden.Name = "lblSekunden"
        Me.ToolTip.SetToolTip(Me.lblSekunden, resources.GetString("lblSekunden.ToolTip"))
        '
        'tbSekunden
        '
        resources.ApplyResources(Me.tbSekunden, "tbSekunden")
        Me.tbSekunden.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.tbSekunden.Name = "tbSekunden"
        Me.tbSekunden.ReadOnly = True
        Me.ToolTip.SetToolTip(Me.tbSekunden, resources.GetString("tbSekunden.ToolTip"))
        '
        'Button_Close
        '
        resources.ApplyResources(Me.Button_Close, "Button_Close")
        Me.Button_Close.Name = "Button_Close"
        Me.ToolTip.SetToolTip(Me.Button_Close, resources.GetString("Button_Close.ToolTip"))
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblStrecke)
        Me.GroupBox1.Controls.Add(Me.tbStrecke)
        Me.GroupBox1.Controls.Add(Me.lblJahre)
        Me.GroupBox1.Controls.Add(Me.tbJahre)
        Me.GroupBox1.Controls.Add(Me.lblTage)
        Me.GroupBox1.Controls.Add(Me.tbTage)
        Me.GroupBox1.Controls.Add(Me.lblStunden)
        Me.GroupBox1.Controls.Add(Me.tbStunden)
        Me.GroupBox1.Controls.Add(Me.tbWarp)
        Me.GroupBox1.Controls.Add(Me.lblMinuten)
        Me.GroupBox1.Controls.Add(Me.tbMinuten)
        Me.GroupBox1.Controls.Add(Me.lblSekunden)
        Me.GroupBox1.Controls.Add(Me.tbSekunden)
        Me.GroupBox1.Controls.Add(Me.lblWarp)
        Me.GroupBox1.Controls.Add(Me.lblC)
        Me.GroupBox1.Controls.Add(Me.tbC)
        Me.GroupBox1.Controls.Add(Me.Button_WarpNachC)
        Me.GroupBox1.Controls.Add(Me.Button_CNachWarp)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.ToolTip.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'Button_WarpNachC
        '
        resources.ApplyResources(Me.Button_WarpNachC, "Button_WarpNachC")
        Me.Button_WarpNachC.Name = "Button_WarpNachC"
        Me.ToolTip.SetToolTip(Me.Button_WarpNachC, resources.GetString("Button_WarpNachC.ToolTip"))
        '
        'Button_CNachWarp
        '
        resources.ApplyResources(Me.Button_CNachWarp, "Button_CNachWarp")
        Me.Button_CNachWarp.Name = "Button_CNachWarp"
        Me.ToolTip.SetToolTip(Me.Button_CNachWarp, resources.GetString("Button_CNachWarp.ToolTip"))
        '
        'LinkLabel_Copyright1
        '
        resources.ApplyResources(Me.LinkLabel_Copyright1, "LinkLabel_Copyright1")
        Me.LinkLabel_Copyright1.ActiveLinkColor = System.Drawing.Color.Red
        Me.LinkLabel_Copyright1.BackColor = System.Drawing.SystemColors.Control
        Me.LinkLabel_Copyright1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel_Copyright1.LinkColor = System.Drawing.Color.Black
        Me.LinkLabel_Copyright1.Name = "LinkLabel_Copyright1"
        Me.LinkLabel_Copyright1.TabStop = True
        Me.ToolTip.SetToolTip(Me.LinkLabel_Copyright1, resources.GetString("LinkLabel_Copyright1.ToolTip"))
        Me.LinkLabel_Copyright1.UseCompatibleTextRendering = True
        '
        'WarpForm
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.LinkLabel_Copyright1)
        Me.Controls.Add(Me.Button_Close)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WarpForm"
        Me.ShowInTaskbar = False
        Me.ToolTip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CWarpForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip.SetToolTip(lblStrecke, My.Resources.Texts.DistanceTooltip)
        ToolTip.SetToolTip(tbStrecke, My.Resources.Texts.DistanceTooltip)

    End Sub
    Private Sub CalcTime()
        Dim myLightspeed As Double
        Dim myTravelTime As TravelTime
        Dim myDistance As Integer

        Try
            If (tbStrecke.Text <> String.Empty) Then
                If (Regex.IsMatch(tbStrecke.Text, "^[0-9]{1,6}$")) Then
                    myLightspeed = CDbl(tbC.Text)
                    myDistance = CInt(tbStrecke.Text)
                    myTravelTime = WarpCalc.LightspeedToTime(myLightspeed, myDistance)
                    tbJahre.Text = CStr(myTravelTime.Years)
                    tbTage.Text = CStr(myTravelTime.Days)
                    tbStunden.Text = CStr(myTravelTime.Hours)
                    tbMinuten.Text = CStr(myTravelTime.Minutes)
                    tbSekunden.Text = CStr(myTravelTime.Seconds)
                Else
                    MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.Distance, 1, 999999), MsgBoxStyle.Exclamation)
                End If
            End If
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

#Region " Buttons / Calculator "

    Private Sub Button_WarpNachC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_WarpNachC.Click
        Dim myWarpFactor As Double

        Try
            If (Regex.IsMatch(tbWarp.Text, "^[1-9](\,[0-9]{1,6}){0,1}$")) Then
                myWarpFactor = CDbl(tbWarp.Text)

                If ((myWarpFactor >= WarpCalc.MinimumWarp) AndAlso (myWarpFactor <= WarpCalc.MaximumWarp)) Then
                    tbC.Text = CStr(WarpCalc.WarpToLightspeed(myWarpFactor))
                    CalcTime()
                Else
                    MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.Warp, WarpCalc.MinimumWarp, WarpCalc.MaximumWarp), MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.Warp, WarpCalc.MinimumWarp, WarpCalc.MaximumWarp), MsgBoxStyle.Exclamation)
            End If
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button_CNachWarp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_CNachWarp.Click
        Dim myCFactor As Double

        Try
            If (Regex.IsMatch(tbC.Text, "^[0-9]{1,6}(\,[0-9]{1,6}){0,1}$")) Then
                myCFactor = CDbl(tbC.Text)

                If ((myCFactor >= WarpCalc.MinimumLightspeed) AndAlso (myCFactor <= WarpCalc.MaximumLightspeed)) Then
                    tbWarp.Text = CStr(WarpCalc.LightspeedToWarp(myCFactor))
                    CalcTime()
                Else
                    MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.c, WarpCalc.MinimumLightspeed, WarpCalc.MaximumLightspeed), MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox(String.Format(My.Resources.Texts.ValueIsInvalid, My.Resources.Texts.c, WarpCalc.MinimumLightspeed, WarpCalc.MaximumLightspeed), MsgBoxStyle.Exclamation)
            End If
        Catch myEx As Exception
            MsgBox(My.Resources.Texts.UnexpectedError, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region " Buttons "

    Private Sub LinkLabel_Copyright1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_Copyright1.LinkClicked
        System.Diagnostics.Process.Start("mailto:theGuy@djdoena.net?subject=StarTrek Calculator" & Me.ProductVersion)
    End Sub
    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

#End Region

End Class