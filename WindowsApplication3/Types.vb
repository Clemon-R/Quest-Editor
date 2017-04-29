Public Class Types
    Public Shared liste As New List(Of Item)

    Public Shared Sub charger()
        Dim first As Boolean = True
        For Each i As Item In liste
            editor.Types.Add(i.name, i)
            editor.obj_type.Items.Add(i.name)
        Next
    End Sub

    Public Shared Sub loadConfig()
        Try
            If IO.File.Exists("Types.txt") Then
                liste.Clear()
                Dim r As New IO.StreamReader("Types.txt", System.Text.Encoding.UTF8)
                Dim l As String
                Do
                    l = r.ReadLine
                    If Not l = Nothing Then
                        Dim s() As String = l.Split("|")
                        Dim i As New Item
                        Dim npc As Boolean = False
                        Dim quest As Boolean = False
                        Dim ans As Boolean = False
                        Dim arg1_activ As Boolean = False
                        Dim arg2_activ As Boolean = False
                        Dim arg1 As String = "Args 1:"
                        Dim arg2 As String = "Args 2:" 
                        If (s(2).Split(",")(0).Equals("true")) Then
                            arg1_activ = True
                            arg1 = s(2).Split(",")(1)
                        End If
                        If (s(3).Split(",")(0).Equals("true")) Then
                            arg2_activ = True
                            arg2 = s(3).Split(",")(1)
                        End If
                        If (s(4).Equals("true")) Then
                            npc = True
                        End If
                        If (s(5).Equals("true")) Then
                            quest = True
                        End If
                        If (s(6).Equals("true")) Then
                            ans = True
                        End If
                        With i
                            .name = s(1)
                            .id = CInt(s(0))
                            .npc = npc
                            .quest = quest
                            .ans = ans
                            .arg1_activ = arg1_activ
                            .arg1 = arg1
                            .arg2_activ = arg2_activ
                            .arg2 = arg2
                        End With
                        liste.Add(i)
                    End If
                Loop Until l = Nothing
                r.Close()
            Else
                MsgBox("Il manque le fichier Types.txt !", MsgBoxStyle.Critical)
                editor.Close()
            End If
        Catch ex As Exception
            MsgBox("Problème avec le fichier Types.txt !", MsgBoxStyle.Critical)
            editor.Close()
        End Try
    End Sub

    Public Class Item
        Public name As String
        Public id As Integer
        Public npc As Boolean
        Public quest As Boolean
        Public ans As Boolean
        Public arg1_activ As Boolean
        Public arg2_activ As Boolean
        Public arg1 As String = "Args 1:"
        Public arg2 As String = "Args 2:"
    End Class
End Class
