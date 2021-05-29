*****************************************************************************
*			DataKitFramework Prerequisites			    *
*****************************************************************************
1.	If you have purchased a license, put it in your app.config or web.config
	files under appSettings configuration. If you are running a trial then
	you do not need to do this.

	<!-- Add your product key to the web.config or app.config file. -->
	<appSettings>
	    <add key="DataKitFramework" value="9E82D0D47072" />
	</appSettings>

2.	Define your application Tenant class derived from DataKitFramework.Tenant
	in your models class and you a good to go.

    	class AppTenant : DataKitFramework.Tenant
    	{

    	}

3.	If you want your database entries to support auditing, then let your
	models derive from DataKitFramework.Audit.

	public abstract class Product : DataKitFramework.Audit
    	{
        	public string Name { get; set; }

        	public Guid OrderId { get; set; }
        	public virtual Order Order { get; set; }
    	}


For more information please visit https://devtools-ng.com/Examples/DataKitFramework
