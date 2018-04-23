using System;
using DevExpress.Xpo;

public class Customer : XPObject {
    public Customer(Session session) : base(session) { }

    private string fName;
    public string Name {
        get { return fName; }
        set { SetPropertyValue<string>("Name", ref fName, value); }
    }

    private int fAge;
    public int Age {
        get { return fAge; }
        set { SetPropertyValue<int>("Age", ref fAge, value); }
    }

    [Association("Customer-Orders", typeof(Order))]
    public XPCollection<Order> Orders { get { return GetCollection<Order>("Orders"); } }
}

public class Order : XPObject {
    public Order(Session session) : base(session) { }

    private string fOrderName;
    public string OrderName {
        get { return fOrderName; }
        set { SetPropertyValue<string>("OrderName", ref fOrderName, value); }
    }

    private DateTime fOrderDate;
    public DateTime OrderDate {
        get { return fOrderDate; }
        set { SetPropertyValue<DateTime>("OrderDate", ref fOrderDate, value); }
    }

    private Customer fCustomer;
    [Association("Customer-Orders")]
    public Customer Customer {
        get { return fCustomer; }
        set { SetPropertyValue<Customer>("Customer", ref fCustomer, value); }
    }
}