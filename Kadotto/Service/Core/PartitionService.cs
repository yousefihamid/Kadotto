using Common.Core;
using DataAccess.Context;
using DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace Service.Core
{
    public class PartitionService
    {
        public long Add(PartitionDTO pPartitionDTO)
        {
            long PartitionID = 0;
            using (var Context = new BaseContext())
            {
                var Partition = new PartitionModel
                {
                    Title = pPartitionDTO.Title,
                    PartitionSize = pPartitionDTO.PartitionSize,
                };
                Context.Partitions.Add(Partition);
                Context.SaveChanges();
                PartitionID = Partition.ID;
            }
            return PartitionID;
        }

        public long Edit(PartitionDTO pPartitionDTO)
        {
            long PartitionID = 0;
            using (var Context = new BaseContext())
            {
                var Partition = Context.Partitions.FirstOrDefault(a => a.ID == pPartitionDTO.ID);
                if (Partition != null)
                {
                    Partition.Title = pPartitionDTO.Title;
                    Partition.PartitionSize = pPartitionDTO.PartitionSize;
                    Context.SaveChanges();
                    PartitionID = Partition.ID;
                }
            }
            return PartitionID;
        }

        public long Delete(long ID)
        {
            long PartitionID = 0;
            using (var Context = new BaseContext())
            {
                var Partition = Context.Partitions.FirstOrDefault(a => a.ID == ID);
                if (Partition != null)
                {
                    Context.Partitions.Remove(Partition);
                    Context.SaveChanges();
                    PartitionID = ID;
                }
            }
            return PartitionID;
        }

        public List<PartitionDTO> GetAll()
        {
            var Result = new List<PartitionDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Partitions
                    .Select(a => new PartitionDTO
                    {
                        ID = a.ID,
                        Title = a.Title,
                        PartitionSize = a.PartitionSize
                    }).ToList();
            }
            return Result;
        }

        public PartitionDTO GetByID(long ID)
        {
            var Result = new PartitionDTO();
            using (var Context = new BaseContext())
            {
                var Partition = Context.Partitions.FirstOrDefault(a => a.ID == ID);
                if (Partition != null)
                {
                    Result.ID = Partition.ID;
                    Result.Title = Partition.Title;
                    Result.PartitionSize = Partition.PartitionSize;
                }
            }
            return Result;
        }
    }
}
