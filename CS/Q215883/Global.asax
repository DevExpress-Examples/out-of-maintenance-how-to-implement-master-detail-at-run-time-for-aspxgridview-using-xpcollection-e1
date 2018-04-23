<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        CreateDataLayer();
        CreateData();   
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    private static void CreateDataLayer() {
        DevExpress.Xpo.Metadata.XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
        dict.GetDataStoreSchema(typeof(Customer).Assembly);
        DevExpress.Xpo.XpoDefault.Session = null;
        DevExpress.Xpo.DB.IDataStore prov = new DevExpress.Xpo.DB.InMemoryDataStore(new System.Data.DataSet(),
            DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
        DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.SimpleDataLayer(dict, prov);
    }

    private void CreateData() {
        using (DevExpress.Xpo.Session session = new DevExpress.Xpo.Session()) {
            Customer customer = new Customer(session);
            customer.Name = "John";
            customer.Age = 21;
            customer.Save();
            Order order = new Order(session);
            order.OrderName = "Chai";
            order.OrderDate = new DateTime(2006, 5, 17);
            order.Customer = customer;
            order.Save();
            order = new Order(session);
            order.OrderName = "Chang";
            order.OrderDate = new DateTime(2006, 8, 23);
            order.Customer = customer;
            order.Save();
            customer = new Customer(session);
            customer.Name = "Bob";
            customer.Age = 37;
            customer.Save();
            order = new Order(session);
            order.OrderName = "Queso Cabrales";
            order.OrderDate = new DateTime(2006, 2, 9);
            order.Customer = customer;
            order.Save();
        }
    }
</script>
