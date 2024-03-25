using Cassandra;
using Cassandra.Data.Linq;
using System.Net;
using users.Models;

namespace users
{
    public class UserDAO : IUserDAO
    {
        // singleton object
        //private static UserDAO? _instance = null;
        //public static UserDAO GetUserDAO(ICon)
        //{
        //    if(_instance == null)
        //        _instance = new UserDAO();
        //    return _instance;
        //}



        private ICluster cluster;
        private Cassandra.ISession session;
        private IConfiguration _config;
        private PreparedStatement _insertUserStatement;
        private PreparedStatement _updateUserNameStatement;
        private PreparedStatement _deleteUserStatement;
        private PreparedStatement _getUserStatement;

        public UserDAO(IConfiguration config) {
            _config = config;
            string bundle_path = _config.GetValue<string>("cassandraDB:connection-bundle-path");
            string keyspace = _config.GetValue<string>("cassandraDB:keyspace");
            string clientId = _config.GetValue<string>("CASSANDRA_CLIENT_ID");
            string clientSecret = _config.GetValue<string>("CASSANDRA_CLIENT_SECRET");
            cluster = Cluster.Builder()
                .WithCloudSecureConnectionBundle(bundle_path)
                .WithCredentials(clientId,clientSecret)
                .Build();
            session = cluster.Connect();
            session.ChangeKeyspace(keyspace);

            // query preparation
            _insertUserStatement = session.Prepare("INSERT INTO user (email, firstname, lastname, salt, hashedpass) VALUES (?,?,?,?,?)");
            _updateUserNameStatement = session.Prepare("UPDATE user SET firstname=?, lastname=? WHERE email=? IF EXISTS");
            _deleteUserStatement = session.Prepare("DELETE FROM user WHERE email=? IF EXISTS");
            _getUserStatement = session.Prepare("SELECT * FROM user WHERE email=?");
        }

        public bool DeleteUser(string email)
        {
            Statement statement = _deleteUserStatement.Bind(email);
            session.Execute(statement);
            return true;
        }

        public User? GetUser(string email)
        {
            Statement statement = _getUserStatement.Bind(email);
            RowSet setRow = session.Execute(statement);
            Row firstRow;
            try
            {
                firstRow = setRow.Single();
            } catch
            {
                return null;
            }
            User user = new User();
            user.Email = email;
            user.FirstName = firstRow.GetValue<string>("firstname");
            user.LastName = firstRow.GetValue<string>("lastname");
            user.Salt = firstRow.GetValue<string>("salt");
            user.HashedPassword = firstRow.GetValue<string>("hashedpass");
            return user;
        }

        public bool InsertUser(User user)
        {
            Statement statement = _insertUserStatement.Bind(user.Email, user.FirstName, user.LastName, user.Salt, user.HashedPassword);
            session.Execute(statement);
            return true;
        }

        public bool UpdateUser(string email, string firstname, string lastname)
        {
            Statement statement = _updateUserNameStatement.Bind(firstname, lastname, email);
            session.Execute(statement);
            return true;
        }
    }
}
