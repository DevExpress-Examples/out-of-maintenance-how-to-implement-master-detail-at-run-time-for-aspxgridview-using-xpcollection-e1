<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1849)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Q215883/Default.aspx) (VB: [Default.aspx](./VB/Q215883/Default.aspx))
* [Default.aspx.cs](./CS/Q215883/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Q215883/Default.aspx.vb))
* [Global.asax](./CS/Q215883/Global.asax) (VB: [Global.asax](./VB/Q215883/Global.asax))
<!-- default file list end -->
# How to implement master-detail at run-time for ASPxGridView using XPCollection


<p>This example demonstrates how to bind the ASPxGridView within the Detail Template to the XPCollection. This can be done in the same manner, as when the XpoDataSource is used to provide data. This approach is described in the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument3873"><u>How to: Implement Master-Detail at Runtime (XPO)</u></a> help topic. However, binding to the XPCollection has some specific requirements.</p><p>When the detail grid is bound to the XPCollection, the data won't be automatically filtered, as it is in the case of binding to the XpoDataSource. It's possible to use the collection property of the persistent object, retrieved by its key value to populate the detail view with data. It's necessary to create a new XPCollection based on the collection property and specify the DisplayableProperties to prevent the detail view from being populated with reference properties, which can't be serialized.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/K18061">K18061</a></p>

<br/>


