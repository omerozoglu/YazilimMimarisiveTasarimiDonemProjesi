namespace Infrastructure.Utilities.AppSettings {
    public class CollectionNames {
        private CollectionNames (string value) { Value = value; }
        public string Value { get; set; }

        public static CollectionNames AdminCollection { get { return new CollectionNames (nameof (AdminCollection)); } }
        public static CollectionNames DieticianCollection { get { return new CollectionNames (nameof (DieticianCollection)); } }
        public static CollectionNames PatientCollection { get { return new CollectionNames (nameof (PatientCollection)); } }
        public static CollectionNames DietCollection { get { return new CollectionNames (nameof (DietCollection)); } }
        public static CollectionNames DietMethodCollection { get { return new CollectionNames (nameof (DietMethodCollection)); } }
        public static CollectionNames FoodCollection { get { return new CollectionNames (nameof (FoodCollection)); } }
        public static CollectionNames DiseaseCollection { get { return new CollectionNames (nameof (DiseaseCollection)); } }
    }
}