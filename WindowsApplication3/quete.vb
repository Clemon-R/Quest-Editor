Public Class quete
    Private _name As String
    Private _id As Integer
    Private _generale As New generale

    Public Sub New(ByVal name As String, ByVal id As Integer)
        Me._name = name
        Me._id = id
        Me.addQuete()
    End Sub

    Private Sub addQuete()
        editor.quetes.Add(Id, Me)
        editor.liste_quete.AddItem(Name, New String() {Id})
    End Sub

    Public Class generale
        Private _etapes As New Dictionary(Of Integer, etape)
        Private _questID As Integer = 0
        Private _questFin As Integer = 0
        Private _lvlMin As Integer = 1
        Private _unique As Boolean = False
        Public Sub addStep(ByVal id As Integer, ByVal etape As etape)
            _etapes.Add(id, etape)
        End Sub
        Public Function containtStep(ByVal id As Integer) As Boolean
            Return _etapes.ContainsKey(id)
        End Function


#Region "Propriété"
        Public Property Etapes() As Dictionary(Of Integer, etape)
            Get
                Return _etapes
            End Get
            Set(ByVal value As Dictionary(Of Integer, etape))
                _etapes = value
            End Set
        End Property

        Public Property Unique() As Boolean
            Get
                Return _unique
            End Get
            Set(ByVal value As Boolean)
                _unique = value
            End Set
        End Property
        Public Property QuestID() As Integer
            Get
                Return _questID
            End Get
            Set(ByVal value As Integer)
                _questID = value
            End Set
        End Property

        Public Property QuestFin() As Integer
            Get
                Return _questFin
            End Get
            Set(ByVal value As Integer)
                _questFin = value
            End Set
        End Property

        Public Property LvlMin() As Integer
            Get
                Return _lvlMin
            End Get
            Set(ByVal value As Integer)
                _lvlMin = value
            End Set
        End Property
#End Region

        Public Class etape
            Private _name As String
            Private _id As Integer
            Private _quest As Integer
            Private _exp As Integer
            Private _kamas As Integer
            Private _description As String
            Private _items As New Dictionary(Of Integer, Integer)
            Private _objectives As New Dictionary(Of Integer, objective)

            Public Sub New(ByVal name As String, ByVal id As Integer)
                Me._name = name
                Me._id = id
                Me.addStep()
            End Sub

            Private Sub addStep()
                editor.liste_step.AddItem(Name, New String() {Id})
                editor.steps.Add(Id, Me)
            End Sub

            Public Sub addObjective(ByVal id As Integer, ByVal obj As objective)
                _objectives.Add(id, obj)
            End Sub

#Region "Propriété"
            Public Property Objectives() As Dictionary(Of Integer, objective)
                Get
                    Return _objectives
                End Get
                Set(ByVal value As Dictionary(Of Integer, objective))
                    _objectives = value
                End Set
            End Property
            Public Property Items() As Dictionary(Of Integer, Integer)
                Get
                    Return _items
                End Get
                Set(ByVal value As Dictionary(Of Integer, Integer))
                    _items = value
                End Set
            End Property
            Public Property Description() As String
                Get
                    Return _description
                End Get
                Set(ByVal value As String)
                    _description = value
                End Set
            End Property
            Public Property Kamas() As Integer
                Get
                    Return _kamas
                End Get
                Set(ByVal value As Integer)
                    _kamas = value
                End Set
            End Property
            Public Property Quest() As Integer
                Get
                    Return _quest
                End Get
                Set(ByVal value As Integer)
                    _quest = value
                End Set
            End Property
            Public Property Exp() As Integer
                Get
                    Return _exp
                End Get
                Set(ByVal value As Integer)
                    _exp = value
                End Set
            End Property

            Public Property Name() As String
                Get
                    Return _name
                End Get
                Set(ByVal value As String)
                    _name = value
                End Set
            End Property

            Public Property Id() As Integer
                Get
                    Return _id
                End Get
                Set(ByVal value As Integer)
                    _id = value
                End Set
            End Property
#End Region

            Public Class objective
                Private _id As Integer

                Public Sub New(ByVal id As Integer)
                    Me._id = id
                    Me.addObjective()
                End Sub

                Public Sub addObjective()
                    editor.liste_step.AddItem(Name, New String() {Id})
                    editor.steps.Add(Id, Me)
                End Sub

#Region "Propriété"
                Public Property Id() As Integer
                    Get
                        Return _id
                    End Get
                    Set(ByVal value As Integer)
                        _id = value
                    End Set
                End Property
#End Region
            End Class
        End Class
    End Class

#Region "Propriété"
    Public Property General() As generale
        Get
            Return _generale
        End Get
        Set(ByVal value As generale)
            _generale = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
#End Region
End Class
