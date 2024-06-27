Imports System.Speech
Imports System.Windows.Forms.Application
Imports System.Data.SqlClient

Public Class pin_change

    Dim connection As New SqlConnection("Data Source=DESKTOP-I3LN1OD;Initial Catalog=atm;Integrated Security=True")

    Dim synth As New Synthesis.SpeechSynthesizer
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine

    Private Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted

        reco.RecognizeAsync()

    End Sub

    Private Sub reco_SpeechRecognized(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized

        Select Case e.Result.Text



            Case "one"
                TextBox1.Text += "1"

            Case "two"
                TextBox1.Text += "2"

            Case "three"
                TextBox1.Text += "3"

            Case "four"
                TextBox1.Text += "4"

            Case "five"
                TextBox1.Text += "5"

            Case "six"
                TextBox1.Text += "6"

            Case "seven"
                TextBox1.Text += "7"

            Case "eight"
                TextBox1.Text += "8"

            Case "nne"
                TextBox1.Text += "9"

            Case "zeo"
                TextBox1.Text += "0"
            Case "ok"


                If (TextBox1.TextLength = 4) Then
                    Dim comm As New SqlCommand("update user1 set pin=" + Me.TextBox1.Text + "where accountno =@username", connection)


                    comm.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text

                    Dim adapter As New SqlDataAdapter(comm)

                    Dim table As New DataTable()

                    adapter.Fill(table)
                    synth.SpeakAsync("your new pin is " + TextBox1.Text)
                    synth.SpeakAsync("please wait")
                    synth.SpeakAsync("pin changed successfully")



                    Me.Enabled = False
                    Me.Close()




                    Form2.Show()

                    Form1.Label1.Visible = False
                    Form1.TextBox1.Visible = False

                Else
                    synth.SpeakAsync("please  say, again new four digit pin number")
                    TextBox1.Text = ""


                End If

        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text <= 3 Then
            synth.SpeakAsync("please say new four digit pin number")
            TextBox1.Text = ""
        Else
            If TextBox1.Text >= 5 Then
                synth.SpeakAsync("please say new four digit number")
                TextBox1.Text = ""
            Else

                If (TextBox1.TextLength = 4) Then
                    Dim comm As New SqlCommand("update user1 set pin=" + Me.TextBox1.Text + "where accountno =@username", connection)


                    comm.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text

                    Dim adapter As New SqlDataAdapter(comm)

                    Dim table As New DataTable()

                    adapter.Fill(table)
                    synth.SpeakAsync("your new pin is " + TextBox1.Text)
                    synth.SpeakAsync("please wait")
                    synth.SpeakAsync("pin changed successfully")



                    Me.Enabled = False
                    Me.Close()



                    Form1.Show()

                    Form1.Label1.Visible = False
                    Form1.TextBox1.Visible = False


                End If
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged






    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text += "1"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text += "2"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text += "3"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Text += "4"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text += "5"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Text += "6"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox1.Text += "7"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        TextBox1.Text += "8"
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        TextBox1.Text += "9"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        TextBox1.Text += "0"
    End Sub


    Private Sub pin_change_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim synth As New Synthesis.SpeechSynthesizer

        synth.SpeakAsync("Please Say the new 4 Digit Pin numbe")
        synth.SpeakAsync("After enter new pin ,say ok to change new  pin")
        reco.SetInputToDefaultAudioDevice()

        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("number")

        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "ok")

        colorRule.Add(colorsList)

        gram.Rules.Add(colorRule)

        gram.Root = colorRule

        reco.LoadGrammar(New Recognition.Grammar(gram))

        reco.RecognizeAsync()
    End Sub
End Class