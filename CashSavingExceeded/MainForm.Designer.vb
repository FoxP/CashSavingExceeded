<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.nudHour = New System.Windows.Forms.NumericUpDown()
        Me.lbTime = New System.Windows.Forms.Label()
        Me.lbMinute = New System.Windows.Forms.Label()
        Me.rbShutdown = New System.Windows.Forms.RadioButton()
        Me.rbSleep = New System.Windows.Forms.RadioButton()
        Me.rbLogOff = New System.Windows.Forms.RadioButton()
        Me.rbReboot = New System.Windows.Forms.RadioButton()
        Me.cbAbout = New System.Windows.Forms.Button()
        Me.notifyIconMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.contextMenuStripMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.nudMinute = New System.Windows.Forms.NumericUpDown()
        Me.cbEnable = New System.Windows.Forms.Button()
        Me.cbReset = New System.Windows.Forms.Button()
        Me.cbDisable = New System.Windows.Forms.Button()
        Me.pbSpinner = New System.Windows.Forms.PictureBox()
        Me.lbText_1 = New System.Windows.Forms.Label()
        Me.lbText_2 = New System.Windows.Forms.Label()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.lbSeparator = New System.Windows.Forms.Label()
        Me.cbStartup = New System.Windows.Forms.CheckBox()
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSpinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudHour
        '
        Me.nudHour.Location = New System.Drawing.Point(56, 12)
        Me.nudHour.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.nudHour.Name = "nudHour"
        Me.nudHour.Size = New System.Drawing.Size(50, 20)
        Me.nudHour.TabIndex = 0
        Me.nudHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbTime
        '
        Me.lbTime.AutoSize = True
        Me.lbTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTime.Location = New System.Drawing.Point(10, 13)
        Me.lbTime.Name = "lbTime"
        Me.lbTime.Size = New System.Drawing.Size(41, 15)
        Me.lbTime.TabIndex = 4
        Me.lbTime.Text = "Time :"
        '
        'lbMinute
        '
        Me.lbMinute.AutoSize = True
        Me.lbMinute.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMinute.Location = New System.Drawing.Point(110, 12)
        Me.lbMinute.Name = "lbMinute"
        Me.lbMinute.Size = New System.Drawing.Size(13, 15)
        Me.lbMinute.TabIndex = 6
        Me.lbMinute.Text = " :"
        '
        'rbShutdown
        '
        Me.rbShutdown.AutoSize = True
        Me.rbShutdown.Location = New System.Drawing.Point(12, 41)
        Me.rbShutdown.Name = "rbShutdown"
        Me.rbShutdown.Size = New System.Drawing.Size(73, 17)
        Me.rbShutdown.TabIndex = 2
        Me.rbShutdown.Text = "Shutdown"
        Me.rbShutdown.UseVisualStyleBackColor = True
        '
        'rbSleep
        '
        Me.rbSleep.AutoSize = True
        Me.rbSleep.Location = New System.Drawing.Point(128, 41)
        Me.rbSleep.Name = "rbSleep"
        Me.rbSleep.Size = New System.Drawing.Size(52, 17)
        Me.rbSleep.TabIndex = 3
        Me.rbSleep.Text = "Sleep"
        Me.rbSleep.UseVisualStyleBackColor = True
        '
        'rbLogOff
        '
        Me.rbLogOff.AutoSize = True
        Me.rbLogOff.Location = New System.Drawing.Point(221, 41)
        Me.rbLogOff.Name = "rbLogOff"
        Me.rbLogOff.Size = New System.Drawing.Size(58, 17)
        Me.rbLogOff.TabIndex = 4
        Me.rbLogOff.Text = "Log off"
        Me.rbLogOff.UseVisualStyleBackColor = True
        '
        'rbReboot
        '
        Me.rbReboot.AutoSize = True
        Me.rbReboot.Location = New System.Drawing.Point(304, 41)
        Me.rbReboot.Name = "rbReboot"
        Me.rbReboot.Size = New System.Drawing.Size(60, 17)
        Me.rbReboot.TabIndex = 5
        Me.rbReboot.Text = "Reboot"
        Me.rbReboot.UseVisualStyleBackColor = True
        '
        'cbAbout
        '
        Me.cbAbout.Cursor = System.Windows.Forms.Cursors.Help
        Me.cbAbout.Location = New System.Drawing.Point(328, 71)
        Me.cbAbout.Name = "cbAbout"
        Me.cbAbout.Size = New System.Drawing.Size(30, 23)
        Me.cbAbout.TabIndex = 9
        Me.cbAbout.Text = "?"
        Me.cbAbout.UseVisualStyleBackColor = True
        '
        'notifyIconMain
        '
        Me.notifyIconMain.Icon = CType(resources.GetObject("notifyIconMain.Icon"), System.Drawing.Icon)
        Me.notifyIconMain.Text = "CashSavingExceeded"
        Me.notifyIconMain.Visible = True
        '
        'contextMenuStripMain
        '
        Me.contextMenuStripMain.Name = "ContextMenuStrip1"
        Me.contextMenuStripMain.Size = New System.Drawing.Size(61, 4)
        '
        'nudMinute
        '
        Me.nudMinute.Location = New System.Drawing.Point(129, 12)
        Me.nudMinute.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudMinute.Name = "nudMinute"
        Me.nudMinute.Size = New System.Drawing.Size(50, 20)
        Me.nudMinute.TabIndex = 1
        Me.nudMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbEnable
        '
        Me.cbEnable.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cbEnable.Location = New System.Drawing.Point(11, 71)
        Me.cbEnable.Name = "cbEnable"
        Me.cbEnable.Size = New System.Drawing.Size(95, 23)
        Me.cbEnable.TabIndex = 6
        Me.cbEnable.Text = "Enable"
        Me.cbEnable.UseVisualStyleBackColor = True
        '
        'cbReset
        '
        Me.cbReset.Location = New System.Drawing.Point(243, 71)
        Me.cbReset.Name = "cbReset"
        Me.cbReset.Size = New System.Drawing.Size(65, 23)
        Me.cbReset.TabIndex = 8
        Me.cbReset.Text = "Reset"
        Me.cbReset.UseVisualStyleBackColor = True
        '
        'cbDisable
        '
        Me.cbDisable.Location = New System.Drawing.Point(127, 71)
        Me.cbDisable.Name = "cbDisable"
        Me.cbDisable.Size = New System.Drawing.Size(95, 23)
        Me.cbDisable.TabIndex = 7
        Me.cbDisable.Text = "Disable"
        Me.cbDisable.UseVisualStyleBackColor = True
        '
        'pbSpinner
        '
        Me.pbSpinner.Image = CType(resources.GetObject("pbSpinner.Image"), System.Drawing.Image)
        Me.pbSpinner.InitialImage = Nothing
        Me.pbSpinner.Location = New System.Drawing.Point(327, 9)
        Me.pbSpinner.Name = "pbSpinner"
        Me.pbSpinner.Size = New System.Drawing.Size(38, 24)
        Me.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbSpinner.TabIndex = 20
        Me.pbSpinner.TabStop = False
        '
        'lbText_1
        '
        Me.lbText_1.AutoSize = True
        Me.lbText_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbText_1.Location = New System.Drawing.Point(187, 15)
        Me.lbText_1.Name = "lbText_1"
        Me.lbText_1.Size = New System.Drawing.Size(147, 13)
        Me.lbText_1.TabIndex = 21
        Me.lbText_1.Text = "Planet saving started, thanks!"
        '
        'lbText_2
        '
        Me.lbText_2.AutoSize = True
        Me.lbText_2.Location = New System.Drawing.Point(219, 15)
        Me.lbText_2.Name = "lbText_2"
        Me.lbText_2.Size = New System.Drawing.Size(114, 13)
        Me.lbText_2.TabIndex = 22
        Me.lbText_2.Text = "cash saving activated!"
        Me.lbText_2.Visible = False
        '
        'lbSeparator
        '
        Me.lbSeparator.AutoSize = True
        Me.lbSeparator.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.lbSeparator.Location = New System.Drawing.Point(-21, 52)
        Me.lbSeparator.Name = "lbSeparator"
        Me.lbSeparator.Size = New System.Drawing.Size(451, 13)
        Me.lbSeparator.TabIndex = 23
        Me.lbSeparator.Text = "__________________________________________________________________________"
        '
        'cbStartup
        '
        Me.cbStartup.AutoSize = True
        Me.cbStartup.Location = New System.Drawing.Point(192, 14)
        Me.cbStartup.Name = "cbStartup"
        Me.cbStartup.Size = New System.Drawing.Size(173, 17)
        Me.cbStartup.TabIndex = 24
        Me.cbStartup.Text = " Launch at user session startup"
        Me.cbStartup.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(370, 100)
        Me.Controls.Add(Me.lbText_2)
        Me.Controls.Add(Me.lbText_1)
        Me.Controls.Add(Me.cbDisable)
        Me.Controls.Add(Me.cbReset)
        Me.Controls.Add(Me.cbAbout)
        Me.Controls.Add(Me.rbReboot)
        Me.Controls.Add(Me.rbLogOff)
        Me.Controls.Add(Me.rbSleep)
        Me.Controls.Add(Me.rbShutdown)
        Me.Controls.Add(Me.cbEnable)
        Me.Controls.Add(Me.lbMinute)
        Me.Controls.Add(Me.lbTime)
        Me.Controls.Add(Me.nudMinute)
        Me.Controls.Add(Me.nudHour)
        Me.Controls.Add(Me.pbSpinner)
        Me.Controls.Add(Me.lbSeparator)
        Me.Controls.Add(Me.cbStartup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "CashSavingExceeded"
        CType(Me.nudHour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSpinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudHour As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbTime As System.Windows.Forms.Label
    Friend WithEvents lbMinute As System.Windows.Forms.Label
    Friend WithEvents rbShutdown As System.Windows.Forms.RadioButton
    Friend WithEvents rbSleep As System.Windows.Forms.RadioButton
    Friend WithEvents rbLogOff As System.Windows.Forms.RadioButton
    Friend WithEvents rbReboot As System.Windows.Forms.RadioButton
    Friend WithEvents cbAbout As System.Windows.Forms.Button
    Friend WithEvents notifyIconMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents contextMenuStripMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents nudMinute As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbEnable As System.Windows.Forms.Button
    Friend WithEvents cbReset As System.Windows.Forms.Button
    Friend WithEvents cbDisable As System.Windows.Forms.Button
    Friend WithEvents pbSpinner As System.Windows.Forms.PictureBox
    Friend WithEvents lbText_1 As System.Windows.Forms.Label
    Friend WithEvents lbText_2 As System.Windows.Forms.Label
    Friend WithEvents tooltipMain As System.Windows.Forms.ToolTip
    Friend WithEvents lbSeparator As System.Windows.Forms.Label
    Friend WithEvents cbStartup As System.Windows.Forms.CheckBox

End Class
