Imports System.Speech
Imports System.Windows.Forms.Application
Public Class cash




    Dim synth As New Synthesis.SpeechSynthesizer
    Dim WithEvents reco As New Recognition.SpeechRecognitionEngine
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim synth As New Synthesis.SpeechSynthesizer
        synth.SpeakAsync("Please Enter the cash digit by digit")
        reco.SetInputToDefaultAudioDevice()

        Dim gram As New Recognition.SrgsGrammar.SrgsDocument

        Dim colorRule As New Recognition.SrgsGrammar.SrgsRule("number")

        Dim colorsList As New Recognition.SrgsGrammar.SrgsOneOf("one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "cash")

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

            Case "nine"
                TextBox1.Text += "9"

            Case "five"
                TextBox1.Text += "0"
            Case "cash"

                synth.SpeakAsync("Please Wait the transcation is processing.... ")
                synth.SpeakAsync("take your cash")
                synth.SpeakAsync("thankyou")

                ATM_CARD_INSERT.Show()
                Me.Hide()


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
        TextBox1.Text += ""
    End Sub
End Class