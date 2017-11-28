Imports System.Web.Optimization
Imports StructureMap

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        ObjectFactory.Initialize(AddressOf Manager)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <remarks></remarks>
    Private Shared Sub Manager(x As IInitializationExpression)
        x.AddRegistry(New StructureMapRegistry)
    End Sub
End Class
