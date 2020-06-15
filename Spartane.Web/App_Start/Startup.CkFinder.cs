using CKSource.CKFinder.Connector.Config;
using CKSource.CKFinder.Connector.Core.Builders;
using CKSource.CKFinder.Connector.Host.Owin;
using CKSource.FileSystem;
using CKSource.FileSystem.Local;
using Owin;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Spartane.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureCkFinder(IAppBuilder app)
        {
           
            FileSystemFactory.RegisterFileSystem<LocalStorage>();
            /*
             * Map the CKFinder connector service under a given path. By default the CKFinder JavaScript
             * client expect the ASP.NET connector to be accessible under the "/ckfinder/connector" route.
             */
            app.Map("/ckfinder/connector", SetupConnector);
        }

        private static void SetupConnector(IAppBuilder app)
        {
            /*
             * Create a connector instance using ConnectorBuilder. The call to the LoadConfig() method
             * will configure the connector using CKFinder configuration options defined in Web.config.
             */
            var connectorFactory = new OwinConnectorFactory();
            var connectorBuilder = new ConnectorBuilder();
            /*
             * Create an instance of authenticator implemented in the previous step.
             */
            var customAuthenticator = new CKFinderAuthenticator();
            connectorBuilder
                /*
                 * Provide the global configuration.
                 *
                 * If you installed CKSource.CKFinder.Connector.Config you may load static configuration
                 * from XML:
                 * connectorBuilder.LoadConfig();
                 */

                .SetAuthenticator(customAuthenticator)
                .SetRequestConfiguration(
                    (request, config) =>
                    {
                        var instanceId = request.QueryParameters["id"].FirstOrDefault() ?? string.Empty;
                       
                        //var baseUrl = GetBaseUrlByInstanceId(instanceId);
                        //config.AddProxyBackend("default", new LocalStorage(root));
                        //config.AddProxyBackend("baseUrl", new LocalStorage(@"\ckfinder\userfiles\"));
                        //config.AddResourceType("images", builder => builder.SetBackend("default", "images" ));
                        config.LoadConfig();

                        /*
                         * Configure settings per request.
                         *
                         * The minimal configuration has to include at least one backend, one resource type
                         * and one ACL rule.
                         *
                         * For example:
                         * config.AddBackend("default", new LocalStorage(@"C:\files"));
                
                         config.AddAclRule(new AclRule(
                         *    new StringMatcher("*"),
                         *     new StringMatcher("*"),
                         *     new StringMatcher("*"),
                         *     new Dictionary<Permission, PermissionType> { { Permission.All, PermissionType.Allow } }));
                         *
                         * If you installed CKSource.CKFinder.Connector.Config, you may load the static configuration
                         * from XML:
                         * config.LoadConfig();
                         *
                         * If you installed CKSource.CKFinder.Connector.KeyValue.EntityFramework, you may enable caching:
                         * config.SetKeyValueStoreProvider(
                         *     new EntityFrameworkKeyValueStoreProvider("CKFinderCacheConnection"));
                         */
                    }
                );
            /*
             * Build the connector middleware.
             */
            var connector = connectorBuilder
                .Build(connectorFactory);
            /*
             * Add the CKFinder connector middleware to the web application pipeline.
             */
            app.UseConnector(connector);
        }

        private static string GetRootByInstanceId(string instanceId)
        {

            var filePathFormatos = Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\ImagesCkEditor\Formatos\");
            var pathMap = new Dictionary<string, string>
            {
                 { "formatos", @filePathFormatos },
                 { "", @filePathFormatos },

            };
            string root;
            if (pathMap.TryGetValue(instanceId, out root))
            {
                return root;
            }
            return root;
        }

    }

}