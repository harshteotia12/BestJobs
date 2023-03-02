using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace BusinessLogicLayer.Repository
{
    public class GenericRepo : IGenericRepo
    {
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor to initialize the property
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public GenericRepo(IMapper mapper)
        {
            _mapper = mapper;
        }
        public G Add<T,G>(T model, G data)
        {
            _mapper.Map(model, data);
            return data;
        }
    }
}
