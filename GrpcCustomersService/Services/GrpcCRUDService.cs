using Grpc.Core;
using DataAccess=Hulujan_Iulia_Petruta_Lab2M.Data;
using ModelAccess=Hulujan_Iulia_Petruta_Lab2M.Models;




namespace GrpcCustomersService.Services
{
    public class GrpcCRUDService : CustomerService.CustomerServiceBase
    {
        private DataAccess.Hulujan_Iulia_Petruta_Lab2MContext db = null;
        public GrpcCRUDService(DataAccess.Hulujan_Iulia_Petruta_Lab2MContext db)
        {
            this.db = db;
        }
        public override Task<CustomerList> GetAll(Empty empty, ServerCallContext
       context)
        {

            CustomerList pl = new CustomerList();
            var query = from cust in db.Customer
                        select new Customer()
                        {
                            CustomerId = cust.ID,
                            Name = cust.Name,
                            Adress = cust.Adress,
                            Birthdate = cust.BirthDate.ToString("yyyy-MM-dd")
                        };
            pl.Item.AddRange(query.ToArray());
            return Task.FromResult(pl);
        }
        public override Task<Empty> Insert(Customer requestData, ServerCallContext
       context)
        {
            db.Customer.Add(new ModelAccess.Customer
            {
                ID = requestData.CustomerId,
                Name = requestData.Name,
                Adress = requestData.Adress,
                BirthDate = DateTime.Parse(requestData.Birthdate)
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Customer> Get(CustomerId requestData, ServerCallContext context)
        {
            var data = db.Customer.Find(requestData.Id);

            Customer emp = new Customer()
            {
                CustomerId = data.ID,
                Name = data.Name,
                Adress = data.Adress,
                Birthdate = data.BirthDate.ToString("yyyy-MM-dd")

            };
            return Task.FromResult(emp);
        }

        public override Task<Empty> Delete(CustomerId requestData, ServerCallContext
       context)
        {
            var data = db.Customer.Find(requestData.Id);
            db.Customer.Remove(data);

            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Customer> Update(Customer requestData, ServerCallContext context)
        {
            var data = db.Customer.Find(requestData.CustomerId);
            if (data != null)
            {
                data.Name = requestData.Name;
                data.Adress = requestData.Adress;
                data.BirthDate = DateTime.Parse(requestData.Birthdate);


                db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return Task.FromResult(requestData);
            }
            return Task.FromResult(requestData);
        }
        //public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        //{
        //    logger.LogInformation("The message is received from {Name}", request.Name);

        //    return Task.FromResult(new HelloReply
        //    {
        //        Message = "Hello " + request.Name
        //    });
        //}
    }
}

