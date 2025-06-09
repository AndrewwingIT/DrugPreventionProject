using DrugPrevention.Repositories.NamND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.NamND
{
    public interface IUnitOfWork : IDisposable
    {
        System_UserAccountRepository System_UserAccountRepository { get; }
        SurveyQuestionsNamNDRepository SurveyQuestionsNamNDRepository { get; }
        SurveysNamNDRepository SurveysNamNDRepository { get; }

        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SU25_PRN222_SE1709_G2_DrugPreventionSystemContext _context;
        private System_UserAccountRepository _systemUserAccountRepository;
        private SurveyQuestionsNamNDRepository _surveyQuestionsNamNDRepository;
        private SurveysNamNDRepository _surveysNamNDRepository;

        public UnitOfWork() => _context ??= new SU25_PRN222_SE1709_G2_DrugPreventionSystemContext();

        public System_UserAccountRepository System_UserAccountRepository
        {
            get { return _systemUserAccountRepository ??= new System_UserAccountRepository(_context); }
        }

        public SurveyQuestionsNamNDRepository SurveyQuestionsNamNDRepository
        {
            get { return _surveyQuestionsNamNDRepository ??= new SurveyQuestionsNamNDRepository(_context); }
        }

        public SurveysNamNDRepository SurveysNamNDRepository
        {
            get { return _surveysNamNDRepository ??= new SurveysNamNDRepository(_context); }
        }

        public void Dispose() => _context.Dispose();

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
