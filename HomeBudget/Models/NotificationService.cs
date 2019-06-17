using HomeBudget.Models;
using HomeBudget.Hubs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace HomeBudget.Models
{
    public class NotificationService
    {
        
        static readonly string connString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\janek\Desktop\TeamProject\HomeBudget\App_Data\aspnet-HomeBudget-20190326032835.mdf;Initial Catalog=aspnet-HomeBudget-20190326032835;Integrated Security=True";

        internal static SqlCommand command = null;
        internal static SqlDependency dependency = null;

        public static string GetNotification()
        {
            try
            {

                var notifications = new List<Notification>();
                using (var connection = new SqlConnection(connString))
                {

                    connection.Open();
                    using (command = new SqlCommand(@"SELECT [Id],[Message],[Date],[User_Id] FROM [dbo].[Notifications]", connection))
                    {
                        command.Notification = null;

                        if (dependency == null)
                        {
                            dependency = new SqlDependency(command);
                            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);
                        }

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        var reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            notifications.Add(item: new Notification
                            {
                                Id = (int)reader["Id"],
                                Message = reader["Message"] != DBNull.Value ? (string)reader["Message"] : "",
                                Date = (DateTime)reader["Date"]
                            });
                        }
                    }

                }
                var jsonSerialiser = new JavaScriptSerializer();
                var json = jsonSerialiser.Serialize(notifications);
                return json;

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unable to load list of notifications.");
            }


        }

        private static void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (dependency != null)
            {
                dependency.OnChange -= dependency_OnChange;
                dependency = null;
            }
            if (e.Type == SqlNotificationType.Change)
            {
                SenderHub.Show();
            }
        }
    }
}