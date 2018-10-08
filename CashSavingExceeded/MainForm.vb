'-----------------------------------------------------------------------------------------------------------------------------------------------
'
'	This program is free software; you can redistribute it and/or
'	modify it under the terms of the GNU General Public License
'	as published by the Free Software Foundation; either version 2
'	of the License, or (at your option) any later version.
'
'	This program is distributed in the hope that it will be useful,
'	but WITHOUT ANY WARRANTY; without even the implied warranty of
'	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'	GNU General Public License for more details.
'
'	You should have received a copy of the GNU General Public License
'	along with this program; if not, write to the Free Software Foundation,
'	Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
'
'	Name :
'				CashSavingExceeded
'	Author :
'				▄▄▄▄▄▄▄  ▄ ▄▄ ▄▄▄▄▄▄▄
'				█ ▄▄▄ █ ██ ▀▄ █ ▄▄▄ █
'				█ ███ █ ▄▀ ▀▄ █ ███ █
'				█▄▄▄▄▄█ █ ▄▀█ █▄▄▄▄▄█
'				▄▄ ▄  ▄▄▀██▀▀ ▄▄▄ ▄▄
'				 ▀█▄█▄▄▄█▀▀ ▄▄▀█ █▄▀█
'				 █ █▀▄▄▄▀██▀▄ █▄▄█ ▀█
'				▄▄▄▄▄▄▄ █▄█▀ ▄ ██ ▄█
'				█ ▄▄▄ █  █▀█▀ ▄▀▀  ▄▀
'				█ ███ █ ▀▄  ▄▀▀▄▄▀█▀█
'				█▄▄▄▄▄█ ███▀▄▀ ▀██ ▄
'
'-----------------------------------------------------------------------------------------------------------------------------------------------

Public Class MainForm

    'Is it time? Check with a thread
    Dim t As System.Threading.Thread

    'Public variables
    Public menuShow As New ToolStripMenuItem
    Public menuExit As New ToolStripMenuItem
    Public menuAbout As New ToolStripMenuItem

    'Main Form loading event
    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Form title : application name + version
        Me.Text = My.Application.Info.AssemblyName & " - v" & My.Application.Info.Version.ToString

        'Restore chosen time in main Form from user settings
        nudMinute.Value = My.Settings.nudMinute
        nudHour.Value = My.Settings.nudHour

        'Restore chosen action in main Form from user settings
        rbSleep.Checked = My.Settings.rbSleep
        rbReboot.Checked = My.Settings.rbReboot
        rbLogOff.Checked = My.Settings.rbLogOff
        rbShutdown.Checked = My.Settings.rbShutdown

        'Restore startup mode in main Form from user settins
        If My.Settings.cbStartup = True Then
            cbStartup.Checked = True
            Call addAppToStartupFolder()
        Else
            cbStartup.Checked = False
            Call deleteAppFromStartupFolder()
        End If

        'Restore easter egg if discovered
        If My.Settings.easter_egg = True Then
            pbSpinner.Image = My.Resources.spinner_bomberman
            lbText_1.Font = New Font(lbText_1.Font, lbText_1.Font.Style Xor FontStyle.Strikeout)
            lbText_2.Visible = True
        End If

        'Is it time? Check with a thread
        t = New Threading.Thread(AddressOf checkTime)

        'Restore chosen activation state in main Form from user settings
        If My.Settings.activated = True Then
            Call lockForm()
            'Start thread
            t.Start()
        Else
            Call unlockForm()
        End If

        'Add 3 ToolStripMenuItems to the ContextMenuStrip :
        ' - Show
        ' - About
        ' - Exit
        menuShow.Text = "Show"
        menuExit.Text = "Exit"
        menuAbout.Text = "About"
        menuShow.Image = My.Resources.settings_small
        menuExit.Image = My.Resources.exit_small
        menuAbout.Image = My.Resources.about_small
        contextMenuStripMain.Items.Add(menuShow)
        contextMenuStripMain.Items.Add(New ToolStripSeparator())
        contextMenuStripMain.Items.Add(menuAbout)
        contextMenuStripMain.Items.Add(New ToolStripSeparator())
        contextMenuStripMain.Items.Add(menuExit)
        'Show main Form on click event for "Show" menu item
        AddHandler menuShow.Click, AddressOf showApp
        'Close main Form on click event for "Exit" menu item
        AddHandler menuExit.Click, AddressOf Me.Close
        'Show "About" Form on click event for "About" menu item
        AddHandler menuAbout.Click, AddressOf cbAbout_Click

        'Add ContextMenuStrip to the NotifyIcon
        notifyIconMain.ContextMenuStrip = contextMenuStripMain

        'Tooltips
        tooltipMain.SetToolTip(cbAbout, "About " & My.Application.Info.AssemblyName)
        tooltipMain.SetToolTip(cbEnable, "Enable scheduled task")
        tooltipMain.SetToolTip(cbDisable, "Disable scheduled task")
        tooltipMain.SetToolTip(cbReset, "Restore default values")
        tooltipMain.SetToolTip(rbShutdown, "Shutdown computer")
        tooltipMain.SetToolTip(rbReboot, "Reboot computer")
        tooltipMain.SetToolTip(rbLogOff, "Disconnect active user")
        tooltipMain.SetToolTip(rbSleep, "Hibernate computer")

        'Start minimized if at Windows startup
        If My.Application.CommandLineArgs.Count > 0 Then
            If UCase(My.Application.CommandLineArgs.Item(0)) = "--STARTMINIMIZED" Then
                Me.WindowState = FormWindowState.Minimized
            End If
        End If
    End Sub

    'Lock main Form : when thread t is running
    Private Sub lockForm()
        cbEnable.Enabled = False
        cbDisable.Enabled = True
        cbDisable.Focus()
        nudHour.Enabled = False
        nudMinute.Enabled = False
        pbSpinner.Visible = True
        lbText_1.Visible = True
        If My.Settings.easter_egg = True Then
            Call easterEggOn()
        Else
            Call easterEggOff()
        End If
    End Sub

    'Unlock main Form : when thread t is not running
    Private Sub unlockForm()
        cbEnable.Enabled = True
        cbDisable.Enabled = False
        cbEnable.Focus()
        nudHour.Enabled = True
        nudMinute.Enabled = True
        pbSpinner.Visible = False
        lbText_1.Visible = False
        lbText_2.Visible = False
    End Sub

    'Reset main Form to default values
    Private Sub resetForm()
        rbSleep.Checked = True
        nudHour.Value = 20
        nudMinute.Value = 30
    End Sub

    'Is it time? Check with a thread
    Private Sub checkTime()
        'Today at chosen time
        Dim dtNext As New DateTime(Now.Year, Now.Month, Now.Day, My.Settings.nudHour, My.Settings.nudMinute, 0)
        'Is it already time? If yes, let's move to tomorrow!
        If dtNext < DateTime.Now Then
            dtNext = dtNext.AddDays(1)
        End If
        Do
            If dtNext < DateTime.Now Then
                dtNext = dtNext.AddDays(1)
                'Shutdown, hibernate, reboot computer or disconnect 
                If My.Settings.easter_egg = True Then
                    My.Computer.Audio.Play(My.Resources.cash_register, AudioPlayMode.Background)
                End If
                If rbShutdown.Checked Then
                    Call shutdown()
                    notifyIconMain.BalloonTipText = "Click here to cancel computer " & rbShutdown.Text.ToLower & "."
                ElseIf rbSleep.Checked Then
                    Call hibernate()
                ElseIf rbReboot.Checked Then
                    Call reboot()
                    notifyIconMain.BalloonTipText = "Click here to cancel computer " & rbReboot.Text.ToLower & "."
                ElseIf rbLogOff.Checked Then
                    Call logOff()
                End If
                'Abort system shutdown if notification from NotifyIcon is clicked
                If rbShutdown.Checked Or rbReboot.Checked Then
                    notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning
                    notifyIconMain.BalloonTipTitle = My.Application.Info.ProductName
                    notifyIconMain.ShowBalloonTip(1000)
                End If
            End If
            'Sleep 30 seconds
            Threading.Thread.Sleep(30 * 1000)
        Loop
    End Sub

    'If "?" button is clicked, show the "About" Form
    Private Sub cbAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAbout.Click
        ABOUT.Show()
    End Sub

    'If "Enable" button is clicked :
    ' - lock main Form
    ' - start thread t
    Private Sub cbEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbEnable.Click
        Call lockForm()
        t = New Threading.Thread(AddressOf checkTime)
        t.Start()
        My.Settings.activated = True
        My.Settings.Save()
    End Sub

    'If "Reset" button is clicked :
    ' - abort thread t
    ' - unlock main Form
    ' - reset main Form to default values
    Private Sub cbReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbReset.Click
        cbDisable.PerformClick()
        Call resetForm()
    End Sub

    'If "Disable" button is clicked :
    ' - abort thread t
    ' - unlock main Form
    Private Sub cbDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDisable.Click
        t.Abort()
        Call unlockForm()
        My.Settings.activated = False
        My.Settings.Save()
    End Sub

    'When main Form is minimized, hide it and show a notification popup
    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Call hideApp()
        End If
    End Sub

    'When NotifyIcon is clicked, hide or show main Form
    Private Sub NotifyIconMain_MouseUpk(ByVal sender As Object, ByVal e As MouseEventArgs) Handles notifyIconMain.MouseUp
        'Only when left-clicked
        'Right click is for ContextMenuStrip
        If (e.Button = MouseButtons.Left) Then
            If Me.Visible Then
                Me.Hide()
                ABOUT.Hide()
            Else
                Call showApp()
            End If
        End If
    End Sub

    Private Sub showApp()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        'Hotfix for `Me.BringToFront`
        Me.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub hideApp()
        Me.Hide()
        Me.ShowInTaskbar = False
        notifyIconMain.BalloonTipIcon = ToolTipIcon.Info
        notifyIconMain.BalloonTipTitle = My.Application.Info.ProductName
        notifyIconMain.BalloonTipText = "Minimized to the notification area"
        notifyIconMain.ShowBalloonTip(250)
        'If "About" Form is visible, hide it
        ABOUT.Hide()
    End Sub

    'When main Form is closed, destroy its NotifyIcon and abort thread t
    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call exitApp()
    End Sub

    Private Sub exitApp()
        t.Abort()
        notifyIconMain.Visible = False
        notifyIconMain.Icon = Nothing
        notifyIconMain.Dispose()
    End Sub

    'When notification from NotifyIcon is clicked, abort shutdown / reboot or show main Form
    Private Sub notifyIconMain_BalloonTipClicked(ByVal sender As Object, ByVal e As EventArgs) Handles notifyIconMain.BalloonTipClicked
        If (notifyIconMain.BalloonTipIcon = ToolTipIcon.Warning) Then
            Call cancelShutdown()
        Else
            Call showApp()
        End If
    End Sub

    'Set chosen time to user settings from main Form input : Hour, minute
    Private Sub nud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMinute.ValueChanged, nudHour.ValueChanged
        Select Case True
            Case sender Is nudHour
                My.Settings.nudHour = CInt(nudHour.Value)
            Case sender Is nudMinute
                My.Settings.nudMinute = CInt(nudMinute.Value)
        End Select
        My.Settings.Save()
    End Sub

    'Set chosen action to user settings from main Form input : Shutdown, hibernate, reboot computer or disconnect user
    Private Sub rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSleep.CheckedChanged, rbShutdown.CheckedChanged, rbLogOff.CheckedChanged, rbReboot.CheckedChanged
        Select Case True
            Case sender Is rbSleep
                My.Settings.rbSleep = sender.Checked
            Case sender Is rbReboot
                My.Settings.rbReboot = sender.Checked
            Case sender Is rbLogOff
                My.Settings.rbLogOff = sender.Checked
            Case sender Is rbShutdown
                My.Settings.rbShutdown = sender.Checked
        End Select
        My.Settings.Save()
    End Sub

    'Set startup mode to user settings from main Form input : Launch at Windows startup, or not
    Private Sub cbStartup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStartup.CheckedChanged
        My.Settings.cbStartup = cbStartup.Checked
        If cbStartup.Checked = True Then
            Call addAppToStartupFolder()
        Else
            Call deleteAppFromStartupFolder()
        End If
        My.Settings.Save()
    End Sub

    'Easter egg
    Private Sub pbSpinner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSpinner.DoubleClick
        If My.Settings.easter_egg = False Then
            Call easterEggOn()
            My.Settings.easter_egg = True
        Else
            Call easterEggOff()
            My.Settings.easter_egg = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub easterEggOn()
        pbSpinner.Image = My.Resources.spinner_bomberman
        lbText_1.Font = New Font(lbText_1.Font, lbText_1.Font.Style Or FontStyle.Strikeout)
        lbText_2.Visible = True
    End Sub

    Private Sub easterEggOff()
        pbSpinner.Image = My.Resources.spinner
        lbText_1.Font = New Font(lbText_1.Font, lbText_1.Font.Style And Not FontStyle.Strikeout)
        lbText_2.Visible = False
    End Sub

End Class

'If application is already running when started, show main Form
Namespace My
    Partial Friend Class MyApplication
        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            MainForm.Show()
            MainForm.WindowState = FormWindowState.Normal
            MainForm.ShowInTaskbar = True
            'Hotfix for `Me.BringToFront`
            MainForm.TopMost = True
            MainForm.TopMost = False
        End Sub
    End Class
End Namespace
