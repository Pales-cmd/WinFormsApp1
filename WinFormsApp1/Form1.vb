Imports System.CodeDom
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = New MySqlConnection()
        conn.ConnectionString =
            "server=127.0.0.1;userid=root;password='';database=test"
        Try
            conn.Open()

            Dim query As String = "INSERT INTO login (username, password) VALUES (@username, @password)"
            COMMAND = New MySqlCommand(query, conn)
            COMMAND.Parameters.AddWithValue("@username", TextBox1.Text)
            COMMAND.Parameters.AddWithValue("@password", TextBox1.Text)

            Dim rowsAffected As Integer = COMMAND.ExecuteNonQuery()
            If rowsAffected > 0 Then
                MessageBox.Show("Data saved successfully!", "Success")
            Else
                MessageBox.Show("No Data inserted.", "Info")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            conn.Close()







        End Try
    End Sub
End Class
