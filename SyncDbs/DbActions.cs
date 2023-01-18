using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SyncDbs.DestinationModels;
using SyncDbs.Models;
using SyncDbs.SourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SyncDbs
{
    public class DbActions : IDisposable
    {
        private readonly Mapper _mapper;
        private readonly Holoo1Context _source;
        private readonly HoloRepDbContext _destination;
        public int InsertCount { get; set; } = 0;
        public DbActions()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<SyncDbs.DestinationModels.Article, SyncDbs.SourceModels.Article>().ReverseMap();
                cfg.CreateMap<SyncDbs.DestinationModels.Article, SyncDbs.Models.TmpArticles>().ReverseMap();
                cfg.CreateMap<SyncDbs.DestinationModels.Article, SyncDbs.DestinationModels.Articlebackup>().ReverseMap();
            });
            _mapper = new AutoMapper.Mapper(configuration);
            _source = new Holoo1Context();
            _destination = new HoloRepDbContext();
        }
        public bool BackupDestination() 
        {
            try
            {
                _destination.Database.ExecuteSqlRaw("TRUNCATE TABLE ARTICLEBackup");
                Thread.Sleep(1000);
                var articles = _destination.Articles.ToList();
                int articleCount = articles.Count;
                _destination.Articlebackups.AddRange(_mapper.Map<List<DestinationModels.Article>,List<Articlebackup>>(articles));
                if (articleCount > 0)
                {
                    if (_destination.SaveChanges() == articleCount)
                    {
                        articles.Clear();
                        return true;
                    }
                    else 
                    {
                        articles.Clear();
                        return false;
                    }
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ClearDestination()
        {
            _destination.Database.ExecuteSqlRaw("TRUNCATE TABLE ARTICLE");
            Thread.Sleep(1000);
            if (_destination.Articles.Count() == 0)
                return true;
            else
                return false;
        }
        public int UpdateDestination() 
        {
            InsertCount = 0;
            List<TmpArticles> sourceArticles = GetSourceArticles().OrderBy(p => p.ACode).ToList();
            if (sourceArticles != null)
            {
                int sourceCount = sourceArticles.Count;
                if (sourceCount > 0)
                {
                    int count = 0;
                    for (int i = 0; i <= (int)sourceCount / 100; i++)
                    {
                        count = DoTransaction(_mapper.Map<List<DestinationModels.Article>>(sourceArticles.Skip(i * 100).Take(100).ToList()));
                        InsertCount = InsertCount + count;
                    }
                    sourceArticles.Clear();
                }
            }
            return InsertCount;
        }
        public int GetSourceCount() 
        {
            try
            {
                return _source.Articles.Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private List<TmpArticles> GetSourceArticles() 
        {
            List<TmpArticles> result = new List<TmpArticles>();
            foreach (var item in _source.Articles.Select(p => new { p.ACode, p.AName, p.SelPrice, p.Exist, p.ExistMandeh, p.Karton, p.Basteh, p.Weight, p.Weight2 }))
            {
                result.Add(new TmpArticles() {  ACode = item.ACode, AName = item.AName, Basteh = item.Basteh, Exist = item.Exist, ExistMandeh = item.ExistMandeh, Karton = item.Karton, SelPrice = item.SelPrice, Weight = item.Weight, Weight2 = item.Weight2});
            }
            return result;
        }
        private int DoTransaction(List<DestinationModels.Article> destinationArticles) 
        {
            HoloRepDbContext context = null;
            try
            {
                context = new HoloRepDbContext();
                foreach (var entityToInsert in destinationArticles)
                {
                    context.Set<DestinationModels.Article>().Add(entityToInsert);
                }
                var result = context.SaveChanges();
                context.Dispose();
                destinationArticles.Clear();
                return result;
            }
            finally
            {
                if (context != null)
                    context.Dispose();
            }
        }
        public bool AddLog(bool Result,string message = "",long duration = 0) 
        {
            HoloRepDbContext destination = new HoloRepDbContext();
            if(Result)
                destination.RepLogs.Add(new RepLog() {  Id = Guid.NewGuid(), ReplicationDate = DateTime.Now, ResultStatus = "success", Duration = int.Parse(duration.ToString()), Description = message });
            else
                destination.RepLogs.Add(new RepLog() { Id = Guid.NewGuid(), ReplicationDate = DateTime.Now, ResultStatus = "error", Duration = int.Parse(duration.ToString()), Description = message });
            if (destination.SaveChanges() == 1)
                return true;
            else
                return false;
        }
        public void Dispose()
        {
        }
    }
}
