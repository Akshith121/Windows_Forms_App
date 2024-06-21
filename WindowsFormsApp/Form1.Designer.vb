<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Private Sub ViewSubmissionsBtn_Click(sender As Object, e As EventArgs) Handles ViewSubmissionsBtn.Click
        Dim viewForms As New ViewSubmissionsForm()
        viewForms.Show()
    End Sub

    Private Sub CreateSubmissionBtn_Click(sender As Object, e As EventArgs) Handles CreateSubmissionBtn.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True ' This enables the form to receive key events before the focused control.
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            ViewSubmissionsBtn.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            CreateSubmissionBtn.PerformClick()
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        TitleLabel = New System.Windows.Forms.Label()
        ViewSubmissionsBtn = New Button()
        CreateSubmissionBtn = New Button()
        SuspendLayout()
        ' 
        ' ViewSubmissionsBtn
        ' 
        Me.ViewSubmissionsBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.ViewSubmissionsBtn.ForeColor = System.Drawing.Color.Black
        Me.ViewSubmissionsBtn.Location = New System.Drawing.Point(295, 250)
        Me.ViewSubmissionsBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ViewSubmissionsBtn.Name = "ViewSubmissionsBtn"
        Me.ViewSubmissionsBtn.Size = New System.Drawing.Size(400, 50)
        Me.ViewSubmissionsBtn.TabIndex = 0
        Me.ViewSubmissionsBtn.Text = "VIEW SUBMISSIONS (CTRL + V)"
        Me.ViewSubmissionsBtn.UseVisualStyleBackColor = False
        ' 
        ' CreateSubmissionBtn
        ' 
        Me.CreateSubmissionBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.CreateSubmissionBtn.ForeColor = System.Drawing.Color.Black
        Me.CreateSubmissionBtn.Location = New System.Drawing.Point(295, 320)
        Me.CreateSubmissionBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CreateSubmissionBtn.Name = "CreateSubmissionBtn"
        Me.CreateSubmissionBtn.Size = New System.Drawing.Size(400, 50)
        Me.CreateSubmissionBtn.TabIndex = 1
        Me.CreateSubmissionBtn.Text = "CREATE NEW SUBMISSION (CTRL + N)"
        Me.CreateSubmissionBtn.UseVisualStyleBackColor = False

        '
        ' TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(250, 150)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(400, 37)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Akshith Pittala, Slidely Task 2 - Slidely Form App"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 562)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.ViewSubmissionsBtn)
        Me.Controls.Add(Me.CreateSubmissionBtn)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.Text = "Slidely Forms App"
        Me.ResumeLayout(False)
        Me.PerformLayout()


    End Sub

    Friend WithEvents ViewSubmissionsBtn As System.Windows.Forms.Button
    Friend WithEvents CreateSubmissionBtn As System.Windows.Forms.Button
    Friend WithEvents TitleLabel As System.Windows.Forms.Label

End Class
