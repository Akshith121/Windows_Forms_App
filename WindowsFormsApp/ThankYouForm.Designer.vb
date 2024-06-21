Imports System.Net.Http

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ThankYouForm
    Inherits System.Windows.Forms.Form

    Private WithEvents backToCreateSubmissionFormLink As LinkLabel
    Dim EmailId As String
    Private WithEvents DeleteFormBtn As Button

    Public Sub New(emailId As String)
        Me.EmailId = emailId
        Me.KeyPreview = True
        InitializeComponent()
    End Sub

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

    Private Async Sub DeleteFormBtn_Click(sender As Object, e As EventArgs) Handles DeleteFormBtn.Click
        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete this form?", "Confirm Deletion", MessageBoxButtons.YesNo)
        If confirmResult = DialogResult.Yes Then
            Dim apiUrl As String = $"http://localhost:3000/api/v1/delete?emailId={EmailId}"

            Using client As New HttpClient()
                Try
                    Dim response As HttpResponseMessage = Await client.DeleteAsync(apiUrl)
                    response.EnsureSuccessStatusCode()

                    MessageBox.Show("Form deleted successfully!")
                    Me.Close()

                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting form: " & ex.Message)
                End Try
            End Using
        End If
    End Sub

    Private Sub ThankYouForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.D Then
            DeleteFormBtn.PerformClick()
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Thank You"
        Me.ClientSize = New System.Drawing.Size(400, 200)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim thankYouLabel As New Label()
        thankYouLabel.Text = "Thank you for your response!"
        thankYouLabel.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        thankYouLabel.AutoSize = True
        thankYouLabel.Location = New Point(50, 50)

        DeleteFormBtn = New System.Windows.Forms.Button()
        DeleteFormBtn.Location = New System.Drawing.Point(100, 150)
        DeleteFormBtn.Name = "DeleteFormBtn"
        DeleteFormBtn.Size = New System.Drawing.Size(240, 30)
        DeleteFormBtn.TabIndex = 13
        DeleteFormBtn.Text = "Delete Form (CTRL + D)"
        DeleteFormBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(252, Byte), Integer))
        DeleteFormBtn.ForeColor = Color.Black
        DeleteFormBtn.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        DeleteFormBtn.UseVisualStyleBackColor = False

        Me.Controls.Add(thankYouLabel)

        backToCreateSubmissionFormLink = New LinkLabel()
        backToCreateSubmissionFormLink.Text = "Click here to edit your response!"
        backToCreateSubmissionFormLink.AutoSize = True
        backToCreateSubmissionFormLink.Location = New Point(50, 100)
        Me.Controls.Add(backToCreateSubmissionFormLink)
        Me.Controls.Add(Me.DeleteFormBtn)
    End Sub

    Private Sub backToFormLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles backToCreateSubmissionFormLink.LinkClicked
        Dim createForm As New CreateSubmissionForm(True, EmailId)
        createForm.Show()
        Me.Close()
    End Sub

End Class
