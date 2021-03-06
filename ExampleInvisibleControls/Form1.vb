﻿Imports System.Text

Public Class Form1
    ''' <summary>
    ''' Get visible Label and TextBox controls. Note that the controls
    ''' are not ordered but can be via .OrderBy Lambda extension.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GetVisibleControls_Click(sender As Object, e As EventArgs) Handles GetVisibleControls.Click
        Dim visibleTextBoxes = TextBoxVisibleList()

        If visibleTextBoxes.Count > 0 Then
            Console.WriteLine(String.Join(",", visibleTextBoxes.Select(Function(item) item.Text)))
        End If

        Dim visibleLabels = LabelVisibleList()

        If visibleLabels.Count > 0 Then
            Console.WriteLine(String.Join(",", visibleLabels.Select(Function(item) item.Text)))
        End If

        Dim sb As New StringBuilder

        '
        ' Basics of working with conditions
        '
        If visibleTextBoxes.Count > 0 AndAlso visibleLabels.Count > 0 Then
            sb.Append(String.Join(",", visibleTextBoxes.Select(Function(item) item.Text)) & ",")
            sb.Append(String.Join(",", visibleLabels.Select(Function(item) item.Text)))
        End If

        If sb.Length > 0 Then
            MessageBox.Show(sb.ToString())
        Else
            MessageBox.Show("Nothing to show")
        End If

        '
        ' No assertion, just combine text for each visible control
        '
        Dim textBoxesTextOnly = visibleTextBoxes.Select(Function(item) item.Text).ToArray()
        Dim labelsTextOnly = visibleLabels.Select(Function(item) item.Text).ToArray()
        Dim combined = textBoxesTextOnly.Concat(labelsTextOnly).ToArray()
        Dim results = String.Join(",", combined)

        MessageBox.Show(results)

    End Sub
End Class