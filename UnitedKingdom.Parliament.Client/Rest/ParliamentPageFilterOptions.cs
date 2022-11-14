namespace UnitedKingdom.Parliament.Rest
{
    public class ParliamentPageFilterOptions
    {
        internal readonly Dictionary<string, string> Filters = new();

        /// <summary>
        /// Selects only records where qsName equals value.
        /// </summary>
        public void AddEquals(string queryStringName, string value) => Filters.Add(queryStringName, value);

        /// <summary>
        /// Selects only records where qsName equals value.
        /// </summary>
        public void AddEquals(string queryStringName, DateTime value) => Filters.Add(queryStringName, value.ToString("s"));

        /// <summary>
        /// Selects only records where qsName equals value.
        /// </summary>
        public void AddEquals(string queryStringName, int value) => Filters.Add(queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName equals value.
        /// </summary>
        public void AddEquals(string queryStringName, double value) => Filters.Add(queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is greater than or equal value
        /// </summary>
        public void AddMinimum(string queryStringName, DateTime value) => Filters.Add("min-" + queryStringName, value.ToString("s"));

        /// <summary>
        /// Selects only records where qsName is greater than or equal value
        /// </summary>
        public void AddMinimum(string queryStringName, int value) => Filters.Add("min-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is greater than or equal value
        /// </summary>
        public void AddMinimum(string queryStringName, double value) => Filters.Add("min-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is less than or equal value
        /// </summary>
        public void AddMaximum(string queryStringName, DateTime value) => Filters.Add("max-" + queryStringName, value.ToString("s"));

        /// <summary>
        /// Selects only records where qsName is less than or equal value
        /// </summary>
        public void AddMaximum(string queryStringName, int value) => Filters.Add("max-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is less than or equal value
        /// </summary>
        public void AddMaximum(string queryStringName, double value) => Filters.Add("max-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is greater than value.
        /// </summary>
        public void AddMinimumExclusive(string queryStringName, DateTime value) => Filters.Add("minEx-" + queryStringName, value.ToString("s"));

        /// <summary>
        /// Selects only records where qsName is greater than value.
        /// </summary>
        public void AddMinimumExclusive(string queryStringName, int value) => Filters.Add("minEx-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is greater than value.
        /// </summary>
        public void AddMinimumExclusive(string queryStringName, double value) => Filters.Add("minEx-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is less than value
        /// </summary>
        public void AddMaximumExclusive(string queryStringName, DateTime value) => Filters.Add("maxEx-" + queryStringName, value.ToString("s"));

        /// <summary>
        /// Selects only records where qsName is less than value
        /// </summary>
        public void AddMaximumExclusive(string queryStringName, int value) => Filters.Add("maxEx-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is less than value
        /// </summary>
        public void AddMaximumExclusive(string queryStringName, double value) => Filters.Add("maxEx-" + queryStringName, value.ToString());

        /// <summary>
        /// Selects only records where qsName is present (true) or not (false)
        /// </summary>
        public void AddExists(string queryStringName, bool value) => Filters.Add("exists-" + queryStringName, value.ToString().ToLower());
    }
}
