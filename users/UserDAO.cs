using Cassandra;
using Cassandra.Data.Linq;
using System.Net;
using users.Models;

namespace users
{
    public class UserDAO : IUserDAO
    {

        private IConfiguration _config;

        public UserDAO(IConfiguration config) {
            //_config = config;
            //string bundle_path = _config.GetValue<string>("cassandraDB:connection-bundle-path");
            //string keyspace = _config.GetValue<string>("cassandraDB:keyspace");
            //string clientId = _config.GetValue<string>("CASSANDRA_CLIENT_ID");
            //string clientSecret = _config.GetValue<string>("CASSANDRA_CLIENT_SECRET");
            //cluster = Cluster.Builder()
            //    .WithCloudSecureConnectionBundle(bundle_path)
            //    .WithCredentials(clientId,clientSecret)
            //    .Build();
            //session = cluster.Connect();
            //session.ChangeKeyspace(keyspace);

            //// query preparation
            //_insertUserStatement = session.Prepare("INSERT INTO user (email, firstname, lastname, salt, hashedpass) VALUES (?,?,?,?,?)");
            //_updateUserNameStatement = session.Prepare("UPDATE user SET firstname=?, lastname=? WHERE email=? IF EXISTS");
            //_deleteUserStatement = session.Prepare("DELETE FROM user WHERE email=? IF EXISTS");
            //_getUserStatement = session.Prepare("SELECT * FROM user WHERE email=?");
        }

        public bool DeleteUser(string email)
        {
            //Statement statement = _deleteUserStatement.Bind(email);
            //session.Execute(statement);
            return true;
        }

        public User? GetUser(string email)
        {
            //Statement statement = _getUserStatement.Bind(email);
            //RowSet setRow = session.Execute(statement);
            //Row firstRow;
            //try
            //{
            //    firstRow = setRow.Single();
            //} catch
            //{
            //    return null;
            //}
            //User user = new()
            //{
            //    Email = email,
            //    FirstName = firstRow.GetValue<string>("firstname"),
            //    LastName = firstRow.GetValue<string>("lastname"),
            //    Salt = firstRow.GetValue<string>("salt"),
            //    HashedPassword = firstRow.GetValue<string>("hashedpass")
            //};
            return null;
        }

        public bool InsertUser(User user)
        {
            //Statement statement = _insertUserStatement.Bind(user.Email, user.FirstName, user.LastName, user.Salt, user.HashedPassword);
            //session.Execute(statement);
            return true;
        }

        public bool UpdateUser(string email, string firstname, string lastname)
        {
            //Statement statement = _updateUserNameStatement.Bind(firstname, lastname, email);
            //session.Execute(statement);
            return true;
        }
    }
}
