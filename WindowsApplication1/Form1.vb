Imports System.Speech
Imports System.Data.SqlClient


Public Class Form1

    Dim connection As New SqlConnection("Data Source=DESKTOP-I3LN1OD;Initial Catalog=atm;Integrated Security=True")
    Dim running As New Int16


    Dim synth As New Synthesis.SpeechSynthesizer
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine




    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        synth.SpeakAsync("say balance to check balance.....say cash to withdraw cash....say change to change pin....say transfer to transfer cash....say leave to exit")
        reco.SetInputToDefaultAudioDevice()
        Label2.Visible = False
        TextBox1.Visible = False
        running = 0


        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("words")

        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("balance", "cash", " change", "leave", "transfer")

        colorRule.Add(colorsList)

        gram.Rules.Add(colorRule)

        gram.Root = colorRule

        reco.LoadGrammar(New Recognition.Grammar(gram))

        reco.RecognizeAsync()
        reco.RecognizeAsyncStop()


    End Sub

    Private Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted

        reco.RecognizeAsync()

    End Sub


    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
        If running = 1 Then


        Else

            Select Case e.Result.Text



                Case "balance"
                    Dim command As New SqlCommand("select * from user1 where accountno = @username", connection)

                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text


                    Dim adapter As New SqlDataAdapter(command)

                    Dim table As New DataTable()

                    adapter.Fill(table)

                    If table.Rows.Count() <= 0 Then

                        synth.SpeakAsync("try again")


                    Else

                        Dim Str As String
                        Str = table.Rows.Item(0).Item("balance").ToString
                        TextBox1.Text = Str



                    End If


                    Label2.Text = "Your Current Account Balance is Rupees:"

                    synth.SpeakAsync("Please Wait ")
                    synth.SpeakAsync(Me.Label2.Text)

                    Label2.Visible = True

                    TextBox1.Visible = True
                    synth.SpeakAsync(TextBox1.Text)

                Case "cash"

                    Me.Hide()
                    cash.Show()
                    running = 1
                Case "change"

                    Me.Hide()
                    running = 1
                    synth.SpeakAsync("Please Wait")
                    Me.Enabled = False

                    pin_change.Show()

                Case "transfer"
                    Me.Hide()
                    running = 1
                    transfer.Show()


                Case "leave"
                    synth.SpeakAsync("thankyou for your's coming..")
                    Me.Close()
                    running = 1
                    ATM_CARD_INSERT.Show()
                    ATM_CARD_INSERT.Enabled = True




            End Select
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As New SqlCommand("select * from user1 where accountno = @username", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text


        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            synth.SpeakAsync("try again")


        Else

            Dim Str As String
            Str = table.Rows.Item(0).Item("balance").ToString
            TextBox1.Text = Str



        End If


        Label2.Text = "Your Current Account Balance is Rupees:"

        synth.SpeakAsync("Please Wait ")
        synth.SpeakAsync("Your Current Account Balance is Rupees :")



        Label2.Visible = True

        TextBox1.Visible = True
        synth.SpeakAsync(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        running = 1
        cash.Show()
        Form2.TextBox1.Text = ""

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        pin_change.Show()
        running = 1
        Form2.TextBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        ATM_CARD_INSERT.Show()
        running = 1
        ATM_CARD_INSERT.TextBox1.Text = ""
        Form2.TextBox1.Text = ""
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        running = 1
        transfer.ShowDialog()

    End Sub
End Class