Imports System
Imports DevExpress.Xpo

Public Class Customer
	Inherits XPObject

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Private fName As String
	Public Property Name() As String
		Get
			Return fName
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("Name", fName, value)
		End Set
	End Property

	Private fAge As Integer
	Public Property Age() As Integer
		Get
			Return fAge
		End Get
		Set(ByVal value As Integer)
			SetPropertyValue(Of Integer)("Age", fAge, value)
		End Set
	End Property

	<Association("Customer-Orders", GetType(Order))>
	Public ReadOnly Property Orders() As XPCollection(Of Order)
		Get
			Return GetCollection(Of Order)("Orders")
		End Get
	End Property
End Class

Public Class Order
	Inherits XPObject

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Private fOrderName As String
	Public Property OrderName() As String
		Get
			Return fOrderName
		End Get
		Set(ByVal value As String)
			SetPropertyValue(Of String)("OrderName", fOrderName, value)
		End Set
	End Property

	Private fOrderDate As DateTime
	Public Property OrderDate() As DateTime
		Get
			Return fOrderDate
		End Get
		Set(ByVal value As DateTime)
			SetPropertyValue(Of DateTime)("OrderDate", fOrderDate, value)
		End Set
	End Property

	Private fCustomer As Customer
	<Association("Customer-Orders")>
	Public Property Customer() As Customer
		Get
			Return fCustomer
		End Get
		Set(ByVal value As Customer)
			SetPropertyValue(Of Customer)("Customer", fCustomer, value)
		End Set
	End Property
End Class