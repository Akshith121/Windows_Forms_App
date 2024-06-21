Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Reflection.Metadata
Imports System.Text


<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreateSubmissionForm
    Inherits System.Windows.Forms.Form

    Private isEditMode As Boolean = False
    Private userEmailId As String = ""

    Public Sub New(Optional editMode As Boolean = False, Optional userEmailId As String = "")
        InitializeComponent()
        Me.isEditMode = editMode

        If isEditMode Then
            Me.userEmailId = userEmailId
            RestorePreviousData(userEmailId)
        End If

    End Sub

    Public Async Sub RestorePreviousData(emailId)

        Dim apiUrl As String = $"http://localhost:3000/api/v1/read/form?emailId={emailId}"
        Dim currentFormDetails As Object

        Using client As New HttpClient()
            Try
                Dim response As HttpResponseMessage = Await client.GetAsync(apiUrl)
                response.EnsureSuccessStatusCode()

                Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                currentFormDetails = JsonConvert.DeserializeObject(responseBody)

                NameTextBox.Text = currentFormDetails("name")
                EmailTextBox.Text = currentFormDetails("email")
                PhoneNumTextBox.Text = currentFormDetails("phone")
                GithubRepositoryUrlTextBox.Text = currentFormDetails("github_link")
                ElapsedTimeLabel.Text = currentFormDetails("stopwatch_time")

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
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

    Private stopwatch As Stopwatch = New Stopwatch()
    Private timer As Timer = New Timer()

    Private Sub StartandPauseBtn_Click(sender As Object, e As EventArgs) Handles StartandPauseBtn.Click
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        Else
            stopwatch.Start()
        End If
    End Sub

    Private Async Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click

        stopwatch.Stop()
        ' Create an object with the user data
        Dim submission As New With {
            .name = NameTextBox.Text,
            .email = EmailTextBox.Text,
            .phone = PhoneNumTextBox.Text,
            .github_link = GithubRepositoryUrlTextBox.Text,
            .stopwatch_time = stopwatch.Elapsed.ToString("hh\:mm\:ss")
        }

        ' Convert the object to JSON
        'Dim json As String = JsonConverter.SerializeObject(submission)
        'Dim json As Object = submission
        Dim json As Object = JsonConvert.SerializeObject(submission)


        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        ' Define the api endpoint URL
        Dim apiUrl As String

        If isEditMode Then
            apiUrl = $"http://localhost:3000/api/v1/update?emailId={userEmailId}"
            ' Send the PUT request
            Using client As New HttpClient()
                Try
                    Dim response As HttpResponseMessage = Await client.PutAsync(apiUrl, content)
                    response.EnsureSuccessStatusCode()

                    ' Optionally handle the response
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show("Submission successful!")

                    Dim thankYouForm As New ThankYouForm(EmailTextBox.Text)
                    thankYouForm.Show()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        Else
            apiUrl = "http://localhost:3000/api/v1/submit"
            ' Send the POST request
            Using client As New HttpClient()
                Try
                    Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, content)
                    response.EnsureSuccessStatusCode()

                    ' Optionally handle the response
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()
                    MessageBox.Show("Submission successful!")

                    Dim thankYouForm As New ThankYouForm(EmailTextBox.Text)
                    thankYouForm.Show()
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End If


    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            SubmitBtn.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.T Then
            StartandPauseBtn.PerformClick()
        End If
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        timer.Interval = 1000 ' Update every second
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        ElapsedTimeLabel.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        'components = New System.ComponentModel.Container

        Me.NameLabel = New System.Windows.Forms.Label()
        Me.EmailLabel = New System.Windows.Forms.Label()
        Me.PhoneNumLabel = New System.Windows.Forms.Label()
        Me.GithubRepositoryUrlLabel = New System.Windows.Forms.Label()

        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.EmailTextBox = New System.Windows.Forms.TextBox()
        Me.PhoneNumTextBox = New System.Windows.Forms.TextBox()
        Me.GithubRepositoryUrlTextBox = New System.Windows.Forms.TextBox()


        StartandPauseBtn = New System.Windows.Forms.Button()
        Me.ElapsedTimeLabel = New System.Windows.Forms.Label()
        SubmitBtn = New System.Windows.Forms.Button()

        TitleLabel = New System.Windows.Forms.Label()

        '
        ' TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(200, 20)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(400, 31)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "Akshith Pittala, Slidely Task 2 - Create Submission"
        'Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' NameLabel
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(50, 70)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(45, 17)
        Me.NameLabel.TabIndex = 3
        Me.NameLabel.Text = "Name"

        ' NameTextBox
        Me.NameTextBox.Location = New System.Drawing.Point(200, 70)
        Me.NameTextBox.Name = "NameTextBox"
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
        Me.GithubRepositoryUrlTextBox.Size = New System.Drawing.Size(400, 22)
        Me.GithubRepositoryUrlTextBox.TabIndex = 10
        '
        'StartandPauseBtn
        '
        Me.StartandPauseBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.StartandPauseBtn.ForeColor = System.Drawing.Color.Black
        Me.StartandPauseBtn.Location = New System.Drawing.Point(50, 230)
        Me.StartandPauseBtn.Name = "StartandPauseBtn"
        Me.StartandPauseBtn.Size = New System.Drawing.Size(250, 30)
        Me.StartandPauseBtn.TabIndex = 11
        Me.StartandPauseBtn.Text = "TOGGLE STOPWATCH (CTRL + T)"
        Me.StartandPauseBtn.UseVisualStyleBackColor = False
        '
        ' ElapsedTimeLabel
        '
        Me.ElapsedTimeLabel.BackColor = System.Drawing.Color.LightGray
        Me.ElapsedTimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ElapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ElapsedTimeLabel.Location = New System.Drawing.Point(320, 230)
        Me.ElapsedTimeLabel.Name = "ElapsedTimeLabel"
        Me.ElapsedTimeLabel.Size = New System.Drawing.Size(200, 30)
        Me.ElapsedTimeLabel.TabIndex = 12
        Me.ElapsedTimeLabel.Text = "00:00:00"
        '
        ' SubmitBtn
        '
        Me.SubmitBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.SubmitBtn.ForeColor = System.Drawing.Color.Black
        Me.SubmitBtn.Location = New System.Drawing.Point(200, 270)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(200, 30)
        Me.SubmitBtn.TabIndex = 13
        Me.SubmitBtn.Text = "SUBMIT (CTRL + S)"
        Me.SubmitBtn.UseVisualStyleBackColor = False


        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0F, 16.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 400)

        Me.Controls.Add(TitleLabel)
        Me.Controls.Add(NameLabel)
        Me.Controls.Add(NameTextBox)
        Me.Controls.Add(EmailLabel)
        Me.Controls.Add(EmailTextBox)
        Me.Controls.Add(PhoneNumLabel)
        Me.Controls.Add(PhoneNumTextBox)
        Me.Controls.Add(GithubRepositoryUrlLabel)
        Me.Controls.Add(GithubRepositoryUrlTextBox)


        Me.Controls.Add(StartandPauseBtn)
        Me.Controls.Add(Me.ElapsedTimeLabel)
        Me.Controls.Add(SubmitBtn)
        Me.Text = "CreateSubmissionForm"
        Me.SuspendLayout()
    End Sub

    Friend WithEvents StartandPauseBtn As Button
    Friend WithEvents ElapsedTimeLabel As Label
    Friend WithEvents SubmitBtn As Button
    Friend WithEvents NameLabel As Label
    Friend WithEvents EmailLabel As Label
    Friend WithEvents PhoneNumLabel As Label
    Friend WithEvents GithubRepositoryUrlLabel As Label
    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents EmailTextBox As TextBox
    Friend WithEvents PhoneNumTextBox As TextBox
    Friend WithEvents GithubRepositoryUrlTextBox As TextBox
    Friend WithEvents TitleLabel As Label

End Class
