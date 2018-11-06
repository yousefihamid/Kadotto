using Common.Core;
using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    public class ClientService
    {
        public long Add(ClientDTO pClientDTO)
        {
            long ClientID = 0;
            using (var Context = new BaseContext())
            {
                var Client = new ClientModel
                {
                    Title = pClientDTO.Title,
                    ImageName = pClientDTO.ImageName,
                };
                Context.Clients.Add(Client);
                Context.SaveChanges();
                ClientID = Client.ID;
            }
            return ClientID;
        }

        public long Edit(ClientDTO pClientDTO)
        {
            long ClientID = 0;
            using (var Context = new BaseContext())
            {
                var Client = Context.Clients.FirstOrDefault(a => a.ID == pClientDTO.ID);
                if (Client != null)
                {
                    Client.Title = pClientDTO.Title;
                    Client.ImageName = pClientDTO.ImageName;
                    Context.SaveChanges();
                    ClientID = Client.ID;
                }
            }
            return ClientID;
        }

        public long Delete(long ID)
        {
            long ClientID = 0;
            using (var Context = new BaseContext())
            {
                var Client = Context.Clients.FirstOrDefault(a => a.ID == ID);
                if (Client != null)
                {
                    Context.Clients.Remove(Client);
                    Context.SaveChanges();
                    ClientID = ID;
                }
            }
            return ClientID;
        }

        public List<ClientDTO> GetAll()
        {
            var Result = new List<ClientDTO>();
            using (var Context = new BaseContext())
            {
                Result = Context.Clients
                    .Select(a => new ClientDTO
                    {
                        ID = a.ID,
                        Title = a.Title,
                        ImageName = a.ImageName
                    }).ToList();
            }
            return Result;
        }

        public ClientDTO GetByID(long ID)
        {
            var Result = new ClientDTO();
            using (var Context = new BaseContext())
            {
                var Client = Context.Clients.FirstOrDefault(a => a.ID == ID);
                if (Client != null)
                {
                    Result.ID = Client.ID;
                    Result.Title = Client.Title;
                    Result.ImageName = Client.ImageName;
                }
            }
            return Result;
        }
    }
}
