
Imports System.Speech
    Imports System.Windows.Forms.Application
    Imports System.Data.SqlClient

    Public Class form3


        Dim synth As New Synthesis.SpeechSynthesizer

    Dim connection As New SqlConnection("Data Source=DESKTOP-I3LN1OD;Initial Catalog=atm;Integrated Security=True")
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
    Public Property Stringpass As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim synth As New Synthesis.SpeechSynthesizer
        synth.SpeakAsync("")

        reco.SetInputToDefaultAudioDevice()

        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("number")

        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "send")

        colorRule.Add(colorsList)

        gram.Rules.Add(colorRule)

        gram.Root = colorRule

        reco.LoadGrammar(New Recognition.Grammar(gram))

        reco.RecognizeAsync()
    End Sub
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

            Case "n111ine"
                TextBox1.Text += "9"

            Case "zero"
                TextBox1.Text += "0"



            Case "send"
                If TextBox1.Text = "" Then
                    synth.SpeakAsync("please enter amount")
                Else

                    Dim command As New SqlCommand("select *from user1 where accountno=@username ", connection)

                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text


                    Dim adapter As New SqlDataAdapter(command)

                    Dim table As New DataTable()

                    adapter.Fill(table)

                    Dim Str As String



                    Str = table.Rows.Item(0).Item("balance").ToString



                    If Str <= 500 Then
                        synth.SpeakAsync("your account don't have enough money")
                        synth.SpeakAsync("your account balance is" + Str + "Only")
                        Me.Close()
                        transfer.Close()

                        Me.Enabled = False
                        ATM_CARD_INSERT.Show()


                    Else

                        Dim p As String
                        p = Stringpass


                        Dim st As String
                        st = Me.TextBox1.Text

                        Dim comma As New SqlCommand(" update user1 set balance=balance-" + st + "where accountno=@username update user1 set balance=balance+" + st + " where accountno=" + p, connection)
                        Dim commas As New SqlCommand("insert into trans_details values('Transfer','" + ATM_CARD_INSERT.TextBox1.Text + "','" + st + "','" + p + "',current_timestamp);", connection)
                        comma.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text
                        connection.Open()
                        commas.ExecuteNonQuery()
                        comma.ExecuteNonQuery()
                        connection.Close()

                        synth.SpeakAsync("Please Wait... entered amount is" + TextBox1.Text)
                        synth.SpeakAsync("transfer successfully")
                        synth.SpeakAsync("thankyou for coming")


                        ATM_CARD_INSERT.TextBox1.Text = ""
                        Me.Close()

                        Form1.TextBox1.Visible = False
                        Form1.Label2.Visible = False

                        pin_change.Close()
                        transfer.Close()
                        Form1.Close()
                        Form2.Close()

                        ATM_CARD_INSERT.Show()


                    End If
                End If
        End Select

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

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        TextBox1.Text = ""
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            synth.SpeakAsync("please enter amount")
        Else

            Dim command As New SqlCommand("select *from user1 where accountno=@username ", connection)

            command.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text


            Dim adapter As New SqlDataAdapter(command)

            Dim table As New DataTable()

            adapter.Fill(table)

            Dim Str As String



            Str = table.Rows.Item(0).Item("balance").ToString



            If Str <= 500 Then
                synth.SpeakAsync("your account don't have enough money")
                synth.SpeakAsync("your account balance is" + Str + "Only")
                Me.Close()
                transfer.Close()

                Me.Enabled = False
                ATM_CARD_INSERT.Show()


            Else

                Dim p As String
                p = Stringpass

                Dim st As String
                st = Me.TextBox1.Text

                Dim comma As New SqlCommand(" update user1 set balance=balance-" + st + "where accountno=@username update user1 set balance=balance+" + st + " where accountno=" + p, connection)
                comma.Parameters.Add("@username", SqlDbType.VarChar).Value = ATM_CARD_INSERT.TextBox1.Text
                connection.Open()
                comma.ExecuteNonQuery()
                connection.Close()

                synth.SpeakAsync("Please Wait... entered amount is" + TextBox1.Text)
                synth.SpeakAsync("transfer successfully")
                synth.SpeakAsync("thankyou for coming")


                ATM_CARD_INSERT.TextBox1.Text = ""
                Me.Close()

                Form1.TextBox1.Visible = False
                Form1.Label2.Visible = False

                pin_change.Close()
                transfer.Close()
                Form1.Close()
                Form2.Close()

                ATM_CARD_INSERT.Show()


            End If
        End If

    End Sub
End Class