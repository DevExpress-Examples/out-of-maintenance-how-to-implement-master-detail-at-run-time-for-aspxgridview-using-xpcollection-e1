<%@ Application Language="vb" %>

<script runat="server">

	Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs on application startup
		CreateDataLayer()
		CreateData()
	End Sub

	Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
		'  Code that runs on application shutdown

	End Sub

	Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when an unhandled error occurs

	End Sub

	Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a new session is started

	End Sub

	Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
		' Code that runs when a session ends. 
		' Note: The Session_End event is raised only when the sessionstate mode
		' is set to InProc in the Web.config file. If session mode is set to StateServer 
		' or SQLServer, the event is not raised.

	End Sub

	Private Shared Sub CreateDataLayer()
		Dim dict As DevExpress.Xpo.Metadata.XPDictionary = New DevExpress.Xpo.Metadata.ReflectionDictionary()
		dict.GetDataStoreSchema(GetType(Customer).Assembly)
		DevExpress.Xpo.XpoDefault.Session = Nothing
		Dim prov As DevExpress.Xpo.DB.IDataStore = New DevExpress.Xpo.DB.InMemoryDataStore(New System.Data.DataSet(), DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema)
		DevExpress.Xpo.XpoDefault.DataLayer = New DevExpress.Xpo.SimpleDataLayer(dict, prov)
	End Sub

	Private Sub CreateData()
		Using session As New DevExpress.Xpo.Session()
			Dim customer As New Customer(session)
			customer.Name = "John"
			customer.Age = 21
			customer.Save()
			Dim order As New Order(session)
			order.OrderName = "Chai"
			order.OrderDate = New DateTime(2006, 5, 17)
			order.Customer = customer
			order.Save()
			order = New Order(session)
			order.OrderName = "Chang"
			order.OrderDate = New DateTime(2006, 8, 23)
			order.Customer = customer
			order.Save()
			customer = New Customer(session)
			customer.Name = "Bob"
			customer.Age = 37
			customer.Save()
			order = New Order(session)
			order.OrderName = "Queso Cabrales"
			order.OrderDate = New DateTime(2006, 2, 9)
			order.Customer = customer
			order.Save()
		End Using
	End Sub
</script>