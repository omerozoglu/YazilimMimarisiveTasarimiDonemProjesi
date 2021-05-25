namespace Infrastructure.Utilities.AppSettings {
    public class MongoDbSettings {
        public string ConnectionString;
        public string DatabaseName;
        //for Configuration
        #region Const Values

        public const string ConnectionStringValue = nameof (ConnectionString);
        public const string DatabaseValue = nameof (DatabaseName);
        #endregion
    }
}