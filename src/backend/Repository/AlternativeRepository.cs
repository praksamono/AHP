using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model.Common;
using Repository.Common;

namespace Repository
{
    public class AlternativeRepository : IAlternativeRepository
    {

        private readonly IMapper _mapper;

        public AlternativeRepository(AHPContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        protected AHPContext _context { get; private set; }

        public async Task<IAlternative> AddAlternativeAsync(IAlternative newAlternative)
        {
            newAlternative.DateCreated = DateTime.UtcNow;

            _context.Alternatives.Add(_mapper.Map<IAlternative, Alternative>(newAlternative));
            await _context.SaveChangesAsync();
            return newAlternative;
        }

        public async Task<bool> DeleteAlternativeAsync(int alternativeUpdate)
        {
            var deleteAlternative = await _context.Alternatives.SingleOrDefaultAsync(x => x.AlternativeId == alternativeUpdate);
            if (deleteAlternative != null)
            {
                _context.Alternatives.Remove(deleteAlternative);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<IAlternative>> GetAllAlternativesAsync()
        {
            var allGoals = await _context.Alternatives.ToListAsync();
            return _mapper.Map<List<IAlternative>>(allGoals);
        }
        
        public async Task<IAlternative> GetAlternativeAsync(int alternativeId)
        {
            var getAlternative = await _context.Alternatives.SingleOrDefaultAsync(x => x.AlternativeId == alternativeId);
            return _mapper.Map<IAlternative>(getAlternative);
        }

        public async Task<bool> UpdateAlternativeAsnyc(IAlternative alternativeUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
