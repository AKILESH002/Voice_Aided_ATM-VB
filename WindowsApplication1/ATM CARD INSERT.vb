Imports System.Speech
Imports System.Data.SqlClient
Public Class ATM_CARD_INSERT
    Dim synth As New Synthesis.SpeechSynthesizer
    Dim connection As New SqlConnection("Data Source=DESKTOP-I3LN1OD;Initial Catalog=atm;Integrated Security=True")

    Private Sub ATM_CARD_INSERT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        synth.SpeakAsync("This ATM Works With Your Voice")
        synth.SpeakAsync("Please Insert Card..")






    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("select * from user1 where accountno ='" + TextBox1.Text + "';", connection)


        command.Parameters.Add("@username", SqlDbType.VarChar).Value = TextBox1.Text


        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            synth.SpeakAsync("invalid account")
            MessageBox.Show("invalid acc")
        Else
            MessageBox.Show("Welcome " + table.Rows.Item(0).Item("name").ToString)
            Dim Str As String
            Str = "Welcome " + table.Rows.Item(0).Item("name").ToString
            Form2.Label2.Text = Str
            Form2.Label2.Visible = "true"
            Form2.Label3.Text = TextBox1.Text
            Me.Hide()
            Form2.Show()
            Form2.Enabled = True

        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class