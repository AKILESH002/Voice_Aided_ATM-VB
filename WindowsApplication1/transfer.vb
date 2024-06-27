Imports System.Speech
Imports System.Windows.Forms.Application
Imports System.Data.SqlClient

Public Class transfer




    Dim synth As New Synthesis.SpeechSynthesizer

    Dim connection As New SqlConnection("Data Source=DESKTOP-I3LN1OD;Initial Catalog=atm;Integrated Security=True")
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
    Private Sub transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim synth As New Synthesis.SpeechSynthesizer

        Form1.Close()
        synth.SpeakAsync("Please Say the transfer account number")

        synth.SpeakAsync("after say account number, say ok ")

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
    Private Sub cash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.Close()

    End Sub

    Public Sub reco_RecognizeCompleted(ByVal sender As Object, ByVal e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted

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

            Case "zero"
                TextBox1.Text += "0"


            Case "ok"



                If (TextBox1.TextLength = 4) Then
                        Dim command As New SqlCommand("select * from user1 where accountno = @user ", connection)


                        command.Parameters.Add("@user", SqlDbType.VarChar).Value = Me.TextBox1.Text
                        Dim adapter As New SqlDataAdapter(command)

                        Dim table As New DataTable()

                        adapter.Fill(table)
                        If table.Rows.Count() <= 0 Then

                            synth.SpeakAsync("Wrong Account Number..Please Say the account number Again.")
                            TextBox1.Text = ""
                        Else


                            Dim Str As String
                            Str = table.Rows.Item(0).Item("accountno").ToString





                        If (TextBox1.Text = Str) Then


                            Dim tr As String
                            tr = table.Rows.Item(0).Item("name").ToString
                            synth.SpeakAsync("you entered account number is" + Me.TextBox1.Text + "and account name is" + tr)
                            synth.SpeakAsync("Please Wait")
                            synth.SpeakAsync("Please Enter the cash digit by digit")
                            synth.SpeakAsync("after enter the amount,say 'send' to transfer")
                            Form1.Close()
                            Dim obj As New form3
                            obj.Stringpass = TextBox1.Text
                            obj.Show()
                            Me.Hide()

                        Else
                            synth.SpeakAsync("Wrong account Number..Please Say the account Again..")
                                TextBox1.Text = ""
                            End If
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


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If (TextBox1.TextLength = 4) Then
            Dim command As New SqlCommand("select * from user1 where accountno = @user ", connection)


            command.Parameters.Add("@user", SqlDbType.VarChar).Value = Me.TextBox1.Text
            Dim adapter As New SqlDataAdapter(command)

            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count() <= 0 Then

                synth.SpeakAsync("Wrong Account Number..Please Say the account number Again.")
                TextBox1.Text = ""
            Else


                Dim Str As String
                Str = table.Rows.Item(0).Item("accountno").ToString





                If (TextBox1.Text = Str) Then


                    Dim tr As String
                    tr = table.Rows.Item(0).Item("name").ToString
                    synth.SpeakAsync("you entered account number is" + Me.TextBox1.Text + "and account name is" + tr)
                    synth.SpeakAsync("Please Wait")
                    synth.SpeakAsync("Please Enter the cash digit by digit")
                    synth.SpeakAsync("after enter the amount,say 'send' to transfer")
                    Form1.Close()
                    Dim obj As New form3
                    obj.Stringpass = TextBox1.Text
                    obj.Show()
                    Me.Hide()

                Else
                    synth.SpeakAsync("Wrong account Number..Please Say the account Again..")
                    TextBox1.Text = ""
                End If
            End If


        End If




    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
