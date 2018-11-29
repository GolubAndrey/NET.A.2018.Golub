using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    public class Process<T,U>
    {
        #region private fields
        private readonly IConverter<T,U> converter;
        private readonly IRepository<T> repository;
        private readonly ISerializer<U> serializer;
        private readonly IValidator<T> validator;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="converter">Converter</param>
        /// <param name="repository">Repository</param>
        /// <param name="serializer">Serializer</param>
        public Process(IConverter<T,U> converter, IRepository<T> repository, ISerializer<U> serializer,IValidator<T> validator)
        {
            this.converter = converter;
            this.repository = repository;
            this.serializer = serializer;
            this.validator = validator;
        }

        #endregion


        #region Public methods
        /// <summary>
        /// Serialization string URLs in file
        /// </summary>
        /// <param name="way">file path to save serialized URLs</param>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when initial data are incorrect</exception>
        public void Start(string way)
        {
            if (way==null)
            {
                throw new ArgumentNullException($"{nameof(way)} can't be null");
            }
            serializer.Serialize(converter.Convert(repository.GetAllElements()), way);
        }
        #endregion
    }
}
