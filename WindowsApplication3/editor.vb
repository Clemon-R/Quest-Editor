Imports Quests_Editor.quete
Imports System.Text.RegularExpressions, System.IO.File

Public Class editor
    Public quete As quete
    Private etape As quete.generale.etape
    Private objective As quete.generale.etape.objective
    Public quetes As New Dictionary(Of Integer, quete)
    Public objectives As New Dictionary(Of Integer, quete.generale.etape.objective)
    Public steps As New Dictionary(Of Integer, quete.generale.etape)
    Private _items As New Dictionary(Of Integer, Integer)
    Private _types As New Dictionary(Of String, Types.Item)

    Public Property Types() As Dictionary(Of String, Types.Item)
        Get
            Return _types
        End Get
        Set(ByVal value As Dictionary(Of String, Types.Item))
            _types = value
        End Set
    End Property

#Region "Deplacement de fenetre"
    Dim mouse_offset
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Location = mousePos
        End If
    End Sub
#End Region

#Region "Boutton"
    Private Sub step_add_Click(sender As Object, e As EventArgs) Handles step_add.Click
        Dim id As Integer = CInt(step_itemid.Text)
        If (_items.ContainsKey(id)) Then
            MsgBox("Vous avez déjà mit cette item !", MsgBoxStyle.Information)
            Return
        End If
        _items.Add(id, CInt(step_itemnbr.Text))
        list_items.AddItem(id, New String() {CInt(step_itemnbr.Text)})
    End Sub

    Private Sub step_supr_Click(sender As Object, e As EventArgs) Handles step_supr.Click
        If (IsNothing(list_items.SelectedItems.First)) Then
            MsgBox("Vous devez sélectionner un item !", MsgBoxStyle.Information)
            Return
        End If
        Dim id As Integer = CInt(list_items.SelectedItems.First.Text)
        _items.Remove(id)
        Dim a As UInteger = 0
        While a < list_items.Items.Count
            If (list_items.Items.First.Text = id) Then
                list_items.RemoveItemAt(a)
            End If
            a += 1
        End While
    End Sub

    Private Sub save_step_Click(sender As Object, e As EventArgs) Handles save_step.Click
        saveStep(True)
    End Sub

    Private Sub supr_step_Click(sender As Object, e As EventArgs) Handles supr_step.Click
        If (IsNothing(liste_step.SelectedItems)) Then
            MsgBox("Vous devez sélectionner une étapes !", MsgBoxStyle.Exclamation)
            Return
        End If
        Dim value As Integer = CInt(liste_step.SelectedItems.First.SubItems(0).Text)
        liste_step.RemoveItems(liste_step.SelectedItems)
        steps.Remove(value)
        quete.General.Etapes.Remove(value)
    End Sub
    Private Sub add_step_Click(sender As Object, e As EventArgs) Handles add_step.Click
        Try
            If (Not quete.General.Etapes.ContainsKey(id_step.Text)) Then
                If (id_step.Text < 0) Then
                    MsgBox("Vous ne pouvez utiliser une ID inférieur à 0 !", MsgBoxStyle.Information)
                    Return
                End If
                If (steps.ContainsKey(CInt(id_step.Text))) Then
                    MsgBox("Cette ID est déjà utiliser !", MsgBoxStyle.Exclamation)
                    Return
                End If
                etape = New quete.generale.etape(step_name.Text, CInt(id_step.Text))
                quete.General.addStep(etape.Id, etape)
                'manager.Visible = True
                'manager.TabPages(0).Show()
                'add_step.Enabled = False
                TabPage1.Show()
                TabPage3.Hide()
                TabPage2.Hide()
                saveStep(False)
            Else
                MsgBox("Cette ID est déjà présent dans la quête !", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SelectStep(sender As Object, e As EventArgs) Handles liste_step.DoubleClick, load_step.Click
        If (IsNothing(liste_step.SelectedItems)) Then
            MsgBox("Vous devez sélectionner une étapes !", MsgBoxStyle.Exclamation)
            Return
        End If
        loadStep(CInt(liste_step.SelectedItems.First.SubItems(0).Text))
        TabPage1.Hide()
        TabPage3.Hide()
        TabPage2.Show()
        'manager.TabPages(1).Show()
    End Sub

    Private Sub save_txt_Click(sender As Object, e As EventArgs) Handles save_txt.Click
        If (IsNothing(quete)) Then
            MsgBox("Aucune quête charger !", MsgBoxStyle.Exclamation)
            Return
        End If
        saveQuete(False)
        Dim ligne_sql As String = ""
        Dim ligne_swf As String = ""
        Dim text As String = ""
        Dim unique As String = "0"
        If (quete.General.Unique = True) Then
            unique = "1"
        End If
        Dim steps As String = ""
        Dim x As Integer = 0
        While x < quete.General.Etapes.Count
            If (steps.Length = 0) Then
                steps = quete.General.Etapes.Keys(x)
            Else
                steps &= ";" & quete.General.Etapes.Keys(x)
            End If
            x += 1
        End While
        text = "/*" & quete.Name & "*\" & vbNewLine
        ligne_sql = "INSERT INTO quests(id,steps,startQuestion,endQuestion,minLvl,unique) VALUES " &
        "('" & quete.Id & "','" & steps & "','" & quete.General.QuestID & "','" & quete.General.QuestFin & "','" & quete.General.LvlMin & "','" & unique & "');" & vbNewLine
        ligne_swf = "Q.q[" & quete.Id & "] = " & Chr(34) & quete.Name & Chr(34) & ";" & vbNewLine
        Dim a As Integer = 0
        While a < quete.General.Etapes.Count
            Dim value As quete.generale.etape = quete.General.Etapes.Values(a)
            Dim items_swf As String = "null"
            Dim items_sql As String = ""
            Dim z As UInteger = 0
            Dim first As Boolean = True
            While z < value.Items.Count
                If (first = True) Then
                    items_swf = "["
                End If
                If (items_sql.Length > 0) Then
                    items_swf &= ", "
                    items_sql &= ";"
                End If
                items_swf &= "[" & value.Items.Keys(z) & ", " & value.Items.Values(z) & "]"
                items_sql &= value.Items.Keys(z) & "," & value.Items.Values(z)
                first = False
                z += 1
            End While
            If (Not items_swf.Contains("null")) Then
                items_swf &= "]"
            End If
            Dim exp As String = "null"
            If (value.Exp > 0) Then
                exp = value.Exp
            End If
            Dim kamas As String = "null"
            If (value.Kamas > 0) Then
                kamas = value.Kamas
            End If
            ligne_swf &= "Q.s[" & value.Id & "] = {n: " & Chr(34) & value.Name & Chr(34) & ", d: " & Chr(34) & value.Description & Chr(34) & ", r: [" & exp & ", " & kamas & ", " & items_swf & ", null, null, null]};" & vbNewLine
            ligne_sql &= "INSERT INTO quest_steps(id, question, gainExp, gainKamas, gainItems) VAUES('" & value.Id & "','" & value.Quest & "','" & value.Exp & "','" & value.Kamas & "','" & items_sql & "');" & vbNewLine
            a += 1
        End While
        text &= ligne_sql & vbNewLine
        text &= ligne_swf
        If (IO.File.Exists(quete.Name & ".txt")) Then
            IO.File.Delete(quete.Name & ".txt")
        End If
        IO.File.WriteAllText(quete.Name & "_" & quete.Id & ".txt", text)
        afficheur.sql.Text = ligne_sql
        afficheur.swf.Text = ligne_swf
        afficheur.Show()
        ligne_sql = "SQL" & vbNewLine & ligne_sql
        ligne_swf = "SWF" & vbNewLine & ligne_swf
        MsgBox("Le fichier " & quete.Name & ".txt à bien été créer !", MsgBoxStyle.Information)
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If (IsNothing(quete)) Then
            MsgBox("Aucune quête charger !", MsgBoxStyle.Exclamation)
            Return
        End If
        saveQuete(True)
        MsgBox("Etapes sauvegarder !", MsgBoxStyle.Information)
    End Sub

    Private Sub liste_quete_Click(sender As Object, e As EventArgs) Handles liste_quete.DoubleClick
        saveQuete(False)
        loadQuete(CInt(liste_quete.SelectedItems.First.SubItems(0).Text))
        manager.Visible = True
        etape = Nothing
    End Sub

    Private Sub new_quete_Click(sender As Object, e As EventArgs) Handles new_quete.Click
        Try
            If (Not quetes.ContainsKey(id_quete.Text)) Then
                If (id_quete.Text < 0) Then
                    MsgBox("Vous ne pouvez utiliser une ID inférieur à 0 !", MsgBoxStyle.Information)
                    Return
                End If
                If (quetes.ContainsKey(CInt(id_quete.Text))) Then
                    MsgBox("Cette ID est déjà utiliser !", MsgBoxStyle.Exclamation)
                    Return
                End If
                quete = New quete(name_quete.Text, CInt(id_quete.Text))
                liste_step.RemoveItems(liste_step.Items)
                manager.Visible = True
            Else
                MsgBox("Cette ID est déjà utiliser !", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub closed_Click(sender As Object, e As EventArgs) Handles closed.Click
        MyBase.Close()
    End Sub

    Private Sub minimised_Click(sender As Object, e As EventArgs) Handles minimised.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
#End Region

    Private Sub MyBase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.Resources.quest1
    End Sub

#Region "Protection Champs text"
    Private Sub TextChangedNumeric(sender As Object, e As EventArgs) Handles id_question.Validated, lvl_min.Validated, id_quete.Validated, id_fin.Validated, id_step.Validated,
        step_exp.Validated, step_kamas.Validated, step_quest.Validated, step_itemid.Validated, step_itemnbr.Validated, obj_id.Validated
        Dim button As NSTextBox = sender
        If (Not IsNumeric(button.Text)) Then
            button.Text = "0"
        End If
    End Sub

    Private Sub TextChangedAlpha(sender As Object, e As EventArgs) Handles name_quete.Validated, step_name.Validated, step_description.Validated
        Dim button As NSTextBox = sender
        If (Not IsAlpha(button.Text)) Then
            button.Text = "Undefined"
        End If
    End Sub
#End Region

#Region "Fonction"
    Private Sub loadStep(ByVal id As Integer)
        If (id < 0 Or Not steps.ContainsKey(id)) Then
            Return
        End If
        etape = steps(id)
        step_name.Text = etape.Name
        id_step.Text = etape.Id
        step_exp.Text = etape.Exp
        step_kamas.Text = etape.Kamas
        step_quest.Text = etape.Quest
        step_description.Text = etape.Description
        Dim test As New Dictionary(Of Integer, Integer)
        Dim z As Integer = 0
        While z < etape.Items.Count
            test.Add(etape.Items.Keys(z), etape.Items.Values(z))
            z += 1
        End While
        _items = test
        list_items.RemoveItems(list_items.Items)
        Dim a As Integer = 0
        While a < _items.Count
            list_items.AddItem(_items.Keys(a), _items.Values(a))
            a += 1
        End While
    End Sub

    Private Sub saveStep(ByVal value As Boolean)
        Try
            If (IsNothing(etape)) Then
                Return
            ElseIf (Not quete.General.containtStep(etape.Id)) Then
                Return
            End If
            etape.Quest = CInt(step_quest.Text)
            etape.Kamas = CInt(step_kamas.Text)
            etape.Exp = CInt(step_exp.Text)
            etape.Description = step_description.Text
            Dim test As New Dictionary(Of Integer, Integer)
            Dim a As Integer = 0
            While a < _items.Count
                test.Add(_items.Keys(a), _items.Values(a))
                a += 1
            End While
            etape.Items = test
            If (value) Then
                MsgBox("Etapes sauvegarder !", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub saveQuete(ByVal type As Boolean)
        Try
            If (IsNothing(quete)) Then
                Return
            End If
            If (type) Then
                Dim a As Integer = 0
                Dim secu As Boolean = False
                Dim ligne As NSListView.NSListViewItem = Nothing
                While (a < liste_quete.Items.Count)
                    ligne = liste_quete.Items(a)
                    Dim id As Integer = CInt(ligne.SubItems(0).Text)
                    'MsgBox(a & " " & liste_quete.Items.Count & " " & id & " " & quete.Id)
                    If (id = quete.Id) Then
                        liste_quete.RemoveItem(ligne)
                        quete.Id = CInt(id_quete.Text)
                        quete.Name = name_quete.Text
                        liste_quete.AddItem(quete.Name, New String() {quete.Id})
                        secu = True
                    End If
                    a = a + 1
                End While
                If (secu = False And Not IsNothing(ligne)) Then
                    liste_quete.RemoveItem(ligne)
                    MsgBox("Une erreur ses produite !", MsgBoxStyle.Exclamation)
                End If
            End If
            Dim generale As generale = quete.General
            quete.Name = name_quete.Text
            quete.Id = CInt(id_quete.Text)
            generale.QuestID = CInt(id_question.Text)
            generale.QuestFin = CInt(id_fin.Text)
            generale.LvlMin = CInt(lvl_min.Text)
            generale.Unique = quete_unique.Checked
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub loadQuete(ByVal id As Integer)
        If (Not quetes.ContainsKey(id)) Then
            MsgBox("Impossible de charger cette quête !", MsgBoxStyle.Exclamation)
            Return
        ElseIf (quete.Equals(quetes.Item(id))) Then
            MsgBox("Cette quête est déjà ouverte !", MsgBoxStyle.Exclamation)
            Return
        End If
        quete = quetes.Item(id)
        Dim generale As generale = quete.General
        name_quete.Text = quete.Name
        id_quete.Text = quete.Id
        id_question.Text = generale.QuestID
        id_fin.Text = generale.QuestFin
        lvl_min.Text = generale.LvlMin
        quete_unique.Checked = generale.Unique
        liste_step.RemoveItems(liste_step.Items)
        Dim a As Integer = 0
        While a < generale.Etapes.Count
            Dim value As quete.generale.etape = generale.Etapes.Values(a)
            liste_step.AddItem(value.Name, New String() {value.Id})
            a += 1
        End While
    End Sub

    Private Function IsAlpha(sChr As String) As Boolean
        Dim regex As Regex = New Regex("[a-zA-Z]+")
        Return regex.IsMatch(sChr)
    End Function
#End Region

    Private Sub panel_Click(sender As Object, e As EventArgs) Handles MyBase.Load
        Quests_Editor.Types.loadConfig()
        Quests_Editor.Types.charger()
    End Sub

    Private Sub obj_type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles obj_type.SelectedIndexChanged
        Dim i As Quests_Editor.Types.Item = _types(obj_type.Text)
        If (i.npc = True) Then
            NsLabel14.Visible = True
            obj_pnj.Visible = True
        Else
            NsLabel14.Visible = False
            obj_pnj.Visible = False
            obj_pnj.Text = "0"
        End If
        If (i.quest = True) Then
            NsLabel15.Visible = True
            obj_quest.Visible = True
        Else
            NsLabel15.Visible = False
            obj_quest.Visible = False
            obj_quest.Text = "0"
        End If
        If (i.ans = True) Then
            NsLabel16.Visible = True
            obj_ans.Visible = True
        Else
            NsLabel16.Visible = False
            obj_ans.Visible = False
            obj_ans.Text = "0"
        End If
        If (i.arg1_activ = True) Then
            NsLabel17.Visible = True
            NsLabel17.Value1 = i.arg1
            obj_arg1.Visible = True
        Else
            NsLabel17.Visible = False
            obj_arg1.Visible = False
            obj_arg1.Text = "0"
        End If
        If (i.arg2_activ = True) Then
            NsLabel18.Visible = True
            NsLabel18.Value1 = i.arg2
            obj_arg2.Visible = True
        Else
            NsLabel18.Visible = False
            obj_arg2.Visible = False
            obj_arg2.Text = "0"
        End If
    End Sub

    Private Sub obj_add_Click(sender As Object, e As EventArgs) Handles obj_add.Click
        Try
            If (Not etape.Objectives.ContainsKey(obj_id.Text)) Then
                If (obj_id.Text < 0) Then
                    MsgBox("Vous ne pouvez utiliser une ID inférieur à 0 !", MsgBoxStyle.Information)
                    Return
                End If
                If (objectives.ContainsKey(CInt(obj_id.Text))) Then
                    MsgBox("Cette ID est déjà utiliser !", MsgBoxStyle.Exclamation)
                    Return
                End If
                objective = New quete.generale.etape.objective(CInt(obj_id.Text))
                etape.addObjective(objective.Id, objective)
                'manager.Visible = True
                'manager.TabPages(0).Show()
                'add_step.Enabled = False
                TabPage1.Hide()
                TabPage3.Hide()
                TabPage2.Show()
                'saveStep(False)
            Else
                MsgBox("Cette ID est déjà présent dans l'étape !", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class