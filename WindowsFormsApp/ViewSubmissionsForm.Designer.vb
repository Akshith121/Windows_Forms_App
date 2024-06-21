Imports System.Linq.Expressions
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewSubmissionsForm
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

    Private currentForm As Object
    Private currentIndex As Integer = 0

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load submissions from the backend
        ' Example: submissions = LoadSubmissions()
        Me.KeyPreview = True
        Await LoadCurrentForm()
    End Sub

    Private Async Function LoadCurrentForm() As Task
        Dim apiUrl As String = $"http://localhost:3000/api/v1/read?index={currentIndex}"

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                currentForm = JsonConvert.DeserializeObject(responseBody)

                ShowCurrentSubmission()

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}")
            End Try

        End Using
    End Function

    Private Sub ShowCurrentSubmission()

        If currentForm IsNot Nothing Then
            NameTextBox.Text = currentForm("name")
            EmailTextBox.Text = currentForm("email")
            PhoneNumTextBox.Text = currentForm("phone")
            GithubRepositoryUrlTextBox.Text = currentForm("github_link")
            StopWatchTextBox.Text = currentForm("stopwatch_time")
        End If
    End Sub

    Private Async Function GetTotalFormsCount() As Task(Of Integer)
        Dim apiUrl As String = $"http://localhost:3000/api/v1/length"
        Dim totalNumberOfForms As Integer = 0

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                totalNumberOfForms = JsonConvert.DeserializeObject(responseBody)

            Catch ex As Exception

                MessageBox.Show($"An error occurred: {ex.Message}")
            End Try

        End Using

        Return totalNumberOfForms

    End Function

    Private Async Sub PreviousBtn_Click(sender As Object, e As EventArgs) Handles PreviousBtn.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadCurrentForm()
        End If
    End Sub

    Private Async Sub NextBtn_Click(sender As Object, e As EventArgs) Handles NextBtn.Click
        Dim totalNumberOfForms = Await GetTotalFormsCount()
        If currentIndex < totalNumberOfForms Then
            currentIndex += 1
            Await LoadCurrentForm()
        End If
    End Sub

    ' Handle KeyDown event for keyboard shortcuts
    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            PreviousBtn.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
            NextBtn.PerformClick()
        End If
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()

        Me.components = New System.ComponentModel.Container()
        Me.currentForm = New Object()
        TitleLabel = New System.Windows.Forms.Label()

        Me.NameLabel = New System.Windows.Forms.Label()
        Me.EmailLabel = New System.Windows.Forms.Label()
        Me.PhoneNumLabel = New System.Windows.Forms.Label()
        Me.GithubRepositoryUrlLabel = New System.Windows.Forms.Label()
        Me.StopWatchTimeLabel = New System.Windows.Forms.Label()

        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.PhoneNumTextBox = New System.Windows.Forms.TextBox()
        Me.GithubRepositoryUrlTextBox = New System.Windows.Forms.TextBox()
        Me.StopWatchTextBox = New System.Windows.Forms.TextBox()

        Me.PreviousBtn = New System.Windows.Forms.Button()
        Me.NextBtn = New System.Windows.Forms.Button()

        ' 
        ' TitleLabel
        ' 
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(200, 20)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(400, 31)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Akshith Pittala, Slidely Task 2 - View Submissions"
        'Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' 
        ' NameLabel
        ' 
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(50, 70)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(45, 17)
        Me.NameLabel.TabIndex = 3
        Me.NameLabel.Text = "Name"

        ' 
        ' NameTextBox
        ' 
        Me.NameTextBox.Location = New System.Drawing.Point(200, 70)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.ReadOnly = True
        Me.NameTextBox.Size = New System.Drawing.Size(400, 22)
        Me.NameTextBox.TabIndex = 4

        ' 
        ' EmailLabel
        ' 
        Me.EmailLabel.AutoSize = True
        Me.EmailLabel.Location = New System.Drawing.Point(50, 110)
        Me.EmailLabel.Name = "EmailLabel"
        Me.EmailLabel.Size = New System.Drawing.Size(42, 17)
        Me.EmailLabel.TabIndex = 5
        Me.EmailLabel.Text = "Email"

        ' 
        ' EmailTextBox
        ' 
        Me.EmailTextBox.Location = New System.Drawing.Point(200, 110)
        Me.EmailTextBox.Name = "EmailTextBox"
        Me.EmailTextBox.ReadOnly = True
        Me.EmailTextBox.Size = New System.Drawing.Size(400, 22)
        Me.EmailTextBox.TabIndex = 6

        ' 
        ' PhoneNumLabel
        ' 
        Me.PhoneNumLabel.AutoSize = True
        Me.PhoneNumLabel.Location = New System.Drawing.Point(50, 150)
        Me.PhoneNumLabel.Name = "PhoneNumLabel"
        Me.PhoneNumLabel.Size = New System.Drawing.Size(95, 17)
        Me.PhoneNumLabel.TabIndex = 7
        Me.PhoneNumLabel.Text = "Phone Num"

        ' 
        ' PhoneNumTextBox
        ' 
        Me.PhoneNumTextBox.Location = New System.Drawing.Point(200, 150)
        Me.PhoneNumTextBox.Name = "PhoneNumTextBox"
        Me.PhoneNumTextBox.ReadOnly = True
        Me.PhoneNumTextBox.Size = New System.Drawing.Size(400, 22)
        Me.PhoneNumTextBox.TabIndex = 8

        ' 
        ' GithubRepositoryUrlLabel
        ' 
        Me.GithubRepositoryUrlLabel.AutoSize = True
        Me.GithubRepositoryUrlLabel.Location = New System.Drawing.Point(50, 190)
        Me.GithubRepositoryUrlLabel.Name = "GithubRepositoryUrlLabel"
        Me.GithubRepositoryUrlLabel.Size = New System.Drawing.Size(140, 17)
        Me.GithubRepositoryUrlLabel.TabIndex = 9
        Me.GithubRepositoryUrlLabel.Text = "GitHub Link for Task 2"

        ' 
        ' GithubRepositoryUrlTextBox
        ' 
        Me.GithubRepositoryUrlTextBox.Location = New System.Drawing.Point(200, 190)
        Me.GithubRepositoryUrlTextBox.Name = "GithubRepositoryUrlTextBox"
        Me.GithubRepositoryUrlTextBox.ReadOnly = True
        Me.GithubRepositoryUrlTextBox.Size = New System.Drawing.Size(400, 22)
        Me.GithubRepositoryUrlTextBox.TabIndex = 10

        ' 
        ' StopWatchTimeLabel
        ' 
        Me.StopWatchTimeLabel.AutoSize = True
        Me.StopWatchTimeLabel.Location = New System.Drawing.Point(50, 230)
        Me.StopWatchTimeLabel.Name = "StopWatchTimeLabel"
        Me.StopWatchTimeLabel.Size = New System.Drawing.Size(103, 17)
        Me.StopWatchTimeLabel.TabIndex = 11
        Me.StopWatchTimeLabel.Text = "Stopwatch Time"

        ' 
        ' StopWatchTextBox
        ' 
        Me.StopWatchTextBox.Location = New System.Drawing.Point(200, 230)
        Me.StopWatchTextBox.Name = "StopWatchTextBox"
        Me.StopWatchTextBox.ReadOnly = True
        Me.StopWatchTextBox.Size = New System.Drawing.Size(400, 22)
        Me.StopWatchTextBox.TabIndex = 12

        ' 
        ' PreviousBtn
        ' 
        Me.PreviousBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.PreviousBtn.ForeColor = System.Drawing.Color.Black
        Me.PreviousBtn.Location = New System.Drawing.Point(220, 270)
        Me.PreviousBtn.Margin = New Padding(3, 4, 3, 4)
        Me.PreviousBtn.Name = "PreviousBtn"
        Me.PreviousBtn.Size = New Size(180, 40)
        Me.PreviousBtn.TabIndex = 13
        Me.PreviousBtn.Text = "PREVIOUS (CTRL + P)"
        Me.PreviousBtn.UseVisualStyleBackColor = False

        ' 
        ' NextBtn
        ' 
        Me.NextBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.NextBtn.ForeColor = System.Drawing.Color.Black
        Me.NextBtn.Location = New System.Drawing.Point(410, 270)
        Me.NextBtn.Margin = New Padding(3, 4, 3, 4)
        Me.NextBtn.Name = "NextBtn"
        Me.NextBtn.Size = New Size(180, 40)
        Me.NextBtn.TabIndex = 14
        Me.NextBtn.Text = "NEXT (CTRL + N)"
        Me.NextBtn.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(800, 350)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.NameTextBox)
        Me.Controls.Add(Me.EmailLabel)
        Me.Controls.Add(Me.EmailTextBox)
        Me.Controls.Add(Me.PhoneNumLabel)
        Me.Controls.Add(Me.PhoneNumTextBox)
        Me.Controls.Add(Me.GithubRepositoryUrlLabel)
        Me.Controls.Add(Me.GithubRepositoryUrlTextBox)
        Me.Controls.Add(Me.StopWatchTimeLabel)
        Me.Controls.Add(Me.StopWatchTextBox)
        Me.Controls.Add(Me.PreviousBtn)
        Me.Controls.Add(Me.NextBtn)
        Me.Name = "ViewSubmissionsForm"
        Me.Text = "View Submissions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PreviousBtn As Button
    Friend WithEvents NextBtn As Button
    Friend WithEvents NameLabel As Label
    Friend WithEvents EmailLabel As Label
    Friend WithEvents PhoneNumLabel As Label
    Friend WithEvents GithubRepositoryUrlLabel As Label
    Friend WithEvents StopWatchTimeLabel As Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents PhoneNumTextBox As TextBox
    Friend WithEvents GithubRepositoryUrlTextBox As TextBox
    Friend WithEvents StopWatchTextBox As TextBox
    Friend WithEvents TitleLabel As Label

End Class
